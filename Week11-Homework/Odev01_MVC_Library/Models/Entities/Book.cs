using System;

namespace Odev01_MVC_Library.Models.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public int PageCount { get; set; }
}
