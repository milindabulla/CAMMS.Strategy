using FluentValidation;
using System;

namespace CAMMS.Strategy.Application.Command.User
{
    class AuthenticateUserCommandValidator: AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserCommandValidator()
        {
            RuleFor(x => x.Database).NotEmpty();
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
