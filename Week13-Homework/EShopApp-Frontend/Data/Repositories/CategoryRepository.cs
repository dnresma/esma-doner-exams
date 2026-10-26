using System;
using EShopApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopApp.Data.Repositories;

public class CategoryRepository
{
    private readonly EShopAppDbContext _context;

    public CategoryRepository(EShopAppDbContext context)
    {
        _context = context;
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        var category = await _context
            .Categories
            .FindAsync(id);
        return category;
    }

    public async Task<Category?> GetByIdWithProductsAsync(int id)
    {
        var category = await _context
            .Categories
            .Where(c => c.Id == id)
            .AsNoTracking()
            .Include(c => c.Products)
            .FirstOrDefaultAsync();
        return category;
    }

    public async Task<List<Category>> GetAllAsync()
    {
        var categories = await _context
            .Categories
            .AsNoTracking()
            .Include(c => c.Products)
            .OrderBy(c => c.Name)
            .ToListAsync();
        return categories;
    }

    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ExistsCategoryName(string name)
    {
        var existsCategoryName = await _context
            .Categories
            .AnyAsync(c => c.Name.ToLowerInvariant() == name.ToLowerInvariant());
        return existsCategoryName;
    }
}
