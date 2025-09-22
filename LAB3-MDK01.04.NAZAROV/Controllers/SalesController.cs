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
    public SalesController(DataContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Sale>>> GetAll()
        => await _context.Sales.AsNoTracking().ToListAsync();
    
    [HttpPost]
    public async Task<ActionResult<Sale>> Create(Sale sale)
    {
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = sale.Id }, sale);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Sale sale)
    {
        if (id != sale.Id) return BadRequest("Id mismatch");
        _context.Entry(sale).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var e = await _context.Sales.FindAsync(id);
        if (e is null) return NotFound();
        _context.Sales.Remove(e);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}