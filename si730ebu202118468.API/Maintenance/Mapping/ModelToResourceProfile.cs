using AutoMapper;
using si730ebu202118468.API.Maintenance.Domain.Models;
using si730ebu202118468.API.Maintenance.Resources;

namespace si730ebu202118468.API.Maintenance.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {

        CreateMap<MantainanceActivity, MantainanceActivityResource>();
    }
}