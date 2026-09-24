using System;

namespace Odev02_MC_MovieArchive.Models.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Director { get; set; } = null!;
    public int ReleaseYear { get; set; }
}
