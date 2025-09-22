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
    public PriceListController(DataContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PriceList>>> GetAll()
        => await _context.PriceLists.AsNoTracking().ToListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PriceList>> GetById(int id)
        => await _context.PriceLists.FindAsync(id) is { } e ? e : NotFound();
    
    [HttpPost]
    public async Task<ActionResult<PriceList>> Create(PriceList item)
    {
        _context.PriceLists.Add(item);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, PriceList item)
    {
        if (id != item.Id) return BadRequest("Id mismatch");
        _context.Entry(item).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var e = await _context.PriceLists.FindAsync(id);
        if (e is null) return NotFound();
        _context.PriceLists.Remove(e);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}