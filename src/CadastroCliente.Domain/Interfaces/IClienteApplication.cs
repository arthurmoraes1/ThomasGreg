using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Entities;

namespace CadastroCliente.Domain.Interfaces
{
    public interface IClienteApplication
    {
        Task<IEnumerable<ClienteDto>> Get();
        Task<ClienteDto> GetById(Guid id);
        Task<ClienteDto> Create(Cliente clienteDto);
        Task Update(Guid id, Cliente clienteDto);
        Task Delete(Guid id);
        Task<bool> IsEmailUnique(string email);
    }
}
