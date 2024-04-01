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
        DotEnv.Load();
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION"));
    }
}
