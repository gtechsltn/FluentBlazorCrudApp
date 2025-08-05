using FluentBlazorCrudApp.Models;

using Microsoft.EntityFrameworkCore;

namespace FluentBlazorCrudApp.Data;

public class ProductRepository
{
    private readonly AppDbContext _db;
    public ProductRepository(AppDbContext db) => _db = db;

    public async Task<(List<Product> Items, int TotalCount)> GetPagedAsync(int skip, int take, string? sortColumn, bool asc)
    {
        IQueryable<Product> query = _db.Products;

        if (!string.IsNullOrEmpty(sortColumn))
        {
            query = sortColumn switch
            {
                "Name" => asc ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name),
                "Price" => asc ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Id)
            };
        }

        int total = await query.CountAsync();
        var items = await query.Skip(skip).Take(take).ToListAsync();
        return (items, total);
    }

    public async Task<Product> AddAsync(Product p)
    {
        _db.Products.Add(p);
        await _db.SaveChangesAsync();
        return p;
    }

    public async Task UpdateAsync(Product p)
    {
        _db.Products.Update(p);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product p)
    {
        _db.Products.Remove(p);
        await _db.SaveChangesAsync();
    }
}
