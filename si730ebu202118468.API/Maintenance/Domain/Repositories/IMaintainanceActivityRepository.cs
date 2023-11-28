using si730ebu202118468.API.Maintenance.Domain.Models;

namespace si730ebu202118468.API.Maintenance.Domain.Repositories;

public interface IMaintainanceActivityRepository
{
    Task AddAsync(MantainanceActivity mantainanceActivity);
}