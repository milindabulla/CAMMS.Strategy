using CAMMS.Strategy.Application.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using CAMMS.Strategy.Application;
using System.Threading.Tasks;
using System.Text;

namespace CAMMS.Strategy.Infrastructure.Cache
{
    public class CacheData : ICacheData
    {
        private readonly IDistributedCache Cache;
        private readonly CacheSettings Settings;
        public CacheData(IDistributedCache cache, IOptions<CacheSettings> settings)
        {
            Cache = cache;
            Settings = settings.Value;
        }
        public async Task<List<T>> GetCacheData<T>(string key)
        {
            List<T> response = default(List<T>);
            if (Settings.BypassCache) return response;
            var cachedResponse = await Cache.GetAsync(key);
            if (cachedResponse != null)
            {
                response = JsonConvert.DeserializeObject<List<T>>(Encoding.Default.GetString(cachedResponse));
            }
            return response;
        }
    }
}
