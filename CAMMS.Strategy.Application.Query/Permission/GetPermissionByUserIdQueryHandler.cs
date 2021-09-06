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
using Microsoft.Data.SqlClient;

namespace CAMMS.Strategy.Application.Query
{
    class GetPermissionByUserIdQueryHandler : IRequestHandler<GetPermissionByUserIdQuery, PermissionDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetPermissionByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<PermissionDto> Handle(GetPermissionByUserIdQuery request, CancellationToken cancellationToken)
        {  
            SqlParameter[] parameters = {new SqlParameter("@USERID", request.UserId)};
            var permission = await unitOfWork.GetRepository<Domain.Permission>().ExecuteReaderAsync<Domain.Permission>("[dbo].GETPERMISSIONSFORUSER", parameters);
            PermissionDto permissionDto = mapper.Map<PermissionDto>(permission);
            return await Task.FromResult(permissionDto);
        }
    }
}
