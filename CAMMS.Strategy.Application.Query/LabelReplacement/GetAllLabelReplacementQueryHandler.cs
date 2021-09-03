using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using MediatR;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.Query
{
    public class GetAllLabelReplacementQueryHandler : IRequestHandler<GetAllLabelReplacementQuery, List<LabelReplacementDto>>
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetAllLabelReplacementQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<List<LabelReplacementDto>> Handle(GetAllLabelReplacementQuery request, CancellationToken cancellationToken)
        {
           var LabelReplacementList = await UnitOfWork.GetRepository<Domain.LABELREPLACEMENT>().GetAllAsync();          
            List<LabelReplacementDto> LabelReplacementDtoList = Mapper.Map<List<LabelReplacementDto>>(LabelReplacementList);
            return await Task.FromResult(LabelReplacementDtoList);
        }
    }
}
