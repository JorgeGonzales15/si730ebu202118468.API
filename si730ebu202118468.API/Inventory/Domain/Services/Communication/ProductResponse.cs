using si730ebu202118468.API.Inventory.Domain.Models;
using si730ebu202118468.API.Shared.Domain.Services.Communication;

namespace si730ebu202118468.API.Inventory.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
    }

    public ProductResponse(Product resource) : base(resource)
    {
    }
}