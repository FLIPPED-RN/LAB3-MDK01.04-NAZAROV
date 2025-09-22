namespace LAB3_MDK01._04.NAZAROV.Models;

public class PriceList
{
    public int Id { get; set; }
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    
}