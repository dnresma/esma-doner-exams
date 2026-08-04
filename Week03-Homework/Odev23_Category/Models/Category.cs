using System;

namespace Odev23_Category.Models;

public class Category
{
    public Category(string? name)
    {
        Name = name;
        Description = "";
    }
    public Category(string? name, string? description)
    {
        Name = name;
        Description = description;
    }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
