using si730ebu202118468.API.Inventory.Domain.Models;
using si730ebu202118468.API.Inventory.Domain.Services.Communication;

namespace si730ebu202118468.API.Inventory.Domain.Services;

public interface IProductService
{
    Task<ProductResponse> SaveAsync(Product product);

    Task<Product> ListByIdAsync(int id);
}