using System;
using EShopApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopApp.Data.Repositories;

public class ProductRepository
{
    private readonly EShopAppDbContext _context;

    public ProductRepository(EShopAppDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await _context
            .Products
            .Where(p => p.Id == id)
            .AsNoTracking()
            .Include(p => p.Category)
            .FirstOrDefaultAsync();
        return product;
    }

    public async Task<Product?> GetByIdForEditAsync(int id)
    {
        var product = await _context
            .Products
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
        return product;
    }
    // GetAllAsync()
    public async Task<List<Product>> GetAllAsync(int? categoryId = null)
    {
        var query = _context.Products.AsQueryable();
        if (categoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == categoryId);
        }

        var products = await query
            .AsNoTracking()
            .Include(p => p.Category)
            .OrderBy(p => p.Name)
            .ToListAsync();
        return products;
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> SearchByName(string searchedName)
    {
        var products = await _context
            .Products
            .Where(p => p.Name.Contains(searchedName, StringComparison.InvariantCulture))
            .AsNoTracking()
            .Include(p => p.Category)
            .OrderBy(p => p.Name)
            .ToListAsync();
        return products;
    }
}
