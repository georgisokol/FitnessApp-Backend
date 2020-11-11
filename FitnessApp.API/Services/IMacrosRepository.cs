using FitnessApp.API.Entities;
using FitnessApp.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Services
{
    public interface IMacrosRepository
    {
       
        DailyMacroTargets GetDailyMacroTargets();
        IEnumerable<MealMacros> GetMealMacros();

        IEnumerable<DailyMacroIntakeHistory> GetDailyMealsHistory(string Month);

        void AddMealMacros(MealMacros mealMacros);

        void DeleteMealMacros(MealMacros mealMacros);

         void DeleteAllMealMacros();

        void AddDailyIntakeToHistory(DailyMacroIntakeHistory dailyMacroIntake);

        MealMacros GetMealMacrosByUid(Guid Uid);

        DailyMacroIntakeDto GetDailyMealMacrosSummed();

        IEnumerable<SavedMeals> GetSavedMeals();

        void AddSavedMeal(SavedMeals savedMeal);

        Users GetUsers();

        void AddActiveDailyMacroTargets(DailyMacroTargets dailyMacroTargets);

        void AddUser(Users user);

        bool Save();
    }
}
