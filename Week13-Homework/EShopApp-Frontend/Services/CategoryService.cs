using System;
using EShopApp.Data.Repositories;
using EShopApp.Models.Entities;
using EShopApp.Models.ViewModels.Categories;
using EShopApp.Models.ViewModels.Products;

namespace EShopApp.Services;

public class CategoryService
{
    private readonly CategoryRepository _categoryRepository;

    private readonly ProductRepository _productRepository;

    public CategoryService(CategoryRepository categoryRepository, ProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
    }


    // Tupple
    public async Task<(bool Success, string Message)> CreateCategoryAsync(AdminCreateCategoryViewModel model)
    {
        var existsCategoryName = await _categoryRepository.ExistsCategoryName(model.Name);
        if (existsCategoryName)
        {
            return (false, $"{model.Name} adlı kategori zaten mevcut olduğu için oluşturulamadı. Lütfen başka bir kategori adı deneyin.");
        }
        var category = new Category
        {
            Name = model.Name,
            Description = model.Description
        };
        await _categoryRepository.AddAsync(category);
        return (true, "Kategori başarıyla oluşturuldu.");
    }

    public async Task<(bool Success, string Message)> UpdateCategoryAsync(AdminUpdateCategoryViewModel model)
    {
        var category = await _categoryRepository.GetByIdAsync(model.Id);
        if (category is null)
        {
            return (false, "Kategori bulunamadı.");
        }
        var existsCategoryName = await _categoryRepository.ExistsCategoryName(model.Name);
        if (existsCategoryName && category.Id != model.Id)
        {
            return (false, "Bu kategori adı zaten mevcut olduğu için kategori güncellenemedi.");
        }
        category.Name = model.Name;
        category.Description = model.Description;
        await _categoryRepository.UpdateAsync(category);
        return (true, "Kategori başarıyla güncellendi.");
    }

    public async Task<(bool Success, string Message)> DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetByIdWithProductsAsync(id);
        if (category is null)
        {
            return (false, "Kategori bulunamadı.");
        }
        int productsCount = category.Products.Count;
        if (productsCount > 0)
        {
            return (false, $"Bu kategoride {productsCount} adet ürün kayıtlı olduğu için silinemedi. Önce bu ürünleri silin ya da başka kategoriye taşıyın.");
        }
        await _categoryRepository.RemoveAsync(category);
        return (true, "Kayıt başarıyla silindi.");
    }

    public async Task<(bool Success, string Message, List<AdminListItemCategoryViewModel>? Categories)> GetAllCategoriesForAdminAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var models = categories
            .Select(c => new AdminListItemCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                ProductCount = c.Products.Count
            }).ToList();
        return (true, "Kategori listesi başarıyla çekildi.", models);
    }

    public async Task<(bool Success, string Message, List<ListItemCategoryViewModel> Categories)> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var models = categories
            .Select(c => new ListItemCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                ProductCount = c.Products.Count
            }).ToList();
        return (true, "Kategori listesi başarıyla çekildi.", models);
    }

    
    public async Task<(bool Success, string Message, DetailsCategoryViewModel? Category, DetailsProductViewModel? Product)> GetCategoryDetailsAsync(int id)
    {
        var category = await _categoryRepository.GetByIdWithProductsAsync(id);

        if (category is null)
        {
            return (false, "Kategori bulunamadı.", null, null);
        }

        var model = new DetailsCategoryViewModel
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description ?? string.Empty,
            ProductCount = category.Products.Count,

            Products = category.Products.Select(p => new DetailsProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                ImageUrl = p.ImageUrl,
                CategoryId = p.CategoryId,
                CategoryName = category.Name
            }).ToList()
        };
        return (true, "Kategori başarıyla çekildi.", model, null);
    }


}
