using CAMMS.Strategy.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;

namespace CAMMS.Strategy.Application.Query
{
    public class GetAllActionsQuery : IRequest<List<ActionDto>>
    {
        public GetAllActionsQuery()
        {
            PageSize = 0;
            PageNumber = 0;
        }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}
