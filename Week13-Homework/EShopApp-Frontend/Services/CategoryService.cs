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
    
    public async Task<(bool Success, string Message)> CreateCategoryAsync(
        AdminCreateCategoryViewModel model)
    {
        var name = model.Name.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            return (false, "Kategori adı zorunludur.");
        }

        var existsCategoryName = await _categoryRepository.ExistsCategoryName(name);

        if (existsCategoryName)
        {
            return (
                false,
                $"{name} adlı kategori zaten mevcut. Başka bir ad deneyin."
            );
        }

        var category = new Category
        {
            Name = name,
            Description = model.Description?.Trim()
        };

        await _categoryRepository.AddAsync(category);

        return (true, "Kategori başarıyla oluşturuldu.");
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

    public async Task<AdminUpdateCategoryViewModel?> GetCategoryForUpdateAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null) return null;

        return new AdminUpdateCategoryViewModel
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description
        };
    }

    public async Task<(bool Success, string Message)> UpdateCategoryAsync(AdminUpdateCategoryViewModel model)
    {
        var name = model.Name.Trim();
        if (string.IsNullOrWhiteSpace(name))
            return (false, "Kategori adı zorunludur.");

        var category = await _categoryRepository.GetByIdAsync(model.Id);
        if (category is null)
            return (false, "Kategori bulunamadı.");

        if (await _categoryRepository.ExistsCategoryName(name, model.Id))
            return (false, $"{name} adlı başka bir kategori zaten mevcut. Başka bir ad deneyin.");

        category.Name = name;
        category.Description = model.Description?.Trim();
        await _categoryRepository.UpdateAsync(category);

        return (true, "Kategori başarıyla güncellendi.");
    }

    public async Task<AdminDeleteCategoryViewModel?> GetCategoryForDeleteAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null) return null;

        return new AdminDeleteCategoryViewModel { Id = category.Id, Name = category.Name };
    }

    public async Task<(bool Success, string Message)> DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category is null)
            return (false, "Kategori bulunamadı.");

        await _categoryRepository.RemoveAsync(category);
        return (true, "Kategori silindi.");
    }
}
