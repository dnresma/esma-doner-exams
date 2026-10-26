using System;
using EShopApp.Models.ViewModels.Products;

namespace EShopApp.Models.ViewModels.Categories;

public class AdminListItemCategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProductCount { get; set; }
    public List<DetailsProductViewModel> Products { get; set; } = [];
}
