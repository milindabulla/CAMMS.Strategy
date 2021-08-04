using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using CAMMS.Strategy.Application.Interface;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using CAMMS.Strategy.Application;

namespace CAMMS.Strategy.Infrastructure.Behavior
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheableQuery
    {
        private readonly IDistributedCache Cache;
        private readonly CacheSettings Settings;
        public CachingBehavior(IDistributedCache cache, IOptions<CacheSettings> settings)
        {
            Cache = cache;
            Settings = settings.Value;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response;
            var cachedResponse = await Cache.GetAsync((string)request.CacheKey, cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
            }
            else
            {
                response = await next();
                var slidingExpiration = TimeSpan.FromMinutes(Settings.SlidingExpirationInMin);
                var absoluteExpiration = TimeSpan.FromMinutes(Settings.AbsoluteExpirationInMin);
                var options = new DistributedCacheEntryOptions { SlidingExpiration = slidingExpiration, AbsoluteExpirationRelativeToNow = absoluteExpiration };
                var serializedData = Encoding.Default.GetBytes(JsonConvert.SerializeObject(response));
                await Cache.SetAsync((string)request.CacheKey, serializedData, options, cancellationToken);
            }

            return response;
        }
    }
}
