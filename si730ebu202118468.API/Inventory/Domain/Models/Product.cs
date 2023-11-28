namespace si730ebu202118468.API.Inventory.Domain.Models;

public class Product
{
    public int Id { get; set; } 
    public string Brand { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public int Status { get; set; }
    public string StatusDescription { get; set; }
}