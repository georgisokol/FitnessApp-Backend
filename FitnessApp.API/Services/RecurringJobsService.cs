using AutoMapper;
using FitnessApp.API.Models;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Services
{
    public class RecurringJobsService : IRecurringJobsService
    {
        private readonly IMacrosRepository _macrosRepository;
        private readonly IMapper _mapper;

        public RecurringJobsService(IMacrosRepository macrosRepository, IMapper mapper)
        {
            _macrosRepository = macrosRepository ?? throw new ArgumentNullException(nameof(macrosRepository));
            _mapper = mapper;
        }


        public void StartRecurringBackroundJobs()
        {
            ClearTheDailyIntakeMacrosAndMoveItToHistory();

        }



        public void ClearTheDailyIntakeMacrosAndMoveItToHistory()
        {
            var dailySummedMacros = _macrosRepository.GetDailyMealMacrosSummed();

            var dailyMacrosIntakeForHistoryDto = new DailyMacrosIntakeHistoryDto()
            {
                UId = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Protein = dailySummedMacros.Protein,
                Carbs = dailySummedMacros.Carbs,
                Fats = dailySummedMacros.Fats
            };

            var finalDailyMacrosIntakeForHistory = _mapper.Map<Entities.DailyMacroIntakeHistory>(dailyMacrosIntakeForHistoryDto);

            _macrosRepository.AddDailyIntakeToHistory(finalDailyMacrosIntakeForHistory);
            _macrosRepository.DeleteAllMealMacros();
            _macrosRepository.Save();

        }



    }
}
