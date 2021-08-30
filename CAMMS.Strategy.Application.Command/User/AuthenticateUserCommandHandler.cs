
using CAMMS.Strategy.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace CAMMS.Strategy.Application.Command
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly IAuthenticator authenticator;

        public AuthenticateUserCommandHandler(IAuthenticator authenticator)
        {
            this.authenticator = authenticator;
        }
        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            return await this.authenticator.AuthenticateAsync(request.Database, request.UserName, request.Password);
        }
    }
}
