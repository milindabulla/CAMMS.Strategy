using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CAMMS.Strategy.Application.Query
{
    public class GetPermissionByUserIdQuery :  IRequest<PermissionDto>
    {
        public GetPermissionByUserIdQuery()
        {

        }

        public Guid UserId { get; set; }
    }
}
