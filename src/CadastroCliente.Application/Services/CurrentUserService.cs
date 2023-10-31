using CadastroCliente.Domain;
using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CadastroCliente.Application.Services
{
    public class CurrentUserService : ICurrentUser
    {
        private readonly ClaimsPrincipal claimsPrincipal;
        private readonly ICacheService cacheService;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            ICacheService cacheService)
        {
            this.cacheService = cacheService;

            var httpContext = httpContextAccessor.HttpContext;
            if (httpContext != null && httpContext.User != null)
            {
                claimsPrincipal = httpContext.User;
            }
        }


        public Guid? GetUserId()
        {
            string userId = string.Empty;

            if(claimsPrincipal != null)
                userId = SearchClaim("user_id")?.Value;

            if (!string.IsNullOrWhiteSpace(userId))
            {
                return Guid.Parse(userId);
            }
            return null;
        }

        public string GetUserLogin()
        {
            var login = SearchClaim(ClaimTypes.Name);

            return login?.Value;

        }


        private Claim SearchClaim(string type)
        {
            var result = claimsPrincipal.Claims.Where(x => x.Type == type).FirstOrDefault();
            return result;
        }


        public async Task<string> GetToken()
        {
            var userLogin = GetUserLogin();

            var cacheKey = string.Format(Constants.CacheKeys.UserDataKey, userLogin.ToLower());

            var loginDto = await cacheService.GetObjectAsync<LoginDto>(cacheKey);

            if (loginDto != null)
                return loginDto.Token;

            return string.Empty;
        }
    }
}
