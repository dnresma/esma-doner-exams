using System;

namespace Odev30_Movie.Models;

public class Movie
{
    public Movie(string? title, string? director)
    {
        Title = title;
        Director = director;
        DurationMinutes = 120;
    }
    public Movie(string? title, string? director, int durationminutes)
    {
        Title = title;
        Director = director;
        DurationMinutes = durationminutes;
    }

    public string? Title { get; set; }
    public string? Director { get; set; }
    public int DurationMinutes { get; set; }
    public double Rating { get; set; }
}
