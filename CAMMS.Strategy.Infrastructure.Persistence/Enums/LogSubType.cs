using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Infrastructure.Persistence.Enums
{
    public enum LogSubType
    {
        None = 0,
        Create = 1,
        Update = 2,
        CreateOrUpdate = 3,
        Delete = 4
    }
}
