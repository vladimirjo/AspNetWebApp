using Microsoft.EntityFrameworkCore;

namespace AspNetWebApp.Models;

public class SeedData
{
    public static void SeedDatabase(DataContext context)
    {
        if (context.Products.Count() == 0 && context.Suppliers.Count() == 0
            && context.Categories.Count() == 0)
        {
            Supplier s1 = new Supplier
            { Name = "Apotek1", City = "Lørenskog" };
            Supplier s2 = new Supplier
            { Name = "Norsk Medisinaldepot AS", City = "Oslo" };
            Supplier s3 = new Supplier
            { Name = "Alliance Healthcare", City = "Langhus" };
            Category c1 = new Category { Name = "Smertestillende" };
            Category c2 = new Category { Name = "Kosttilskudd" };
            Category c3 = new Category { Name = "Hudpleie" };
            context.Products.AddRange(
            new Product
            {
                Name = "Paracet 500mg tabletter 20stk",
                Price = 29.90m,
                Category = c1,
                Supplier = s1
            },
            new Product
            {
                Name = "Ibux 200mg kapsler 20stk",
                Price = 49,
                Category = c1,
                Supplier = s1
            },
            new Product
            {
                Name = "Nycoplus Høykonsentrert omega-3 500mg kapsler 120stk",
                Price = 214.90m,
                Category = c2,
                Supplier = s2
            },
            new Product
            {
                Name = "Nycoplus Multi tabletter 200stk",
                Price = 134,
                Category = c2,
                Supplier = s2
            },
            new Product
            {
                Name = "Gevita Sink & vitamin C tabletter 120stk",
                Price = 97.50m,
                Category = c2,
                Supplier = s2
            },
            new Product
            {
                Name = "A-Derma Exomega Control lotion 400ml",
                Price = 299,
                Category = c3,
                Supplier = s3
            },
            new Product
            {
                Name = "La Roche-Posay Lipikar Balm Light AP+M 400ml",
                Price = 389,
                Category = c3,
                Supplier = s3
            },
            new Product
            {
                Name = "Bepanthen salve 30g",
                Price = 64,
                Category = c3,
                Supplier = s3
            },
            new Product
            {
                Name = "Canoderm 5% krem 100g",
                Price = 79,
                Category = c3,
                Supplier = s3
            }
            );
            context.SaveChanges();
        }
    }
}