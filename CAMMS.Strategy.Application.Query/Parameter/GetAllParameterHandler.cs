using AutoMapper;
using CAMMS.Strategy.Application.DTO.Common;
using CAMMS.Strategy.Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.Query.Parameter
{
    public class GetAllParameterHandler : IRequestHandler<GetAllParameterQuery, List<ParameterDto>>
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetAllParameterHandler(IUnitOfWork UnitOfWork, IMapper Mapper)
        {
            this.UnitOfWork = UnitOfWork;
            this.Mapper = Mapper;
        }

        public async Task<List<ParameterDto>> Handle(GetAllParameterQuery request, CancellationToken cancellationToken)
        {
            var parameterList = await UnitOfWork.GetRepository<Domain.Common.Parameters>().GetAllAsync();
            List<ParameterDto> parameterDtoList = Mapper.Map<List<ParameterDto>>(parameterList);
            return await Task.FromResult(parameterDtoList);
        }

    }
}
