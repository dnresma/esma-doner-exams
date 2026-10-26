using System;
using EShopApp.Models.Entities;
using EShopApp.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace EShopApp.Data.Repositories;

public class OrderRepository
{
    private readonly EShopAppDbContext _context;

    public OrderRepository(EShopAppDbContext context)
    {
        _context = context;
    }
    public async Task CreateFromCartAsync(Order order, Cart cart)
    {
        await _context.Orders.AddAsync(order);
        _context.CartItems.RemoveRange(cart.CartItems);
        await _context.SaveChangesAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context
            .Orders
            .AsNoTracking()
            .Where(o=>o.Id==id)
            .Include(o=>o.AppUser)
            .Include(o=>o.OrderItems)
            .ThenInclude(oi=>oi.Product)
            .FirstOrDefaultAsync();
    }

    public async Task<Order?> GetByIdForUpdateAsync(int id)
    {
        return await _context
            .Orders
            .Where(o=>o.Id==id)
            .Include(o=>o.OrderItems)
            .ThenInclude(oi=>oi.Product)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Order>> GetByUserIdAsync(string userId, OrderStatus? orderStatus=null)
    {
        var query = _context.Orders.Where(o=>o.AppUserId==userId).AsQueryable();

        if (orderStatus.HasValue)
        {
            query = query.Where(o => o.OrderStatus == orderStatus);
        }

        return await query
            .AsNoTracking()
            .Include(o=>o.OrderItems)
            .OrderByDescending(o=>o.OrderDate)
            .ToListAsync();
    }

    public async Task<List<Order>> GetAllAsync(OrderStatus? status = null)
    {
        var query = _context
            .Orders
            .AsNoTracking()
            .AsQueryable();

        if(status.HasValue) query = query.Where(o=>o.OrderStatus==status.Value);

        return await query
            .Include(o=>o.AppUser)
            .Include(o=>o.OrderItems)
            .OrderByDescending(o=>o.OrderDate)
            .ToListAsync();
    }

    public async Task<Dictionary<OrderStatus, int>> GetStatusCountAsync()
    {
        return await _context
            .Orders
            .GroupBy(o=>o.OrderStatus)
            .Select(g=>new { Status = g.Key, Count = g.Count()})
            .ToDictionaryAsync(x=>x.Status, x=>x.Count);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
