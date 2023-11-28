using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using si730ebu202118468.API.Inventory.Domain.Models;
using si730ebu202118468.API.Inventory.Domain.Services;
using si730ebu202118468.API.Inventory.Resources;
using si730ebu202118468.API.Shared.Extensions;

namespace si730ebu202118468.API.Inventory.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;
    
    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var product = _mapper.Map<SaveProductResource, Product>(resource);
        var result = await _productService.SaveAsync(product);
        if (!result.Success)
            return BadRequest(result.Message);

        var productResource = _mapper.Map<Product, ProductResource>(result.Resource);
        return Ok(productResource);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync (int id)
    {
        var result = await _productService.ListByIdAsync(id);
        var resource = _mapper.Map<Product, ProductResource>(result);
        return Ok(resource);
    }
}