using Microsoft.EntityFrameworkCore;
using MultipleDb.Domain;

namespace MultipleDb.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
