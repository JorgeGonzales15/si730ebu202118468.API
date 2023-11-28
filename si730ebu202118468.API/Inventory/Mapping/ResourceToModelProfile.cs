using AutoMapper;
using si730ebu202118468.API.Inventory.Domain.Models;
using si730ebu202118468.API.Inventory.Resources;

namespace si730ebu202118468.API.Inventory.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProductResource, Product>();

    }
}