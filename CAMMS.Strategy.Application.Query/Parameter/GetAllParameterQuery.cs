using CAMMS.Strategy.Application.DTO.Common;
using CAMMS.Strategy.Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.Query.Parameter
{
    public class GetAllParameterQuery : IRequest<List<ParameterDto>>

    {
        
    }
}
