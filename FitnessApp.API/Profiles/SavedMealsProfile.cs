using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Profiles
{
    public class SavedMealsProfile : Profile
    {
        public SavedMealsProfile()
        {
            CreateMap<Entities.SavedMeals, Models.SavedMealsDto>();
            CreateMap<Models.SavedMealsDto, Entities.SavedMeals >();
        }
    }
}
