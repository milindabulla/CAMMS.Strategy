using System;
using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Domain;

namespace CAMMS.Strategy.Application.ObjectMapping
{
    public class RiskFieldSettingsProfile : Profile
    {
        public RiskFieldSettingsProfile()
        {
            CreateMap<Domain.RiskFieldSettings, RiskFieldSettingsDto>();
            CreateMap<RiskFieldSettingsDto, Domain.RiskFieldSettings>();
        }
    }
}
