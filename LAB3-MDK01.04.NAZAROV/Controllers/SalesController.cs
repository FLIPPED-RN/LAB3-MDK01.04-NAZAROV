using LAB3_MDK01._04.NAZAROV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB3_MDK01._04.NAZAROV.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly DataContext _context;

    public SalesController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sale>>> GetAll()
    {
        return await _context.Sales.ToListAsync();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Sale>> Create(Sale sale)
    {
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = sale.Id }, sale);
    }
}