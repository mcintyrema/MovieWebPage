using System.ComponentModel.DataAnnotations;

namespace RazorPagesReviews.Models;
public class Movies{
    public int Id {get; set;}
    public Stars Review {get; set;}

    [Required]
    public string Name {get; set;}
    public string Genre {get; set;}
}

public enum Stars {One, Two, Three, Four, Five}