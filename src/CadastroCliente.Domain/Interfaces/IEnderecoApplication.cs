using CadastroCliente.Domain.Dtos;
using CadastroCliente.Domain.Entities;

namespace CadastroCliente.Domain.Interfaces
{
    public interface IEnderecoApplication
    {
        Task<IEnumerable<EnderecoDto>> Get();
        Task<EnderecoDto> GetById(Guid id);
        Task<EnderecoDto> Create(Endereco clienteDto);
        Task Update(Guid id, Endereco clienteDto);
        Task Delete(Guid id);
    }
}
