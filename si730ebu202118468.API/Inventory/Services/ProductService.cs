using si730ebu202118468.API.Inventory.Domain.Models;
using si730ebu202118468.API.Inventory.Domain.Repositories;
using si730ebu202118468.API.Inventory.Domain.Services;
using si730ebu202118468.API.Inventory.Domain.Services.Communication;
using si730ebu202118468.API.Shared.Domain.Repositories;

namespace si730ebu202118468.API.Inventory.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<ProductResponse> SaveAsync(Product product)
    {
        // Validate StatusDescription
        
        if (product.StatusDescription != "OPERATIONAL" && product.StatusDescription != "UNOPERATIONAL")
        {
            return new ProductResponse("StatusDescription must be OPERATIONAL or UNOPERATIONAL.");
        }
        
        if (product.StatusDescription.ToUpper() == "OPERATIONAL")
        {
            product.Status = 1;
        }
        else if (product.StatusDescription.ToUpper() == "UNOPERATIONAL"){
            product.Status = 2;
        }
        // Validate SerialNumber
        
        var existingSerialNumber = await _productRepository.FindBySerialNumberAsync(product.SerialNumber);
        
        if (existingSerialNumber != null)
        {
            return new ProductResponse("SerialNumber already in use.");
        }

        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            return new ProductResponse($"An error occurred while saving the product: {e.Message}");
        }
    }

    public async Task<Product> ListByIdAsync(int id)
    {
        Product product = await _productRepository.FindByIdAsync(id);

        if (product.Status == 1)
        {
            product.StatusDescription = "OPERATIONAL";
        }
        else if (product.Status == 2){
            product.StatusDescription = "UNOPERATIONAL";
        }
        return product;
    }
}