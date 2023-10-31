using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Interfaces.Services;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace CadastroCliente.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly HttpClient _httpClient;
        private readonly ICurrentUser currentUser;
        private readonly string api = "/api/endereco";

        public EnderecoService(HttpClient httpClient, ICurrentUser currentUser)
        {
            _httpClient = httpClient;
            this.currentUser = currentUser;
        }

        public async Task<IEnumerable<EnderecoDto>> GetEnderecosAsync()
        {
            try
            {

                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var response = await _httpClient.GetAsync(api);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<EnderecoDto>>(content)!;
                }

                return Enumerable.Empty<EnderecoDto>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> CreateEnderecoAsync(EnderecoDto endereco)
        {
            try
            {
                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.PostAsJsonAsync(api, endereco);

                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> UpdateEnderecoAsync(Guid enderecoId, EnderecoDto endereco)
        {
            try
            {
                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.PutAsJsonAsync($"{api}/{enderecoId}", endereco);

                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> DeleteEnderecoAsync(Guid enderecoId)
        {
            try
            {
                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.DeleteAsync($"{api}/{enderecoId}");

                return response.IsSuccessStatusCode;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<EnderecoDto> GetEnderecoByIdAsync(Guid enderecoId)
        {
            try
            {
                var token = await currentUser.GetToken();
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await _httpClient.GetAsync($"{api}/{enderecoId}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<EnderecoDto>(content);
                }

                return new EnderecoDto();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
