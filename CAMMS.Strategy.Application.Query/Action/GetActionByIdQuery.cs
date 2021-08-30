using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CAMMS.Strategy.Application.Query
{
    public class GetActionByIdQuery :  IRequest<ActionDto>,IAuthorizedRequest
    {
        public GetActionByIdQuery()
        {

        }

        public Guid Id { get; set; }
    }
}
