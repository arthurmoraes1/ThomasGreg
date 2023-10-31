using CadastroCliente.Domain.Dtos;

namespace CadastroCliente.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<ClienteDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ClienteDto>> GetClientesAsync();
        Task<bool> CreateClienteAsync(ClienteDto cliente);
        Task<bool> UpdateClienteAsync(Guid clienteId, ClienteDto cliente);
        Task<bool> DeleteClienteAsync(Guid clienteId);
    }
}
