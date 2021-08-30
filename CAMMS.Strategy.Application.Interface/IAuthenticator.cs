using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.Interface
{
    public interface IAuthenticator
    {
        Task<string> AuthenticateAsync(string database, string userName, string password);
    }
}
