using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Profiles
{
    public class DailyMacrosIntakeHistoryProfile :Profile
    {
        public DailyMacrosIntakeHistoryProfile()
        {
            CreateMap<Entities.DailyMacroIntakeHistory, Models.DailyMacrosIntakeHistoryDto>();
            CreateMap<Models.DailyMacrosIntakeHistoryDto, Entities.DailyMacroIntakeHistory>();
        }
        

    }
}
