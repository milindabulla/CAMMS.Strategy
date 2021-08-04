using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Infrastructure.Behavior
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Log.Information("{RequestName} - Request - {@Request}", typeof(TRequest).Name, request);
            var response = await next();
            Log.Information("{RequestName} - Response - {@Response}", typeof(TRequest).Name, response);

            return response;
        }
    }
}
