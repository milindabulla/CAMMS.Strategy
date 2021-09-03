using CAMMS.Strategy.Application.DTO;
using CAMMS.Strategy.Application.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMMS.Strategy.Application.Query
{
    public class GetAllLabelReplacementQuery : IRequest<List<LabelReplacementDto>>, ICacheableQuery//,IAuthorizedRequest
    {
        public GetAllLabelReplacementQuery()
        {
        }
        public string CacheKey => $"GetAllLabelReplacementQuery";
    }
}
