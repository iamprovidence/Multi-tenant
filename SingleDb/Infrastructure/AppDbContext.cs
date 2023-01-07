using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SingleDb.Domain;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace SingleDb.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly TenantContext _tenantContext;
        public DbSet<Order> Orders => Set<Order>();

        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            TenantContext tenantContext)
            : base(options)
        {
            _tenantContext = tenantContext;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<OrderItem>()
                .ToTable("OrderItems");

            /*
            modelBuilder
                .Entity<Order>()
                .HasQueryFilter(x => x.TenantId == _tenantContext.GetId());
            */

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (entityType.ClrType.IsAssignableTo(typeof(ITenantEntity)))
                {
                    AddTenantQueryFilter(entityType);
                }
            }
        }

        public void AddTenantQueryFilter(IMutableEntityType entityData)
        {
            var methodToCall = typeof(AppDbContext)
                .GetMethod(nameof(SetupTenantQueryFilter), BindingFlags.NonPublic | BindingFlags.Instance)
                .MakeGenericMethod(entityData.ClrType);

            var filter = methodToCall.Invoke(this, null);
            entityData.SetQueryFilter((LambdaExpression)filter);
        }

        private LambdaExpression SetupTenantQueryFilter<TEntity>()
            where TEntity : class, ITenantEntity
        {
            Expression<Func<TEntity, bool>> filter = x => x.TenantId == _tenantContext.GetId();
            return filter;
        }
    }
}
