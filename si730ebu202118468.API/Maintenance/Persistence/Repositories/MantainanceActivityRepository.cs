using si730ebu202118468.API.Maintenance.Domain.Models;
using si730ebu202118468.API.Maintenance.Domain.Repositories;
using si730ebu202118468.API.Shared.Persistence.Contexts;
using si730ebu202118468.API.Shared.Persistence.Repositories;

namespace si730ebu202118468.API.Maintenance.Persistence.Repositories;

public class MantainanceActivityRepository : BaseRepository, IMaintainanceActivityRepository
{
    public MantainanceActivityRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task AddAsync(MantainanceActivity mantainanceActivity)
    {
        await _context.MantainanceActivities.AddAsync(mantainanceActivity);
    }
}