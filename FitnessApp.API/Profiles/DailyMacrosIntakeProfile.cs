using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Profiles
{
    public class DailyMacrosIntakeProfile :Profile
    {
        public DailyMacrosIntakeProfile()
        {
            CreateMap<Entities.DailyMacroIntakeHistory, Models.DailyMacroIntakeDto>();
            CreateMap<Models.DailyMacroIntakeDto, Entities.DailyMacroIntakeHistory>();
           
        }
        
    }
}
