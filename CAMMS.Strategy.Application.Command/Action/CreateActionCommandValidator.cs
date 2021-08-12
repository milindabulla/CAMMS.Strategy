using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.Command
{   
        public class CreateActionCommandValidator : AbstractValidator<CreateActionCommand>
        {
            public CreateActionCommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }   
}
