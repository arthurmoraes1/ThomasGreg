namespace CadastroCliente.Domain.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
