using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace FinalApbd3.Server.Services
{
    public class ExtensionUserHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExtensionUserHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void YourMethodName()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
