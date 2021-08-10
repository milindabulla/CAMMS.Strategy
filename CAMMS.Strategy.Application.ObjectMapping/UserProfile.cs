using System;
using AutoMapper;
using CAMMS.Strategy.Application.DTO;
using CAMMS.Domain;
namespace CAMMS.Strategy.Application.ObjectMapping
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<Domain.User, UserDto>();
            CreateMap<UserDto, Domain.User>();
        }
    }
}
