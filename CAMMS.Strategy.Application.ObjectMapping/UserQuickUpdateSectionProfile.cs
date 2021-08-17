using System;
using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Domain;
namespace CAMMS.Strategy.Application.ObjectMapping
{
    public class UserQuickUpdateSectionProfile : Profile
    {
        public UserQuickUpdateSectionProfile()
        {
            CreateMap<Domain.UserQuickUpdateSection, UserQuickUpdateSectionDto>();
            CreateMap<UserQuickUpdateSectionDto, Domain.UserQuickUpdateSection>();
        }
    }
}
