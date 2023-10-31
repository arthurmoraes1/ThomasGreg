using CadastroCliente.Domain.Entities;
using CadastroCliente.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Infra.Data.Context
{
    public class ClienteContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Logradouros)
                .WithOne(l => l.Cliente)
                .HasForeignKey(l => l.ClienteId);

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Endereco>()
                .ToTable("Enderecos");

            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Endereco>(new EnderecoMap().Configure);
        }
    }
}

