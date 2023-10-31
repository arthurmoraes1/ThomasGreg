namespace CadastroCliente.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string Logradouro { get; set; }

        public Guid ClienteId { get; private set; }
        public virtual Cliente Cliente { get; set; }
    }
}
