using AutoMapper;
using FitnessApp.API.Entities;
using FitnessApp.API.Models;
using FitnessApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Controllers
{
    [ApiController]
    public class MacrosController : ControllerBase
    {
        private readonly IMacrosRepository _macrosRepository;
        private readonly IMapper _mapper;

        public MacrosController(IMacrosRepository macrosRepository, IMapper mapper)
        {
            _macrosRepository = macrosRepository ?? throw new ArgumentNullException(nameof(macrosRepository));
            _mapper = mapper;
        }
        [HttpGet("api/dailymacrotargets")]
        public IActionResult GetDailyMacroTargets()
        {
            var dailyMacroTargets = _macrosRepository.GetDailyMacroTargets();

            if(dailyMacroTargets == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<DailyMacroTargetsDto>(dailyMacroTargets));
        }

        [HttpPost("api/dailymacrotargets", Name ="GetActiveDailyMacroTargets")]
        public IActionResult CreateDailyMacroTargets([FromBody] DailyMacroTargetsForCreationDto dailyMacroTargets )
        {
            var finalDailyMacroTargetsDto = new DailyMacroTargetsDto() {
               
                UId = Guid.NewGuid(),
                CreatedOn = DateTime.Now,              
                TProtein = dailyMacroTargets.TProtein,
                TCarbs = dailyMacroTargets.TCarbs,
                TFats = dailyMacroTargets.TFats,
                RProtein = dailyMacroTargets.RProtein,
                RCarbs = dailyMacroTargets.RCarbs,
                RFats = dailyMacroTargets.RFats,
                CustomMacros = dailyMacroTargets.CustomMacros

            };

            var finalDailyMacroTargets = _mapper.Map<Entities.DailyMacroTargets>(finalDailyMacroTargetsDto);

            _macrosRepository.AddActiveDailyMacroTargets(finalDailyMacroTargets);
            _macrosRepository.Save();

            return CreatedAtRoute("GetActiveDailyMacroTargets", finalDailyMacroTargetsDto);
        }

        [HttpPut("api/dailymacrotargets/{Uid}")]
        public IActionResult UpdateActiveDailyMacroTargets([FromRoute]Guid Uid, [FromBody] DailyMacroTargetsForUpdateDto dailyMacroTargetsForUpdate)
        {
            var dailyMacroTargetsEntity = _macrosRepository.GetDailyMacroTargets();
            if(dailyMacroTargetsEntity == null)
            {
                return NotFound();
            }
            var finalDailyMacroTargetsDto = new DailyMacroTargetsDto()
            {

                UId = Uid,
                CreatedOn = DateTime.Now,
                TProtein = dailyMacroTargetsForUpdate.TProtein,
                TCarbs = dailyMacroTargetsForUpdate.TCarbs,
                TFats = dailyMacroTargetsForUpdate.TFats,
                RProtein = dailyMacroTargetsForUpdate.RProtein,
                RCarbs = dailyMacroTargetsForUpdate.RCarbs,
                RFats = dailyMacroTargetsForUpdate.RFats,
                CustomMacros = dailyMacroTargetsForUpdate.CustomMacros

            };
            _mapper.Map(finalDailyMacroTargetsDto, dailyMacroTargetsEntity);
            _macrosRepository.Save();

            return NoContent();
        }
        [HttpGet("api/dailymeals")]
        public IActionResult GetDailyMealMacros()
        {
            var dailyMealsMacros = _macrosRepository.GetMealMacros();
            if(dailyMealsMacros == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<MealMacrosDto>>(dailyMealsMacros));
        }

        [HttpPost("api/dailymeals", Name ="GetDailyMealMacros")]

        public IActionResult AddMealMacros([FromBody] MealMacrosForCreationDto mealMacrosForCreationDto)
        {
            var finalMealMacrosDto = new MealMacrosDto()
            {
                UId = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Protein = mealMacrosForCreationDto.Protein,
                Carbs = mealMacrosForCreationDto.Carbs,
                Fats = mealMacrosForCreationDto.Fats,
                MealName = mealMacrosForCreationDto.MealName
            };


            var finalMealMacros = _mapper.Map<Entities.MealMacros>(finalMealMacrosDto);
            _macrosRepository.AddMealMacros(finalMealMacros);
            _macrosRepository.Save();

            return CreatedAtRoute("GetDailyMealMacros", finalMealMacrosDto);
        }

        [HttpPut("api/dailymeals/{Uid}")]
        public IActionResult UpdateMealMacros([FromRoute] Guid Uid, [FromBody] MealMacrosForUpdateDto mealMacrosForUpdateDto)
        {
            var mealMacrosEntity = _macrosRepository.GetMealMacrosByUid(Uid);
            if(mealMacrosEntity == null)
            {
                return NotFound();
            }
            var finalMealMacrosDto = new MealMacrosDto()
            {
                UId = Uid,
                CreatedOn = DateTime.Now,
                Protein = mealMacrosForUpdateDto.Protein,
                Carbs = mealMacrosForUpdateDto.Carbs,
                Fats = mealMacrosForUpdateDto.Fats,
                MealName = mealMacrosForUpdateDto.MealName
            };

            _mapper.Map(finalMealMacrosDto, mealMacrosEntity);
            _macrosRepository.Save();

            return NoContent();

        }

        [HttpDelete("api/dailymeals/{Uid}")]
        public IActionResult DeleteMealMacros([FromRoute] Guid Uid)
        {
            var mealMacrosEntity = _macrosRepository.GetMealMacrosByUid(Uid);
            if(mealMacrosEntity == null)
            {
                return NotFound();
            }
            _macrosRepository.DeleteMealMacros(mealMacrosEntity);
            _macrosRepository.Save();

            return NoContent();
        }

        [HttpGet("api/dailymeals/summed")]
        public IActionResult GetDailyIntakeSummed()
        {
            var dailyIntakeSummed = _macrosRepository.GetDailyMealMacrosSummed();
            if (dailyIntakeSummed == null)
            {
                dailyIntakeSummed = new DailyMacroIntakeDto()
                {
                    Protein = 0,
                    Carbs = 0,
                    Fats = 0
                };
            }

            return Ok(dailyIntakeSummed);
        }

        [HttpGet("api/dailymeals/history")]
        public IActionResult GetDailyMealsHistory()
        {
            var dailyMealsHistory = _macrosRepository.GetDailyMealsHistory();
            if(dailyMealsHistory == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<DailyMacrosIntakeHistoryDto>>(dailyMealsHistory));
        }

    }
}
