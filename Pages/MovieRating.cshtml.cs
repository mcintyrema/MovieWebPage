using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesReviews.Models;
using RazorPagesReviews.Services;
using Newtonsoft.Json;


namespace RazorPagesReviews.Pages
{
    public class MovieRatingModel : PageModel
    {
        public void OnGet()
        {
            ratings = MovieRating.GetAll();
        }

        public List<Ratings> ratings = new();

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            MovieRating.Add(NewRating);
            MovieReview.Add(NewRating);
            return RedirectToAction("Get");
        }

        [BindProperty]
        public Ratings NewRating {get; set;} = new();
        Dictionary<string, string> dictRatings = 
        new Dictionary<string, string> { { "passedObject", JsonConvert.SerializeObject(NewRating) } };

        
        public IActionResult OnPostDelete(int id)
        {
            MovieRating.Delete(id);
            MovieReview.Delete(id);
            return RedirectToAction("Get");
        }

    }
    
}
