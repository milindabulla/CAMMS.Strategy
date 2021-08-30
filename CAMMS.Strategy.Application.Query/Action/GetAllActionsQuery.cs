using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CAMMS.Strategy.Application.Query
{
    public class GetAllActionsQuery : IRequest<List<ActionDto>> ,IAuthorizedRequest
    {
        public GetAllActionsQuery()
        {
            PageSize = 0;
            PageNumber = 0;
        }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        //[FromHeader(Name = "Authorization")]
        //public string Token { get; set; }
        public string CacheKey => $"GetAllActionsQuery";
    }
}
