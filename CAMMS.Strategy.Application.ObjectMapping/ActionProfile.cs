using System;
using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Domain;

namespace CAMMS.Strategy.Application.ObjectMapping
{
    public class ActionProfile: Profile
    {
        public ActionProfile()
        {
            CreateMap<Domain.Action, ActionDto>();
            CreateMap<ActionDto, Domain.Action>();
        }
    }
}
