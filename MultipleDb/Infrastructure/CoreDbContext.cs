using Microsoft.EntityFrameworkCore;
using MultipleDb.Domain;

namespace MultipleDb.Infrastructure
{
    public class CoreDbContext : DbContext
    {
        public DbSet<Tenant> Tenants => Set<Tenant>();

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options) { }
    }
}
