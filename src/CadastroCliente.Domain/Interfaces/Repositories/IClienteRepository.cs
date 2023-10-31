using CadastroCliente.Domain.Entities;

namespace CadastroCliente.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente?> GetById(Guid id);
        Task<Cliente> Create(Cliente model);
        Task Update(Guid id, Cliente model);
        Task Delete(Guid id);
        Task<Cliente?> GetClienteByEmail(string email);
    }
}
