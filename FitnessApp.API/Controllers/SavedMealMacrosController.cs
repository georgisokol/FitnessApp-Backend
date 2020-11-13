using AutoMapper;
using FitnessApp.API.Models;
using FitnessApp.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FitnessApp.API.Controllers
{
    [Route("api/savedmeals")]
    [ApiController]
    public class SavedMealMacrosController : ControllerBase
    {
        private readonly IMacrosRepository _macrosRepository;
        private readonly IMapper _mapper;

        public SavedMealMacrosController(IMacrosRepository macrosRepository, IMapper mapper)
        {
            _macrosRepository = macrosRepository ?? throw new ArgumentNullException(nameof(macrosRepository));
            _mapper = mapper;
        }

       [HttpGet("{userUid:guid}")]
       public IActionResult GetSavedMeals([FromRoute] Guid userUid)
        {
            var savedMeals = _macrosRepository.GetSavedMeals(userUid);

            if(savedMeals == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<SavedMealsDto>>(savedMeals));
        }

        [HttpPost("{userUid:guid}", Name = "GetSavedMeals")]
        public IActionResult AddMealToSavedMeals([FromRoute] Guid userUid, [FromBody] SavedMealsForCreation savedMealForCreation)
        {
            var finalSavedMealDto = new SavedMealsDto()
            {
                UId = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Protein = savedMealForCreation.Protein,
                Carbs = savedMealForCreation.Carbs,
                Fats = savedMealForCreation.Fats,
                MealName = savedMealForCreation.MealName,
                UserFk = userUid
            };

            var finalSavedMeal = _mapper.Map<Entities.SavedMeals>(finalSavedMealDto);

            _macrosRepository.AddSavedMeal(finalSavedMeal);
            _macrosRepository.Save();

            return CreatedAtRoute("GetSavedmeals", finalSavedMealDto);
        }
    }
}
