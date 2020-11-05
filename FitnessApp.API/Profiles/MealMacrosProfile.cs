using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Profiles
{
    public class MealMacrosProfile :Profile
    {
        public MealMacrosProfile()
        {
            CreateMap<Entities.MealMacros, Models.MealMacrosDto>();
            CreateMap<Models.MealMacrosDto, Entities.MealMacros>();
        }
    }
}
