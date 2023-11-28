using si730ebu202118468.API.Inventory.Domain.Repositories;
using si730ebu202118468.API.Maintenance.Domain.Models;
using si730ebu202118468.API.Maintenance.Domain.Repositories;
using si730ebu202118468.API.Maintenance.Domain.Services;
using si730ebu202118468.API.Maintenance.Domain.Services.Communication;
using si730ebu202118468.API.Shared.Domain.Repositories;

namespace si730ebu202118468.API.Maintenance.Services;

public class MantainanceActivityService : IMantainanceActivityService
{
    private readonly IMaintainanceActivityRepository _mantainanceActivityRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public MantainanceActivityService(IMaintainanceActivityRepository mantainanceActivityRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _mantainanceActivityRepository = mantainanceActivityRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<MantainanceActivityResponse> SaveAsync(MantainanceActivity mantainanceActivity)
    {

        var existingSerialNumber =  await _productRepository.FindBySerialNumberAsync(mantainanceActivity.ProductSerialNumber);
        if (existingSerialNumber == null)
            return new MantainanceActivityResponse("Invalid product serial number.");
        
        // Validate that activityResult has values between 0 and 1
        if (mantainanceActivity.ActivityResult is > 1 or < 0)
            return new MantainanceActivityResponse("Activity result must be between 0 and 1.");
        
        if (mantainanceActivity.ActivityResult == 0)
        {
            existingSerialNumber.Status = 2;
        }
        else if (mantainanceActivity.ActivityResult == 1)
        {
            existingSerialNumber.Status = 1;
        }

        try
        {
            await _mantainanceActivityRepository.AddAsync(mantainanceActivity);
            await _unitOfWork.CompleteAsync();

            return new MantainanceActivityResponse(mantainanceActivity);
        }
        catch (Exception e)
        {
            return new MantainanceActivityResponse($"An error occurred while saving the mantainance activity: {e.Message}");
        }
    }
}