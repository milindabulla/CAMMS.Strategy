using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Infrastructure.Identity
{
    public class UnauthorizedException :Exception
    {
        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
