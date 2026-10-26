using System;
using EShopApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopApp.Data.Repositories;

public class CartRepository
{
    private readonly EShopAppDbContext _context;

    public CartRepository(EShopAppDbContext context)
    {
        _context = context;
    }
    public async Task<Cart?> GetByUserIdAsync(string userId)
    {
        return await _context
            .Carts
            .Where(c=>c.AppUserId==userId)
            .Include(c=>c.CartItems)
            .ThenInclude(ci=>ci.Product)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(Cart cart)
    {
        await _context.Carts.AddAsync(cart);
        await _context.SaveChangesAsync();
    }

    public async Task RemoteItemAsync(CartItem item)
    {
        _context.CartItems.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
