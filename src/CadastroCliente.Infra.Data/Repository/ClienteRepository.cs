using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Interfaces.Repositories;
using CadastroCliente.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _dbContext;

        public ClienteRepository(ClienteContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _dbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetById(Guid id)
        {
            return await _dbContext.Clientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            try
            {
                cliente.Id = Guid.NewGuid();

                var parameters = new[]
                    {
                        new SqlParameter("@Id", cliente.Id),
                        new SqlParameter("@Nome", cliente.Nome),
                        new SqlParameter("@Email", cliente.Email),
                        new SqlParameter("@Logotipo", cliente.Logotipo)
                    };

                var novoCliente = await _dbContext.Database.ExecuteSqlRawAsync("EXEC InserirCliente @Id, @Nome, @Email, @Logotipo", parameters);

                return await _dbContext.Clientes.FirstOrDefaultAsync(c=>c.Id == cliente.Id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(Guid id, Cliente cliente)
        {
            try
            {
                var parameters = new[]
                    {
                        new SqlParameter("@Id", id),
                        new SqlParameter("@Nome", cliente.Nome),
                        new SqlParameter("@Email", cliente.Email),
                        new SqlParameter("@Logotipo", cliente.Logotipo)
                    };

                await _dbContext.Database.ExecuteSqlRawAsync("EXEC AtualizarCliente @Id, @Nome, @Email, @Logotipo", parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task Delete(Guid id)
        {

            try
            {

                var parameters = new[]
                    {
                        new SqlParameter("@Id", id)
                    };

                await _dbContext.Database.ExecuteSqlRawAsync("EXEC RemoverCliente @Id", parameters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Cliente?> GetClienteByEmail(string email)
        {
            return await _dbContext.Set<Cliente>()
                .Where(c => c.Email == email)
                .FirstOrDefaultAsync();
        }

        private async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
