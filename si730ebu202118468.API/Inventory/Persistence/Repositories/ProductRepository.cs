using Microsoft.EntityFrameworkCore;
using si730ebu202118468.API.Inventory.Domain.Models;
using si730ebu202118468.API.Inventory.Domain.Repositories;
using si730ebu202118468.API.Shared.Persistence.Contexts;
using si730ebu202118468.API.Shared.Persistence.Repositories;

namespace si730ebu202118468.API.Inventory.Persistence.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindBySerialNumberAsync(string serialNumber)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.SerialNumber == serialNumber);
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
}