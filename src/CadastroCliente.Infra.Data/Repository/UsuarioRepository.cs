using CadastroCliente.Domain.Models;

namespace CadastroCliente.Infra.Data.Repository
{
    public static class UsuarioRepository
    {
        public static Usuario Get(string login, string password)
        {
            var usuarios = new List<Usuario>();
            usuarios.Add(new Usuario { Id = Guid.NewGuid(), Login = "Administrador", Password = "password", Role = "Admin" });

            return usuarios.FirstOrDefault(c=> c.Login == login && c.Password == password);
        }
    }
}
