using System;

namespace EShopApp.Models.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int ProductCount { get; set; }
    public List<Product> Products { get; set; } = [];
}
