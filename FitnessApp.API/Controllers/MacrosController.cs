using AutoMapper;
using FitnessApp.API.Models;
using FitnessApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FitnessApp.API.Controllers
{
    [Route("api/macros")]
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

        [HttpGet("{userUid:guid}/dailymacrotargets")]
        public IActionResult GetDailyMacroTargets([FromRoute] Guid userUid)
        {
            var dailyMacroTargets = _macrosRepository.GetDailyMacroTargets(userUid);

            if(dailyMacroTargets == null)
            {
                return NotFound();
            }
            
            return Ok(_mapper.Map<DailyMacroTargetsDto>(dailyMacroTargets));
        }

        [HttpGet("{userUid:guid}/dailymeals/summed")]
        public IActionResult GetDailyIntakeSummed([FromRoute] Guid userUid)
        {
            var dailyIntakeSummed = _macrosRepository.GetDailyMealMacrosSummed(userUid);

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

        [HttpGet("{userUid:guid}/dailymeals/history")]
        public IActionResult GetDailyMealsHistory([FromRoute]Guid userUid)
        {
            var dailyMealsHistory = _macrosRepository.GetDailyMealsHistory(userUid);

            if (dailyMealsHistory == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<DailyMacrosIntakeHistoryDto>>(dailyMealsHistory));
        }

        [HttpGet("{userUid:guid}/dailymeals")]
        public IActionResult GetDailyMealMacros([FromRoute] Guid userUid)
        {
            var dailyMealsMacros = _macrosRepository.GetMealMacros(userUid);

            if (dailyMealsMacros == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<MealMacrosDto>>(dailyMealsMacros));
        }

        [HttpPost("{userUid:guid}/dailymacrotargets", Name ="GetActiveDailyMacroTargets")]
        public IActionResult CreateDailyMacroTargets([FromRoute] Guid userUid,[FromBody] DailyMacroTargetsForCreationDto dailyMacroTargets )
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
                CustomMacros = dailyMacroTargets.CustomMacros,
                 UserUid = userUid
            };

            var finalDailyMacroTargets = _mapper.Map<Entities.DailyMacroTargets>(finalDailyMacroTargetsDto);

            _macrosRepository.AddActiveDailyMacroTargets(finalDailyMacroTargets);
            _macrosRepository.Save();

            return CreatedAtRoute("GetActiveDailyMacroTargets", finalDailyMacroTargetsDto);
        }

        [HttpPost("{userUid:guid}/dailymeals", Name ="GetDailyMealMacros")]
        public IActionResult AddMealMacros([FromRoute] Guid userUid, [FromBody] MealMacrosForCreationDto mealMacrosForCreationDto)
        {
            var finalMealMacrosDto = new MealMacrosDto()
            {
                UId = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Protein = mealMacrosForCreationDto.Protein,
                Carbs = mealMacrosForCreationDto.Carbs,
                Fats = mealMacrosForCreationDto.Fats,
                MealName = mealMacrosForCreationDto.MealName,
                UserUid = userUid
            };

            var finalMealMacros = _mapper.Map<Entities.MealMacros>(finalMealMacrosDto);

            _macrosRepository.AddMealMacros(finalMealMacros);
            _macrosRepository.Save();

            return CreatedAtRoute("GetDailyMealMacros", finalMealMacrosDto);
        }

        [HttpPut("{userUid:guid}/dailymacrotargets/{dailyMacroTargetUid:guid}")]
        public IActionResult UpdateActiveDailyMacroTargets([FromRoute] Guid userUid, [FromRoute] Guid dailyMacroTargetUid, [FromBody] DailyMacroTargetsForUpdateDto dailyMacroTargetsForUpdate)
        {
            var dailyMacroTargetsEntity = _macrosRepository.GetDailyMacroTargets(userUid);

            if (dailyMacroTargetsEntity == null)
            {
                return NotFound();
            }

            var finalDailyMacroTargetsDto = new DailyMacroTargetsDto()
            {

                UId = dailyMacroTargetUid,
                CreatedOn = DateTime.Now,
                TProtein = dailyMacroTargetsForUpdate.TProtein,
                TCarbs = dailyMacroTargetsForUpdate.TCarbs,
                TFats = dailyMacroTargetsForUpdate.TFats,
                RProtein = dailyMacroTargetsForUpdate.RProtein,
                RCarbs = dailyMacroTargetsForUpdate.RCarbs,
                RFats = dailyMacroTargetsForUpdate.RFats,
                CustomMacros = dailyMacroTargetsForUpdate.CustomMacros,
                UserUid = userUid
            };

            _mapper.Map(finalDailyMacroTargetsDto, dailyMacroTargetsEntity);
            _macrosRepository.Save();

            return NoContent();
        }

        [HttpPut("{userUid:guid}/dailymeals/{dailyMealUid:guid}")]
        public IActionResult UpdateMealMacros([FromRoute] Guid userUid, [FromRoute] Guid dailyMealUid, [FromBody] MealMacrosForUpdateDto mealMacrosForUpdateDto)
        {
            var mealMacrosEntity = _macrosRepository.GetMealMacrosByUid(userUid);

            if(mealMacrosEntity == null)
            {
                return NotFound();
            }

            var finalMealMacrosDto = new MealMacrosDto()
            {
                UId = dailyMealUid,
                CreatedOn = DateTime.Now,
                Protein = mealMacrosForUpdateDto.Protein,
                Carbs = mealMacrosForUpdateDto.Carbs,
                Fats = mealMacrosForUpdateDto.Fats,
                MealName = mealMacrosForUpdateDto.MealName,
                UserUid = userUid
            };

            _mapper.Map(finalMealMacrosDto, mealMacrosEntity);
            _macrosRepository.Save();

            return NoContent();

        }

        [HttpDelete("{userUid:guid}/dailymeals/{dailyMealUid:guid}")]
        public IActionResult DeleteMealMacros([FromRoute] Guid userUid, [FromRoute] Guid dailyMealUid)
        {
            var mealMacrosEntity = _macrosRepository.GetMealMacrosByUid(dailyMealUid);

            if(mealMacrosEntity == null)
            {
                return NotFound();
            }

            _macrosRepository.DeleteMealMacros(mealMacrosEntity);
            _macrosRepository.Save();

            return NoContent();
        }
    }
}
