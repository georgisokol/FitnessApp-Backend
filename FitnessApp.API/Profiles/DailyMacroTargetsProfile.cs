using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Profiles
{
    public class DailyMacroTargetsProfile :Profile
    {
        public DailyMacroTargetsProfile()
        {
            CreateMap<Entities.DailyMacroTargets, Models.DailyMacroTargetsDto>();
            CreateMap<Models.DailyMacroTargetsDto, Entities.DailyMacroTargets>();
        }
    }
}
