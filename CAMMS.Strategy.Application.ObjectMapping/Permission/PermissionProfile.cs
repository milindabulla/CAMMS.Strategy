using System;
using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Domain;

namespace CAMMS.Strategy.Application.ObjectMapping
{
    public class PermissionProfile: Profile
    {
        public PermissionProfile()
        {
            CreateMap<Domain.Permission, PermissionDto>();
            CreateMap<PermissionDto, Domain.Permission>();
        }
    }
}
