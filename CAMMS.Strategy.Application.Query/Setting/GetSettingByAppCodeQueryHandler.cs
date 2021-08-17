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

namespace CAMMS.Strategy.Application.Query.Setting
{
    public class GetSettingByAppCodeQueryHandler : IRequestHandler<GetSettingByAppCodeQuery, List<SettingDto>>
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IMapper Mapper;

        public GetSettingByAppCodeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<List<SettingDto>> Handle(GetSettingByAppCodeQuery request, CancellationToken cancellationToken)
        {
            SqlParameter[] param = {
              new SqlParameter("@ApplicationCode",request.ApplicationCode)
            };
            var settingList = await UnitOfWork.GetRepository<Domain.Common.Setting>().ExecuteReaderAsync<Domain.Common.Setting>("[dbo].GetSettingsByApplicaionCode", param);
            List<SettingDto> settingDtoList = Mapper.Map<List<SettingDto>>(settingList);
            return await Task.FromResult(settingDtoList);
        }
    }
}


