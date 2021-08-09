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
            var actionList = new List<Domain.Action>();
            List<ActionDto> actionDtoList;
            if (!request.PageNumber.HasValue || request.PageNumber==0 
                || !request.PageSize.HasValue || request.PageSize == 0)
            {
                actionList = await unitOfWork.GetRepository<Domain.Action>().GetAllAsync();
                actionDtoList = mapper.Map<List<ActionDto>>(actionList);
            }
            else
            {
                actionList = await unitOfWork.GetRepository<Domain.Action>().GetAllPagedAsync(request.PageNumber.Value, request.PageSize.Value);
                actionDtoList = mapper.Map<List<ActionDto>>(actionList);
            }
            
            return await Task.FromResult(actionDtoList);
        }
    }
}
