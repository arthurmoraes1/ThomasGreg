using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Interfaces.Repositories;
using CadastroCliente.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Infra.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ClienteContext _dbContext;

        public EnderecoRepository(ClienteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Endereco>> GetAll()
        {
            return await _dbContext.Enderecos.Include(e=>e.Cliente).ToListAsync();
        }

        public async Task<Endereco?> GetById(Guid id)
        {
            return await _dbContext.Enderecos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Endereco> Create(Endereco endereco)
        {
            try
            {
                endereco.Id = Guid.NewGuid();

                var parameters = new[]
                    {
                        new SqlParameter("@Id", endereco.Id),
                        new SqlParameter("@Logradouro", endereco.Logradouro),
                        new SqlParameter("@ClienteId", endereco.ClienteId),
                    };

                    var novoLogradouro = await _dbContext.Database.ExecuteSqlRawAsync("EXEC InserirLogradouro @Id, @Logradouro, @ClienteId", parameters);

                    return await _dbContext.Enderecos.FirstOrDefaultAsync(c => c.Id == endereco.Id);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Update(Guid id, Endereco endereco)
        {
            try
            {
                var parameters = new[]
                    {
                        new SqlParameter("@Id", id),
                        new SqlParameter("@Logradouro", endereco.Logradouro),
                        new SqlParameter("@ClienteId", endereco.ClienteId),
                    };

                await _dbContext.Database.ExecuteSqlRawAsync("EXEC AtualizarLogradouro @Id, @Logradouro, @ClienteId", parameters);
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

                await _dbContext.Database.ExecuteSqlRawAsync("EXEC RemoverLogradouro @Id", parameters);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
