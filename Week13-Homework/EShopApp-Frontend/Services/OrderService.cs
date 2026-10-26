using System;
using System.Diagnostics;
using EShopApp.Data.Repositories;
using EShopApp.Models.Entities;
using EShopApp.Models.Enums;
using EShopApp.Models.ViewModels.Orders;

namespace EShopApp.Services;

public class OrderService
{
    private readonly OrderRepository _orderRepository;
    private readonly CartRepository _cartRepository;

    public OrderService(OrderRepository orderRepository, CartRepository cartRepository)
    {
        _orderRepository = orderRepository;
        _cartRepository = cartRepository;
    }

    #region Müşteri Tarafı
    public async Task<(bool Success, string Message, CheckoutViewModel? Checkout)> GetCheckoutAsync(string userId)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId);
        if (cart is null || cart.CartItems.Count == 0)
        {
            return (false, "Sepetiniz boş olduğu için ödeme ekranına geçilemedi.", null);
        }
        return (true, "Ödeme bilgileri çekildi.", new CheckoutViewModel { Cart = CartService.ToViewModel(cart) });
    }

    public async Task<(bool Success, string Message, int? orderId)> PlaceOrderAsync(string userId, CreateOrderViewModel model)
    {
        var cart = await _cartRepository.GetByUserIdAsync(userId);
        if (cart is null || cart.CartItems.Count == 0)
        {
            return (false, "Sepetiniz boş olduğu için sipariş oluşturulamadı.", null);
        }
        foreach (var item in cart.CartItems)
        {
            if (item.Quantity > item.Product!.StockQuantity)
            {
                return (false, $"\"{item.Product.Name}\" ürününde yeterli stok yok. (Kalan: {item.Product.StockQuantity}. Lütfen sepetinizi güncelleyin.)", null);
            }
        }
        var order = new Order
        {
            AppUserId = userId,
            OrderDate = DateTime.UtcNow,
            OrderStatus = OrderStatus.Pending,
            ShippingAddress = model.ShippingAddress,
            PhoneNumber = model.PhoneNumber,
            OrderItems = cart.CartItems.Select(ci => new OrderItem
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                UnitPrice = ci.Product!.Price
            }).ToList()
        };
        foreach (var item in cart.CartItems)
        {
            item.Product!.StockQuantity -= item.Quantity;
        }
        await _orderRepository.CreateFromCartAsync(order, cart);
        return (true, "Siparişiniz alındı. Teşekkür ederiz.", order.Id);
    }

    public async Task<List<ListItemOrderViewModel>> GetUserOrdersAsync(string userId)
    {
        var orders = await _orderRepository.GetByUserIdAsync(userId);
        return orders.Select(ToListItem).ToList();
    }

    public async Task<(bool Success, string Message, DetailsOrderViewModel? Order)> GetUserOrderDetailsAsync(string userId, int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order is null || order.AppUserId != userId) return (false, "Sipariş bulunumadı.", null);
        return (true, "Sipariş çekildi", ToDetails(order));
    }
    
    public async Task<(bool Success, string Message)> CancelUserOrderAsync(string userId, int orderId)
    {
        var order = await _orderRepository.GetByIdForUpdateAsync(orderId);
        if (order is null || order.AppUserId != userId) return (false, "Sipariş bulunumadı.");
        if (order.OrderStatus != OrderStatus.Pending) return (false, "Sadece \"Hazırlanıyor\" durumundaki siparişler iptal edilebilir!");
        await CancelAndRestoreStock(order);
        return (true, "Siparişiniz iptal edilmiştir.");
    }
    #endregion

    #region Admin Tarafı
    public async Task<AdminOrdersIndexViewModel> GetOrdersForAdminAsync(OrderStatus? status)
    {
        var orders = await _orderRepository.GetAllAsync(status);
        var model = new AdminOrdersIndexViewModel
        {
            Orders = orders.Select(ToListItem).ToList(),
            SelectedStatus = status,
            StatusCounts = await _orderRepository.GetStatusCountAsync()
        };
        return model;
    }

    public async Task<(bool Success, string Message, DetailsOrderViewModel? Order)> GetOrderDetailsForAdminAsync(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order is null) return (false, "Sipariş bulunamadı", null);
        return (true, "Sipariş çekildi", ToDetails(order));
    }

    public async Task<(bool Success, string Message)> UpdateStatusAsync(int orderId, OrderStatus newStatus)
    {
        var order = await _orderRepository.GetByIdForUpdateAsync(orderId);
        if (order is null) return (false, "Sipariş bulunamadı");
        if (!GetNextStatuses(order.OrderStatus).Contains(newStatus))
        {
            return (false, $"\"{order.OrderStatus.ToText()}\" durumundaki sipariş \"{newStatus.ToText()}\" durumuna geçirilemez.");
        }
        if (newStatus == OrderStatus.Cancelled)
        {
            await CancelAndRestoreStock(order);
        }
        else
        {
            order.OrderStatus = newStatus;
            await _orderRepository.SaveChangesAsync();
        }
        return (true, $"Sipariş durumu \"{newStatus.ToText()}\" olarak güncellendi.");
    }
    #endregion

    #region Yardımcı Metotlar
    private async Task CancelAndRestoreStock(Order order)
    {
        foreach (var item in order.OrderItems)
        {
            item.Product!.StockQuantity += item.Quantity;
        }
        order.OrderStatus = OrderStatus.Cancelled;
        await _orderRepository.SaveChangesAsync();
    }

    private static ListItemOrderViewModel ToListItem(Order order)
    {
        return new ListItemOrderViewModel
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            Status = order.OrderStatus,
            ItemCount = order.OrderItems.Sum(oi => oi.Quantity),
            Total = order.OrderItems.Sum(oi => oi.UnitPrice * oi.Quantity),
            CustomerName = order.AppUser?.FullName ?? string.Empty,
            CustomerEmail = order.AppUser?.Email ?? string.Empty
        };
    }

    private static DetailsOrderViewModel ToDetails(Order order)
    {
        return new DetailsOrderViewModel
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            Status = order.OrderStatus,
            ShippingAddress = order.ShippingAddress,
            PhoneNumber = order.PhoneNumber,
            CustomerName = order.AppUser?.FullName ?? string.Empty,
            CustomerEmail = order.AppUser?.Email ?? string.Empty,
            NextStatuses = GetNextStatuses(order.OrderStatus),
            Lines = order.OrderItems.Select(oi => new OrderLineViewModel
            {
                ProductId = oi.ProductId,
                ProductName = oi.Product!.Name,
                ImageUrl = oi.Product.ImageUrl,
                UnitPrice = oi.UnitPrice,
                Quantity = oi.Quantity
            }).ToList()
        };
    }

    private static List<OrderStatus> GetNextStatuses(OrderStatus current)
    {
        return current switch
        {
            OrderStatus.Pending => [OrderStatus.Shipped, OrderStatus.Cancelled],
            OrderStatus.Shipped => [OrderStatus.Delivered, OrderStatus.Cancelled],
            _ => []
        };
    }
    #endregion
}
