using CadastroCliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroCliente.Infra.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Logradouro)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Logradouro")
                .HasColumnType("varchar(255)");

            builder.HasOne(prop => prop.Cliente)
                        .WithMany(c => c.Logradouros)
                        .HasForeignKey(prop => prop.ClienteId);
        }
    }
}
