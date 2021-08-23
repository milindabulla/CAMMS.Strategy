using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;

namespace CAMMS.Strategy.Application.Query
{
    public class GetAllQuickUpdateSummeryQuery : IRequest<List<QuickUpdateSummeryDto>>, ICacheableQuery
    {
        public GetAllQuickUpdateSummeryQuery()
        {
           
        }
        public Guid? UserId { get; set; }
        public string AppCode { get; set; }

        public string CacheKey => $"GetAllQuickUpdateSummeryQuery";
    }
}
