using CadastroCliente.Domain.Dtos;

namespace CadastroCliente.Domain.Interfaces.Services
{
    public interface IEnderecoService
    {
        Task<EnderecoDto> GetEnderecoByIdAsync(Guid id);
        Task<IEnumerable<EnderecoDto>> GetEnderecosAsync();
        Task<bool> CreateEnderecoAsync(EnderecoDto endereco);
        Task<bool> UpdateEnderecoAsync(Guid enderecoId, EnderecoDto endereco);
        Task<bool> DeleteEnderecoAsync(Guid enderecoId);
    }
}
