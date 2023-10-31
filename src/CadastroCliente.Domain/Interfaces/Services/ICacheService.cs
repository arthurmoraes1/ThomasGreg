namespace CadastroCliente.Domain.Interfaces.Services
{
    public interface ICacheService
    {
        Task<T> GetAndSetObjectAsync<T>(string key, Func<Task<T>> callback);


        Task<T> GetObjectAsync<T>(string key);
    }
}
