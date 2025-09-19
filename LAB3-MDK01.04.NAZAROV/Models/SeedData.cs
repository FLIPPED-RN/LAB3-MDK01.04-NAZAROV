using Microsoft.EntityFrameworkCore;

namespace LAB3_MDK01._04.NAZAROV.Models;

public static class SeedData
{
    public static void SeedDatabase(DataContext context)
    {
        context.Database.Migrate();
        
        if (!context.PriceLists.Any() && !context.Sales.Any() && !context.MyUsers.Any())
        {
            var p1 = new PriceList { ProductCode = "A01", ProductName = "Хлеб", UnitPrice = 25 };
            var p2 = new PriceList { ProductCode = "A02", ProductName = "Молоко", UnitPrice = 60 };
            var p3 = new PriceList { ProductCode = "A03", ProductName = "Сыр", UnitPrice = 300 };
            var p4 = new PriceList { ProductCode = "A04", ProductName = "Кефир", UnitPrice = 70 };
            var p5 = new PriceList { ProductCode = "A05", ProductName = "Масло", UnitPrice = 150 };
            var p6 = new PriceList { ProductCode = "A06", ProductName = "Сахар", UnitPrice = 50 };
            var p7 = new PriceList { ProductCode = "A07", ProductName = "Яйца", UnitPrice = 80 };

            context.PriceLists.AddRange(p1, p2, p3, p4, p5, p6, p7);
            
            context.Sales.AddRange(
                new Sale { SellerName = "Иванов", ProductCode = p1.ProductCode, ProductName = p1.ProductName, Quantity = 5, TotalPrice = 5 * p1.UnitPrice },
                new Sale { SellerName = "Иванов", ProductCode = p2.ProductCode, ProductName = p2.ProductName, Quantity = 3, TotalPrice = 3 * p2.UnitPrice },
                new Sale { SellerName = "Петров", ProductCode = p3.ProductCode, ProductName = p3.ProductName, Quantity = 2, TotalPrice = 2 * p3.UnitPrice },
                new Sale { SellerName = "Сидоров", ProductCode = p4.ProductCode, ProductName = p4.ProductName, Quantity = 4, TotalPrice = 4 * p4.UnitPrice },
                new Sale { SellerName = "Кузнецов", ProductCode = p5.ProductCode, ProductName = p5.ProductName, Quantity = 1, TotalPrice = 1 * p5.UnitPrice },
                new Sale { SellerName = "Иванов", ProductCode = p6.ProductCode, ProductName = p6.ProductName, Quantity = 7, TotalPrice = 7 * p6.UnitPrice },
                new Sale { SellerName = "Петров", ProductCode = p7.ProductCode, ProductName = p7.ProductName, Quantity = 10, TotalPrice = 10 * p7.UnitPrice },
                new Sale { SellerName = "Сидоров", ProductCode = p1.ProductCode, ProductName = p1.ProductName, Quantity = 8, TotalPrice = 8 * p1.UnitPrice },
                new Sale { SellerName = "Кузнецов", ProductCode = p2.ProductCode, ProductName = p2.ProductName, Quantity = 2, TotalPrice = 2 * p2.UnitPrice },
                new Sale { SellerName = "Иванов", ProductCode = p3.ProductCode, ProductName = p3.ProductName, Quantity = 1, TotalPrice = 1 * p3.UnitPrice },
                new Sale { SellerName = "Петров", ProductCode = p4.ProductCode, ProductName = p4.ProductName, Quantity = 6, TotalPrice = 6 * p4.UnitPrice },
                new Sale { SellerName = "Сидоров", ProductCode = p5.ProductCode, ProductName = p5.ProductName, Quantity = 3, TotalPrice = 3 * p5.UnitPrice },
                new Sale { SellerName = "Кузнецов", ProductCode = p6.ProductCode, ProductName = p6.ProductName, Quantity = 9, TotalPrice = 9 * p6.UnitPrice },
                new Sale { SellerName = "Иванов", ProductCode = p7.ProductCode, ProductName = p7.ProductName, Quantity = 12, TotalPrice = 12 * p7.UnitPrice },
                new Sale { SellerName = "Петров", ProductCode = p1.ProductCode, ProductName = p1.ProductName, Quantity = 4, TotalPrice = 4 * p1.UnitPrice }
            );
            
            context.MyUsers.AddRange(
                new MyUser { Login = "admin", Password = "12345" },
                new MyUser { Login = "user", Password = "qwerty" }
            );

            context.SaveChanges();
        }
    }
}