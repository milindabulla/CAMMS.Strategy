using System;
using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Domain;

namespace CAMMS.Strategy.Application.ObjectMapping
{
    public class QuickUpdateStrategicRiskProfile: Profile
    {
        public QuickUpdateStrategicRiskProfile()
        {
            CreateMap<Domain.QuickUpdateStrategicRisk, QuickUpdateStrategicRiskDto>();
            CreateMap<QuickUpdateStrategicRiskDto, Domain.QuickUpdateStrategicRisk>();
        }
    }
}
