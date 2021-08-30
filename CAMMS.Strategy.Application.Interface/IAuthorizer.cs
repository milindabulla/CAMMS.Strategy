﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.Interface
{
    public interface IAuthorizer<T> where T: class {
        Task<T> AuthorizeAsync(IAuthorizedRequest authorizedRequest);
    }
}
