using Microsoft.AspNetCore.Mvc;
using SingleDb.Domain;
using SingleDb.Infrastructure;

namespace SingleDb.Controllers
{
    [ApiController]
    [Route("{tenantId}/[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly TenantContext _tenantContext;

        public TenantController(
            AppDbContext dbContext,
            TenantContext tenantContext
            )
        {
            _dbContext = dbContext;
            _tenantContext = tenantContext;
        }

        [HttpGet("explicit-filter")]
        public IEnumerable<Order> GetWithExplicitFilter()
        {
            return _dbContext
                .Orders
                .Where(x => x.TenantId == _tenantContext.GetId())
                .ToList();
        }

        [HttpGet("global-filter")]
        public IEnumerable<Order> GetWithGlobalFilter()
        {
            return _dbContext
                .Orders
                .ToList();
        }
    }
}