using System.ComponentModel.DataAnnotations;
namespace RazorPagesReviews.Models;
public class Ratings : Movies
{
    // inherits movies from Movies.cs model
    public string Rating {get; set;}

}

