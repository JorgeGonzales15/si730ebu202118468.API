using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using si730ebu202118468.API.Maintenance.Domain.Models;
using si730ebu202118468.API.Maintenance.Domain.Services;
using si730ebu202118468.API.Maintenance.Resources;
using si730ebu202118468.API.Shared.Extensions;

namespace si730ebu202118468.API.Maintenance.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class MantainanceActivitiesController : ControllerBase
{
    private readonly IMantainanceActivityService _mantainanceActivityService;
    private readonly IMapper _mapper;
    
    public MantainanceActivitiesController(IMantainanceActivityService mantainanceActivityService, IMapper mapper)
    {
        _mantainanceActivityService = mantainanceActivityService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveMantainanceActivityResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var mantainanceActivity = _mapper.Map<SaveMantainanceActivityResource, MantainanceActivity>(resource);
        var result = await _mantainanceActivityService.SaveAsync(mantainanceActivity);
        if (!result.Success)
            return BadRequest(result.Message);

        var mantainanceActivityResource = _mapper.Map<MantainanceActivity, MantainanceActivityResource>(result.Resource);
        return Ok(mantainanceActivityResource);
    }
}