using AutoMapper;
using CAMMS.Domain.Common;
using CAMMS.Strategy.Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.ObjectMapping.Common
{
    public class ParameterProfile:Profile
    {
        public ParameterProfile()
        {
            CreateMap<Parameters, ParameterDto>();
            CreateMap<ParameterDto, Parameters>();
        }
    }
}
