using CadastroCliente.Domain;
using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Interfaces.Services;
using Newtonsoft.Json;
using System.Text;

namespace CadastroCliente.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly HttpClient _httpClient;
        private readonly string api = "/api/login";
        private readonly ICacheService _serviceCache;

        public UsuarioService(HttpClient httpClient, ICacheService serviceCache)
        {
            _httpClient = httpClient;
            _serviceCache = serviceCache;
        }

        public async Task<LoginDto?> Logar(string user, string password)
        {
            try
            {
                var cacheKey = string.Format(Constants.CacheKeys.UserDataKey, user.ToLower());
                var credentials = new { Login = user, Password = password, Role = "Administrador" };
                var json = JsonConvert.SerializeObject(credentials);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(api, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await _serviceCache.GetAndSetObjectAsync(cacheKey, async () => {

                        var result = await response.Content.ReadAsStringAsync();
                        
                        return JsonConvert.DeserializeObject<LoginDto>(result); 
                    });

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
