using Microsoft.EntityFrameworkCore;
using Watchdog.Domain.Entities;

namespace Watchdog.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Customer> Customers => Set<Customer>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Cliente Teste",
                Country = "Brazil",
                RiskLevel = 0,
                KycStatus = 0,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
