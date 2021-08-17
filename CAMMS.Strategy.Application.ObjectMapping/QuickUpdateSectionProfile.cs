using System;
using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Domain;
namespace CAMMS.Strategy.Application.ObjectMapping
{
    public class QuickUpdateSectionProfile : Profile
    {
        public QuickUpdateSectionProfile()
        {
            CreateMap<Domain.QuickUpdateSection, QuickUpdateSectionDto>();
            CreateMap<QuickUpdateSectionDto, Domain.QuickUpdateSection>();
        }
    }
}
