using Microsoft.AspNetCore.Mvc;
using MultipleDb.Domain;
using MultipleDb.Infrastructure;

namespace MultipleDb.Controllers
{
    [ApiController]
    [Route("{tenantId}/[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public TenantController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Order> GetWithExplicitFilter()
        {
            return _dbContext
                .Orders
                .ToList();
        }
    }
}