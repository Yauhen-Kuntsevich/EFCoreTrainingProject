# Working with DB context

## Add entities to the database:

```C#
using EFCoreTrainingProject.Data;
using EFCoreTrainingProject.Models;

// "using" here is about external (outside .NET) resources managment
// Auto-calling of Dispose() method defined in IDisposable
using SuperPizzaContext context = new SuperPizzaContext();

Product veggieSpecial = new Product()
{
    Name = "Veggie Special Pizza",
    Price = 9.99M
};
context.Products.Add(veggieSpecial);

Product deluxeMeat = new Product()
{
    Name = "Deluxe Meat Pizza",
    Price = 12.99M
};
context.Products.Add(deluxeMeat);

context.SaveChanges();

```

## Find something in the database with API:

```C#
using EFCoreTrainingProject.Data;
using EFCoreTrainingProject.Models;

using SuperPizzaContext context = new SuperPizzaContext();

var products = context.Products.Where(p => p.Price > 10.00M).OrderBy(p => p.Name);

foreach (var p in products)
{
    Console.WriteLine(p.Id);
    Console.WriteLine(p.Name);
    Console.WriteLine(p.Price);
    Console.WriteLine(new string('-', 20));
}
```

## To find something in the database with LINQ:   

```C#
using EFCoreTrainingProject.Data;
using EFCoreTrainingProject.Models;

using SuperPizzaContext context = new SuperPizzaContext();

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
```

## To change entity in the database:

```C#
using EFCoreTrainingProject.Data;
using EFCoreTrainingProject.Models;

using SuperPizzaContext context = new SuperPizzaContext();

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

```

## To remove entity from the database:

```C#
using EFCoreTrainingProject.Data;
using EFCoreTrainingProject.Models;

using SuperPizzaContext context = new SuperPizzaContext();

var veggiePizza = context.Products
    .Where(p => p.Name == "Veggie Special Pizza")
    .FirstOrDefault();

if (veggiePizza is Product)
{
    veggiePizza.Remove();
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
```
