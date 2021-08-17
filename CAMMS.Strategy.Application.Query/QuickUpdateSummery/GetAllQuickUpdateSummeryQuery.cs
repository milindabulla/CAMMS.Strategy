using CAMMS.Strategy.Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;

namespace CAMMS.Strategy.Application.Query
{
    public class GetAllQuickUpdateSummeryQuery : IRequest<List<QuickUpdateSummeryDto>>
    {
        public GetAllQuickUpdateSummeryQuery()
        {
           
        }
        public Guid UserId { get; set; }
        public string AppCode { get; set; }
      
    }
}
