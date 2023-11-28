using si730ebu202118468.API.Maintenance.Domain.Models;
using si730ebu202118468.API.Shared.Domain.Services.Communication;

namespace si730ebu202118468.API.Maintenance.Domain.Services.Communication;

public class MantainanceActivityResponse : BaseResponse<MantainanceActivity>
{
    public MantainanceActivityResponse(string message) : base(message)
    {
    }

    public MantainanceActivityResponse(MantainanceActivity resource) : base(resource)
    {
    }
}