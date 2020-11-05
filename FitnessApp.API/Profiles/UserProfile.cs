using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Profiles
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<Entities.Users, Models.UserDto>();
            CreateMap<Models.UserDto, Entities.Users>();
        }
    }
}
