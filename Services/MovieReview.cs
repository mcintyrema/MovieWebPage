using RazorPagesReviews.Models;

namespace RazorPagesReviews.Services;
public class MovieReview {
    static List<Movies> Movies {get;}
    static MovieReview()
    {
        Movies = new List<Movies>
        {
            new Movies {Id = 1, Name = "Shutter Island", Genre = "Thriller", Review=Stars.Five},
            new Movies {Id = 2, Name = "La La Land", Genre = "Romance", Review=Stars.Four}
        };
    }

    public static List<Movies> GetAll() => Movies;
    public static Movies? Get(int id) => Movies.FirstOrDefault(m => m.Id == id);
    public static void Add(Movies movie)
    {
        movie.Id = movie.Id++;
        Movies.Add(movie);
    }
    public static void Delete(int id)
    {
        var movie = Get(id);
        if(movie is null)
            return;
        
        Movies.Remove(movie);
    }
    public static void Update(Movies movie){
        var index = Movies.FindIndex(m => m.Id == movie.Id);
        if(index == -1)
            return;
        
        Movies[index] = movie;
    }
}