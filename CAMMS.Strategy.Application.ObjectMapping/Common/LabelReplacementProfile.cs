using AutoMapper;
using CAMMS.Domain.Common;
using CAMMS.Strategy.Application.DTO;

namespace CAMMS.Strategy.Application.ObjectMapping
{
    public class LabelReplacementProfile : Profile
    {
        public LabelReplacementProfile()
        {
            CreateMap<Domain.LABELREPLACEMENT, LabelReplacementDto>();
            CreateMap<LabelReplacementDto, Domain.LABELREPLACEMENT>();
        }
    }
}
