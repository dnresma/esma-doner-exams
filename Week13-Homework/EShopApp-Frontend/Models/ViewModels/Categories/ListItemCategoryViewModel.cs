using System;

namespace EShopApp.Models.ViewModels.Categories;

public class ListItemCategoryViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProductCount { get; set; }

}
