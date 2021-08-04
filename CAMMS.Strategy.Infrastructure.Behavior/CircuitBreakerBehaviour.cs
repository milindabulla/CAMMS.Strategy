using MediatR;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using Microsoft.Extensions.Configuration;
using Polly.CircuitBreaker;

namespace CAMMS.Strategy.Infrastructure.Behavior
{
    public class CircuitBreakerBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IConfiguration configuration;
        private static AsyncCircuitBreakerPolicy<TResponse> AsyncCircuitBreakerPolicy;

        public CircuitBreakerBehaviour(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var noOfExceptions = int.TryParse(configuration["CircuitBreaker:NoOfExceptions"], out int noOfTimes) ? noOfTimes : 3;
            var breakDuration = int.TryParse(configuration["CircuitBreaker:CircuitBreakDuration"], out int duration) ? duration : 3000;
            string requestName = typeof(TRequest).Name;
            var circuitBreaker = GetInstance(requestName, noOfExceptions, breakDuration);
            var response = await circuitBreaker.ExecuteAsync(async () => await next());
            return response;
        }

        public static AsyncCircuitBreakerPolicy<TResponse> GetInstance(string requestName, int noOfExceptions, int breakDuration)
        {
            if (AsyncCircuitBreakerPolicy == null)
            {
                AsyncCircuitBreakerPolicy = Policy<TResponse>.Handle<Exception>()
                    .CircuitBreakerAsync(noOfExceptions,
                    TimeSpan.FromMilliseconds(breakDuration),
                    (exception, timeDuration) => {
                        Log.Information("{RequestName} - Circuit Breaker - {@CircuitState} - {@Response}", requestName, AsyncCircuitBreakerPolicy.CircuitState, exception);
                    },
                    () => {
                        Log.Information("{RequestName} - Circuit Breaker - {@CircuitState}", requestName, AsyncCircuitBreakerPolicy.CircuitState);
                    });
            }

            return AsyncCircuitBreakerPolicy;
        }
    }
}
