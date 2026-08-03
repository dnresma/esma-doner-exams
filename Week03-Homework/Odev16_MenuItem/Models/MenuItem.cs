using System;

namespace Odev16_MenuItem.Models;

public class MenuItem
{
    public MenuItem(string? name, string? description, decimal price, bool isVegetarian)
    {
        Name = name;
        Description = description;
        Price = price;
        IsVegetarian = isVegetarian;
    }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsVegetarian { get; set; }
    

}
