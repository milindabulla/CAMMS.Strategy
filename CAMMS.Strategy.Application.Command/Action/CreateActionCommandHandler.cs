using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using CAMMS.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace CAMMS.Strategy.Application.Command
{
    class CreateActionCommandHandler : IRequestHandler<CreateActionCommand, int>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateActionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<int> Handle(CreateActionCommand request, CancellationToken cancellationToken)
        {
            //var actionDto = new ActionDto();
            //actionDto.Id = request.Id;
            //actionDto.Name = request.Name;
            //actionDto.Description = request.Description;
            //actionDto.StartDate = request.StartDate;
            //actionDto.EndDate = request.EndDate;

            //Domain.Action action = mapper.Map<Domain.Action>(actionDto);
            //await unitOfWork.GetRepository<Domain.Action>().InsertAsync(action);
            //await unitOfWork.SaveAsync();

            //return action.Id;
            return 0;
        }
    }
}
