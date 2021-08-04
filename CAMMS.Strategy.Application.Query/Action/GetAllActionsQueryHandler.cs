using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using CAMMS.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using Serilog;

namespace CAMMS.Strategy.Application.Query
{
    public class GetAllActionsQueryHandler : IRequestHandler<GetAllActionsQuery, List<ActionDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllActionsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<ActionDto>> Handle(GetAllActionsQuery request, CancellationToken cancellationToken)
        {
            var actionList = await unitOfWork.GetRepository<Domain.Action>().GetAllAsync();
            List<ActionDto> actionDtoList = mapper.Map<List<ActionDto>>(actionList);
            return await Task.FromResult(actionDtoList);
        }
    }
}
