namespace CadastroCliente.Domain.Dtos
{
    public record LoginDto(string User, string Token, Guid? UserId);
}
