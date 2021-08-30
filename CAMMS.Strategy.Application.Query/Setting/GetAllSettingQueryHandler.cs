using AutoMapper;
using CAMMS.Strategy.Application.DTO.Common;
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
    public class GetAllSettingQueryHandler : IRequestHandler<GetAllSettingQuery, List<SettingDto>>
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetAllSettingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<List<SettingDto>> Handle(GetAllSettingQuery request, CancellationToken cancellationToken)
        {
            var settingList = await UnitOfWork.GetRepository<Domain.Common.Setting>().ExecuteReaderAsync<Domain.Common.Setting>("[dbo].[GetAllSettings]");
            List<SettingDto> settingDtoList = Mapper.Map<List<SettingDto>>(settingList);
            return await Task.FromResult(settingDtoList);
        }
    }
}
