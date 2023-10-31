using CadastroCliente.Domain.Entities;

namespace CadastroCliente.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> GetAll();
        Task<Endereco?> GetById(Guid id);
        Task<Endereco> Create(Endereco model);
        Task Update(Guid id, Endereco model);
        Task Delete(Guid id);
    }
}
