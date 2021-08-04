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
    public class ExceptionHandleBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception exception)
            {
                Log.Information("{RequestName} - Unhandled Exception - {@Response}", typeof(TRequest).Name, exception);
            }

            return default(TResponse);
        }
    }
}
