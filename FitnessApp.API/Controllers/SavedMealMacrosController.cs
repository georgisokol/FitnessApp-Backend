using AutoMapper;
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
    public class SavedMealMacrosController : ControllerBase
    {
        private readonly IMacrosRepository _macrosRepository;
        private readonly IMapper _mapper;

        public SavedMealMacrosController(IMacrosRepository macrosRepository, IMapper mapper)
        {
            _macrosRepository = macrosRepository ?? throw new ArgumentNullException(nameof(macrosRepository));
            _mapper = mapper;
        }
       [HttpGet("api/savedmeals")]
       public IActionResult GetSavedMeals()
        {
            var savedMeals = _macrosRepository.GetSavedMeals();
            if(savedMeals == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<SavedMealsDto>>(savedMeals));
        }

        [HttpPost("api/savedmeals", Name = "GetSavedMeals")]
        public IActionResult AddMealToSavedMeals([FromBody] SavedMealsForCreation savedMealForCreation)
        {
            var finalSavedMealDto = new SavedMealsDto()
            {
                UId = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Protein = savedMealForCreation.Protein,
                Carbs = savedMealForCreation.Carbs,
                Fats = savedMealForCreation.Fats,
                MealName = savedMealForCreation.MealName
                
            };

            var finalSavedMeal = _mapper.Map<Entities.SavedMeals>(finalSavedMealDto);
            _macrosRepository.AddSavedMeal(finalSavedMeal);
            _macrosRepository.Save();

            return CreatedAtRoute("GetSavedmeals", finalSavedMealDto);

        }


    }
}
