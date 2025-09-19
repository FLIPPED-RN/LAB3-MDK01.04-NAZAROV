using LAB3_MDK01._04.NAZAROV.Models;

namespace LAB3_MDK01._04.NAZAROV;

public class TestMiddleware
{
    private readonly RequestDelegate _next;

    public TestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, DataContext db)
    {
        if (context.Request.Path == "/test")
        {
            await context.Response.WriteAsync($"PriceList count: {db.PriceLists.Count()}\n");
            await context.Response.WriteAsync($"Sales count: {db.Sales.Count()}\n");
            await context.Response.WriteAsync($"Users count: {db.MyUsers.Count()}\n");
        }
        else
        {
            await _next(context);
        }
    }
}