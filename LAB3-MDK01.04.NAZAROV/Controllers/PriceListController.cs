using LAB3_MDK01._04.NAZAROV.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LAB3_MDK01._04.NAZAROV.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PriceListController : ControllerBase
{
    private readonly DataContext _context;

    public PriceListController(DataContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PriceList>>> GetAll()
    {
        return await _context.PriceLists.ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<PriceList>> GetById(int id)
    {
        var product = await _context.PriceLists.FindAsync(id);
        if (product == null) return NotFound();
        return product;
    }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<PriceList>> Create(PriceList product)
    {
        _context.PriceLists.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
}