using System;
namespace EShopApp.Models.ViewModels.Categories
{
    public class CategoriesIndexViewModel
    {
        public CategoriesIndexViewModel(List<ListItemCategoryViewModel> categories, int? selectedCategoryId)
        {
            Categories = categories;
            SelectedCategoryId = selectedCategoryId;
        }

        public List<ListItemCategoryViewModel> Categories { get; set; } = [];
        public int? SelectedCategoryId { get; set; }
    }
}