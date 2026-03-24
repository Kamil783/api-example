using Api_example.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_example.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Customer> Customers => Set<Customer>();
}
