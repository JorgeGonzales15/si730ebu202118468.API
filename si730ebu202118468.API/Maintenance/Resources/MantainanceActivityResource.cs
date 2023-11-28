namespace si730ebu202118468.API.Maintenance.Resources;

public class MantainanceActivityResource
{
    public int Id { get; set; }
    public string ProductSerialNumber { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public int ActivityResult { get; set; }
}