using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultipleDb.Domain;
using MultipleDb.Infrastructure;
using System.Collections.Generic;
using System.Linq;

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
                .Include(x => x.Items)
                .ToList();
        }
    }
}