using System;
using EShopApp.Data.Repositories;
using EShopApp.Models.Entities;
using EShopApp.Models.ViewModels.Carts;

namespace EShopApp.Services;

public class CartService
{
    private readonly CartRepository _cartRepository;
    private readonly ProductRepository _productRepository;

    public CartService(CartRepository cartRepository, ProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }

    private async Task<Cart> GetOrCreateCartAsync(string userId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId);
        if (cart is null)
        {
            cart = new Cart { AppUserId = userId };
            await _cartRepository.AddAsync(cart);
        }
        return cart;
    }
    public async Task<CartViewModel> GetCartAsync(string userId)
    {
        var cart = await GetOrCreateCartAsync(userId);
        return (ToViewModel(cart));
    }


    public static CartViewModel ToViewModel(Cart cart)
    {
        return new CartViewModel
        {
            Items = cart.CartItems
                .OrderBy(ci => ci.Product!.Name)
                .Select(ci => new CartItemViewModel
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product!.Name,
                    ImageUrl = ci.Product.ImageUrl,
                    UnitPrice = ci.Product.Price,
                    Quantity = ci.Quantity,
                    StockQuantity = ci.Product.StockQuantity
                }).ToList()
        };
    }
    public async Task<int> GetItemCountAsync(string userId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId);
        return cart?.CartItems.Sum(ci => ci.Quantity) ?? 0;
    }

    public async Task<(bool Success, string Message, int Count)> AddToCartAsync(string userId, int productId, int quantity)
    {
        if (quantity < 1) return (false, "Miktar, en az bir adet olmalıdır.", 0);
        var product = await _productRepository.GetByIdForEditAsync(productId);
        if (product is null) return (false, "Ürün bulunamadı", 0);
        var cart = await GetOrCreateCartAsync(userId);
        var item = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);
        int newQuantity = (item?.Quantity ?? 0) + quantity;
        if (newQuantity > product.StockQuantity)
        {
            var inCart = item?.Quantity ?? 0;
            return (false, $"Stok yetersiz. Stokta {product.StockQuantity} adet var, sepetinizde ise {inCart} adet bulunuyor.", cart.CartItems.Sum(ci => ci.Quantity));
        }
        if (item is null) // Eğer sepete eklenmek istenen ürün daha önceden yoksa
        {
            cart.CartItems.Add(new CartItem { ProductId = productId, Quantity = quantity });
        }
        else // Eğer sepete eklenmek istenen ürün daha önceden varsa
        {
            item.Quantity = newQuantity;
        }
        await _cartRepository.SaveChangesAsync();
        return (true, $"\"{product.Name}\" sepete eklendi.", cart.CartItems.Sum(ci => ci.Quantity));
    }

    public async Task<(bool Success, string Message)> UpdateQuantityAsnyc(string userId, int productId, int quantity)
    {
        var cart = await GetOrCreateCartAsync(userId);
        var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if (item is null) return (false, "Ürün sepetinizde bulunamadı.");
        if (quantity < 1) return (false, "Adet en az 1 olmalıdır.");
        if (quantity > item.Product!.StockQuantity) return (false, $"Stok yetersiz. \"{item.Product.Name}\" için stokta {item.Product.StockQuantity} adet mevcut.");
        item.Quantity = quantity;
        await _cartRepository.SaveChangesAsync();
        return (true, "Sepetiniz güncellendi.");
    }
    
    public async Task<(bool Success, string Message)> RemoveAsync(string userId, int productId)
    {
        var cart = await GetOrCreateCartAsync(userId);
        var item = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if (item is null) return (false, "Ürün sepetinizde bulunamadı.");
        await _cartRepository.RemoteItemAsync(item);
        return (true, "Ürün sepetten çıkarıldı.");
    }
}
