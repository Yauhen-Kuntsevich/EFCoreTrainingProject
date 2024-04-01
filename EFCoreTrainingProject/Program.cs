using dotenv.net;
using EFCoreTrainingProject.Data;
using EFCoreTrainingProject.Models;

using SuperPizzaContext context = new SuperPizzaContext();

DotEnv.Load();

var veggiePizza = context.Products
    .Where(p => p.Name == "Veggie Special Pizza")
    .FirstOrDefault();

if (veggiePizza is Product)
{
    veggiePizza.Price = 10.99M;
}
context.SaveChanges();

var products = from product in context.Products
               where product.Price > 10.00M
               orderby product.Name
               select product;

foreach (var p in products)
{
    Console.WriteLine(p.Id);
    Console.WriteLine(p.Name);
    Console.WriteLine(p.Price);
    Console.WriteLine(new string('-', 20));
}
