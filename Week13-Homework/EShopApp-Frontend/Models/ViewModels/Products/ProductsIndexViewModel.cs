using System;
using EShopApp.Models.ViewModels.Categories;

namespace EShopApp.Models.ViewModels.Products;

public class ProductsIndexViewModel
{
    public ProductsIndexViewModel(List<ListItemProductViewModel> products, List<ListItemCategoryViewModel> categories, int? selectedCategoryId)
    {
        Products = products;
        Categories = categories;
        SelectedCategoryId = selectedCategoryId;
    }

    public List<ListItemProductViewModel> Products { get; set; } = [];
    public List<ListItemCategoryViewModel> Categories { get; set; } = [];
    public int? SelectedCategoryId { get; set; }
}
