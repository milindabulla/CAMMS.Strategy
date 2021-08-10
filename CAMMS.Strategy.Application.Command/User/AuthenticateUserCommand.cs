using MediatR;
using System;

namespace CAMMS.Strategy.Application.Command
{
    public class AuthenticateUserCommand : IRequest<string>
    {
        public string Database { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
