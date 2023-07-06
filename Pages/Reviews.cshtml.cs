using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesReviews.Models;
using RazorPagesReviews.Services;

namespace RazorPagesReviews.Pages
{
    public class ReviewsModel : PageModel
    {
        public void OnGet()
        {
            movie = MovieReview.GetAll();
        }
        public List<Movies> movie = new();
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            MovieReview.Add(NewMovie);
            MovieRating.Add(NewRating);
            return RedirectToAction("Get");
        }
        [BindProperty]
        public Movies NewMovie { get; set; } = new();
        public IActionResult OnPostDelete(int id)
        {
            MovieReview.Delete(id);
            MovieRating.Delete(id); // deletes review from other page too
            return RedirectToAction("Get");
        }
        public Ratings NewRating {get; set;}
        public IActionResult OnGet(string passedObject)
        {
            NewRating = JsonConvert.DeserializeObject<Ratings>(passedObject);

            if(NewRating == null){
                return NotFound();
            }
            return Page();
        }
    }
}
