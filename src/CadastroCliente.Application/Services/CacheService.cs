using CadastroCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CadastroCliente.Application.Services
{
    [Authorize]
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache source)
        {
            _cache = source;
        }

        public async Task<T> GetAndSetObjectAsync<T>(string key, Func<Task<T>> callback)
        {
            var data = await _cache.GetStringAsync(key);

            if (data != null)
                return JsonConvert.DeserializeObject<T>(data);

            var result = await callback();

            if (result == null) return default;

            var cacheSettings = new DistributedCacheEntryOptions();
            cacheSettings.SetAbsoluteExpiration(TimeSpan.FromDays(1));

            await _cache.SetStringAsync(key.ToLower(), JsonConvert.SerializeObject(result), cacheSettings);

            return result;
        }

        public async Task<T> GetObjectAsync<T>(string key)
        {
            var data = await _cache.GetStringAsync(key);

            if (data != null)
                return JsonConvert.DeserializeObject<T>(data);

            return default!;
        }
    }
}
