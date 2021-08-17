using CAMMS.Strategy.Application.Interface;
using CAMMS.Strategy.Infrastructure.Identity;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Infrastructure.Behavior
{
    public class RequestAuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IAuthorizedRequest
    {
        private readonly IConfiguration configuration;
        private readonly RequestAuthorizer authorizer;

        public RequestAuthorizationBehavior(IConfiguration configuration, RequestAuthorizer authorizer)
        {
            this.configuration = configuration;
            this.authorizer = authorizer;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var result = await authorizer.AuthorizeAsync(request);
            if (!result.IsAuthorized)
            {
                throw new UnauthorizedException(result.FailureMessage);
            }

            return await next();
        }
    }
}
