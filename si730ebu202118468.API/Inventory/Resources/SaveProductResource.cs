using System.ComponentModel.DataAnnotations;

namespace si730ebu202118468.API.Inventory.Resources;

public class SaveProductResource
{
    [Required]
    public string Brand { get; set; }
    
    [Required]
    public string Model { get; set; }
    
    [Required]
    public string SerialNumber { get; set; }
    
    [Required]
    public string StatusDescription { get; set; }
}