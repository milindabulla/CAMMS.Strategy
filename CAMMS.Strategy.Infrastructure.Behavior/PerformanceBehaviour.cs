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

namespace CAMMS.Strategy.Infrastructure.Behavior
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch stopwatch;

        public PerformanceBehaviour()
        {
            stopwatch = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            stopwatch.Start();
            var response = await next();
            stopwatch.Stop();

            Log.Information("{RequestName} - Loading in - {Time} ms", typeof(TRequest).Name, stopwatch.ElapsedMilliseconds);

            return response;
        }
    }
}
