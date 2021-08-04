using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using Microsoft.Extensions.Configuration;

namespace CAMMS.Strategy.Infrastructure.Behavior
{
    public class RetryBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IConfiguration configuration;

        public RetryBehaviour(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var retryAttempts = int.TryParse(configuration["RetryRequest:Attempts"], out int attempts) ? attempts : 3;
            var retryDelay = int.TryParse(configuration["RetryRequest:DelayMiliSeconds"], out int delay) ? delay : 3000;

            var retryPolicy = Policy<TResponse>.Handle<Exception>().WaitAndRetryAsync(retryAttempts, retryAttempt =>
            {
                var delay = TimeSpan.FromMilliseconds(retryDelay);
                return delay;
            },
            onRetry: (response, retryDelay) =>
            {
                Log.Information("{RequestName} - Retry Request - Delay in {RetryDelay} ms - Response: {@Response}", typeof(TRequest).Name, retryDelay, response);
            });

            var response = await retryPolicy.ExecuteAsync(async () => await next());
            return response;
        }
    }
}
