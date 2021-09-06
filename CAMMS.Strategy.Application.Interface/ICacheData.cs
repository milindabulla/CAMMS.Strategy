using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.Interface
{
    public interface ICacheData
    {
        Task<List<T>> GetCacheData<T>(string key);
    }
}
