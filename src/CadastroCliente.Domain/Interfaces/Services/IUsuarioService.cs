using CadastroCliente.Domain.Dtos;

namespace CadastroCliente.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<LoginDto> Logar(string user, string passoword);
    }
}
