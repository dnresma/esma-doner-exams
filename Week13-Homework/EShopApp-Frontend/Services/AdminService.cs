using System;
using EShopApp.Data.Repositories;
using EShopApp.Models.Enums;
using EShopApp.Models.ViewModels.Admin;

namespace EShopApp.Services;

public class AdminService
{
    private readonly ProductRepository _productRepository;
    private readonly OrderRepository _orderRepository;

    public AdminService(ProductRepository productRepository, OrderRepository orderRepository)
    {
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public async Task<AdminIndexViewModel> GetDashboardAsync()
    {
        var products = await _productRepository.GetAllAsync();
        var orders = await _orderRepository.GetAllAsync(null);

        return new AdminIndexViewModel
        {
            TotalProducts = products.Count,
            TotalOrders = orders.Count,
            TotalSales = orders
                .Where(o => o.OrderStatus != OrderStatus.Cancelled)
                .Sum(o => o.OrderItems.Sum(oi => oi.UnitPrice * oi.Quantity)),
        };
    }
}
