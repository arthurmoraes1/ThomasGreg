namespace CadastroCliente.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Logotipo { get; set; }

        public IEnumerable<Endereco> Logradouros { get; set; }
    }
}
