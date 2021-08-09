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
    class GetActionByIdQueryHandler : IRequestHandler<GetActionByIdQuery, ActionDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetActionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<ActionDto> Handle(GetActionByIdQuery request, CancellationToken cancellationToken)
        {
            var action = await unitOfWork.GetRepository<Domain.Action>().GetByGuidAsync(request.Id);
            ActionDto actionDto = mapper.Map<ActionDto>(action);
            return await Task.FromResult(actionDto);
        }
    }
}
