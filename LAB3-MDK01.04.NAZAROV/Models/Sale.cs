using System.Text.Json.Serialization;

namespace LAB3_MDK01._04.NAZAROV.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Sale
{
    public int Id { get; set; }
    public string SellerName { get; set; } = string.Empty;
    public string ProductCode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    
    public int PriceListId { get; set; }
    
}