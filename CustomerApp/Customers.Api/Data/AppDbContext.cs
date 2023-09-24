using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Data;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Customers.Customer> Customers { get; set; }

}