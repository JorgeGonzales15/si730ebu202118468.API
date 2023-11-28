using si730ebu202118468.API.Maintenance.Domain.Models;
using si730ebu202118468.API.Maintenance.Domain.Services.Communication;

namespace si730ebu202118468.API.Maintenance.Domain.Services;

public interface IMantainanceActivityService
{
    Task<MantainanceActivityResponse> SaveAsync(MantainanceActivity mantainanceActivity);
}