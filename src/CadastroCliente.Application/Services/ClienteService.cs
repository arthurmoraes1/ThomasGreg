using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Interfaces.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CadastroCliente.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _httpClient;
        private readonly ICurrentUser currentUser;
        private readonly string api = "/api/cliente";

        public ClienteService(HttpClient httpClient, ICurrentUser currentUser)
        {
            _httpClient = httpClient;
            this.currentUser = currentUser;
        }

        public async Task<IEnumerable<ClienteDto>> GetClientesAsync()
        {
            try
            {

                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync(api);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ClienteDto>>(content)!;
                }

                return Enumerable.Empty<ClienteDto>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HttpResponseMessage> CreateClienteAsync(ClienteDto cliente)
        {
            try
            {
                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.PostAsJsonAsync(api, cliente);

                return response;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> UpdateClienteAsync(Guid clienteId, ClienteDto cliente)
        {
            try
            {
                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.PutAsJsonAsync($"{api}/{clienteId}", cliente);

                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeleteClienteAsync(Guid clienteId)
        {
            try
            {
                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.DeleteAsync($"{api}/{clienteId}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<ClienteDto> GetByIdAsync(Guid clienteId)
        {
            try
            {
                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync($"{api}/{clienteId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ClienteDto>(content);
                }

                return new ClienteDto();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
