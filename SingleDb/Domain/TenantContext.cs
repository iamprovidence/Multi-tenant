using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace SingleDb.Domain
{
    public class TenantContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetId()
        {
            return int.Parse(_httpContextAccessor.HttpContext.GetRouteValue("tenantId").ToString());
        }

    }
}
