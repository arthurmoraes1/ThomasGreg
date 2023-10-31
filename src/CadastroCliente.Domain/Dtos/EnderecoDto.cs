namespace CadastroCliente.Domain.Dtos
{
    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public string? Logradouro { get; set; }
        public Guid ClienteId { get; set; }
        public ClienteDto Cliente { get; set; }
    }
}
