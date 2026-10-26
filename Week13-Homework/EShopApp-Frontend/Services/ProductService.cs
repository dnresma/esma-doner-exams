using System;
using EShopApp.Data.Repositories;
using EShopApp.Models.Entities;
using EShopApp.Models.ViewModels.Products;

namespace EShopApp.Services;

public class ProductService
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryRepository _categoryRepository;
    private readonly IWebHostEnvironment _env;

    public ProductService(ProductRepository productRepository, CategoryRepository categoryRepository, IWebHostEnvironment env)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _env = env;
    }

    public async Task<(bool Success, string Message, int? ProductId)> CreateProductAsync(AdminCreateProductViewModel model, IFormFile? imageFile = null)
    {
        var category = await _categoryRepository.GetByIdAsync(model.CategoryId);
        if (category is null)
        {
            return (false, "İlgili kategori bulunamadığı için, ürün kaydedilemedi.", null);
        }

        var imageUrl = string.Empty;
        if(imageFile is not null)
        {
            var (successImage, messageImage, uploadedUrl) = await UploadImageAsync(imageFile);
            if(!successImage) return (false, messageImage, null);
            imageUrl = uploadedUrl;
        }

        var product = new Product
        {
            Name = model.Name,
            Description = model.Description,
            Price = model.Price,
            StockQuantity = model.StockQuantity,
            ImageUrl = imageUrl!,
            CategoryId = model.CategoryId
        };

        try
        {
            await _productRepository.AddAsync(product);
        }
        catch
        {
            DeleteImageFile(imageUrl);
            return (false, "Ürün oluşturulamadı",null);
        }
        
        return (true, $"Ürün başarıyla oluşturuldu. ", product.Id);
    }

    public async Task<(bool Success, string Message)> UpdateProductAsync(AdminUpdateProductViewModel model, IFormFile? imageFile = null)
    {
        var product = await _productRepository.GetByIdForEditAsync(model.Id);
        if (product is null)
        {
            return (false, "Ürün bulunamadığı için güncellenemedi.");
        }

        var category = await _categoryRepository.GetByIdAsync(model.CategoryId);
        if (category is null)
        {
            return (false, "İlgili kategori bulunamadığı için, ürün güncellenemedi.");
        }

        var oldImageUrl = product.ImageUrl;
        var newImageUrl = string.Empty;
        if(string.IsNullOrEmpty(oldImageUrl) && (imageFile is null))
        {
            return (false, "Lütfen bir resim seçin.");
        }

        if(imageFile is not null)
        {
            var (successImage, messageImage, uploadedUrl) = await UploadImageAsync(imageFile);
            if(!successImage) return (false, messageImage);
            newImageUrl = uploadedUrl;
            product.ImageUrl = newImageUrl!;
        }

        product.Name = model.Name;
        product.Description = model.Description;
        product.Price = model.Price;
        product.StockQuantity = model.StockQuantity;
        product.CategoryId = model.CategoryId;

        try
        {
            await _productRepository.UpdateAsync(product);
        }
        catch
        {
            DeleteImageFile(newImageUrl);
            return (false, "Ürün oluşturulamadı.");            
        }
        if(newImageUrl != string.Empty)
        {
            DeleteImageFile(oldImageUrl);
        }
        return (true, "Ürün başarıyla güncellendi.");
    }

    public async Task<(bool Success, string Message, List<AdminListItemProductViewModel> Products)> GetAllProductsForAdminAsync(int? categoryId = null)
    {
        var products = await _productRepository.GetAllAsync(categoryId);
        var models = products
            .Select(p => new AdminListItemProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                StockQuantity = p.StockQuantity,
                ImageUrl = p.ImageUrl,
                CategoryName = p.Category!.Name
            }).ToList();
        return (true, "Ürünler başarıyla çekildi.", models);
    }

    public async Task<(bool Success, string Message, List<ListItemProductViewModel> Products)> GetAllProductsAsync(int? categoryId = null)
    {
        var products = await _productRepository.GetAllAsync(categoryId);
        var models = products
            .Select(p => new ListItemProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                CategoryName = p.Category!.Name,
                StockQuantity = p.StockQuantity 
            }).ToList();
        return (true, "Ürünler başarıyla çekildi.", models);
    }

    public async Task<(bool Success, string Message, DetailsProductViewModel? Product)> GetProductDetailsAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            return (false, "Ürün bulunamadı.", null);
        }
        var model = new DetailsProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            ImageUrl = product.ImageUrl,
            CategoryId = product.CategoryId,
            CategoryName = product.Category!.Name
        };
        return (true, "Ürün başarıyla çekildi.", model);
    }

    public async Task<(bool Success, string Message, AdminUpdateProductViewModel? Product)> GetProductForEditAsync(int id)
    {
        var product = await _productRepository.GetByIdForEditAsync(id);
        if (product is null)
        {
            return (false, "Ürün bulunamadı.", null);
        }
        var model = new AdminUpdateProductViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            ImageUrl = product.ImageUrl,
            CategoryId = product.CategoryId
        };
        return (true, "Ürün başarıyla çekildi.", model);
    }

    public async Task<(bool Success, string Message, AdminDeleteProductViewModel? Product)> GetProductForDeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if(product is null) return (false, "Ürün bulunamadı.", null);
        return (true, "Ürün başarıyla çekildi.", new AdminDeleteProductViewModel{ Id=product.Id, Name=product.Name});
    }

    public async Task<(bool Success, string Message)> DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product is null)
        {
            return (false, "Ürün bulunamadığı için silinemedi.");
        }
        await _productRepository.RemoveAsync(product);
        return (true, "Ürün başarıyla silindi.");
    }

    private const long MaxImageSize = 5 * 1024 * 1024;

    public async Task<(bool Success, string Message, string? ImageUrl)> UploadImageAsync(IFormFile image)
    {
        if (image.Length == 0)
        {
            return (false, "Resim geçersiz.", null);
        }
        if(image.Length> MaxImageSize)
        {
            return (false, "Resim en fazla 5 mb olabilir.", null);
        }
        string[] allowedExtensions = [".png", ".jpg", ".jpeg"]; 
        var extension = Path.GetExtension(image.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(extension))
        {
            return (false, "Resim formatı geçersiz. Lütfen png, jpg ya da jpeg formatında görsel yükleyin.", null);
        }
        var directory = Path.Combine(_env.WebRootPath, "images", "products");
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        var imageName = $"{Guid.NewGuid()}{extension}";
        var imagePath = Path.Combine(directory, imageName);
        await using var stream = new FileStream(imagePath, FileMode.Create);
        await image.CopyToAsync(stream);
        var imageUrl = $"/images/products/{imageName}";
        return (true, "Resim başarıyla yüklendi.", imageUrl);
    }

    private void DeleteImageFile(string? imageUrl)
    {
        if(string.IsNullOrEmpty(imageUrl) || !imageUrl.StartsWith("/images/products/")) return;
        var path = Path.Combine(_env.WebRootPath,"images","products",Path.GetFileName(imageUrl));
        if(File.Exists(path)) File.Delete(path);
    }
}
