using System;
using EShopApp.Models.Entities;

namespace EShopApp.Models.ViewModels.Categories;

public class AdminDeleteCategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProductCount { get; set; }
    public List<Product> Products { get; set; } = [];
}
