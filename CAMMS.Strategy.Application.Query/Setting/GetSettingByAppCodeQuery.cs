using CAMMS.Strategy.Application.DTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.Query.Setting
{
    public class GetSettingByAppCodeQuery: IRequest<List<SettingDto>>
    {
        public GetSettingByAppCodeQuery()
        {
        }

        public string ApplicationCode { get; set; }
    }
}
