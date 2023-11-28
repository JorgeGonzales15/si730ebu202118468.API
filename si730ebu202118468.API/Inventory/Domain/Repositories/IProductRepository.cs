using si730ebu202118468.API.Inventory.Domain.Models;

namespace si730ebu202118468.API.Inventory.Domain.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product> FindBySerialNumberAsync(string serialNumber);
    
    Task<Product> FindByIdAsync(int id);
}