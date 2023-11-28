using System.ComponentModel.DataAnnotations;

namespace si730ebu202118468.API.Maintenance.Resources;

public class SaveMantainanceActivityResource
{
    [Required]
    public string ProductSerialNumber { get; set; }
    
    [Required]
    public string Summary { get; set; }
    
    public string Description { get; set; }
    
    [Required]
    public int ActivityResult { get; set; }
}