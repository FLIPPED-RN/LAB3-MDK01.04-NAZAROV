using LAB3_MDK01._04.NAZAROV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB3_MDK01._04.NAZAROV.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly DataContext _context;

    public ReportController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet("sellers")]
    public async Task<IActionResult> GetSellerReport()
    {
        var report = await _context.Sales
            .GroupBy(s => s.SellerName)
            .Select(g => new
            {
                Seller = g.Key,
                TotalQuantity = g.Sum(x => x.Quantity),
                TotalRevenue = g.Sum(x => x.TotalPrice)
            })
            .ToListAsync();

        return Ok(report);
    }
    
    [HttpGet("products")]
    public async Task<IActionResult> GetProductReport()
    {
        var report = await _context.Sales
            .GroupBy(s => s.ProductName)
            .Select(g => new
            {
                Product = g.Key,
                TotalQuantity = g.Sum(x => x.Quantity),
                TotalRevenue = g.Sum(x => x.TotalPrice)
            })
            .ToListAsync();

        return Ok(report);
    }
}