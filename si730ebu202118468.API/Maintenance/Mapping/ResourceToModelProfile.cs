using AutoMapper;
using si730ebu202118468.API.Maintenance.Domain.Models;
using si730ebu202118468.API.Maintenance.Resources;

namespace si730ebu202118468.API.Maintenance.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {

        CreateMap<SaveMantainanceActivityResource, MantainanceActivity>();
    }
}