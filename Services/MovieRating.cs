using RazorPagesReviews.Models;

namespace RazorPagesReviews.Services;
public class MovieRating : MovieReview
{
//  inherited from MovieReview.cs 
static List<Ratings> Ratings {get;}
    static MovieRating()
    {
        Ratings = new List<Ratings>
        {
            new Ratings {Id = 1, Name = "Shutter Island", Genre = "Thriller", Review=Stars.Five},
            new Ratings {Id = 2, Name = "La La Land", Genre = "Romance", Review=Stars.Four}
        };
    }

    public static List<Ratings> GetAll() => Ratings;
    public static Ratings? Get(int id) => Ratings.FirstOrDefault(m => m.Id == id);
    public static void Add(Ratings rating)
    {
        rating.Id = rating.Id++;
        Ratings.Add(rating);
    }
    public static void Delete(int id)
    {
        var rating = Get(id);
        if(rating is null)
            return;
        
        Ratings.Remove(rating);
    }
    public static void Update(Ratings rating){
        var index = Ratings.FindIndex(m => m.Id == rating.Id);
        if(index == -1)
            return;
        
        Ratings[index] = rating;
    }
}