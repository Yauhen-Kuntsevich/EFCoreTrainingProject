# DB context and migrations creating

## To add necessary packages

```Bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
# DotEnv is a package for working with (local) environment variables
dotnet add package dotenv.net
```

## To add DB context and DbSets

```C#
using dotenv.net;
using EFCoreTrainingProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTrainingProject.Data;

public class SuperPizzaContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connection string was saved in .env, .env must be added to .gitignore
        DotEnv.Load();
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION"));
    }
}

```

## To change appsettings.json

```JSON
{
  "ConnectionStrings": {
    "DefaultConnection": "${DB_CONNECTION}"
  },
  "AllowedHosts": "*"
}
```

## To add migrations and update database
You need to repeat this if you changed something in Models properties

```Bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```