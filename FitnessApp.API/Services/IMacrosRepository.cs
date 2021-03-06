﻿using FitnessApp.API.Entities;
using FitnessApp.API.Models;
using System;
using System.Collections.Generic;

namespace FitnessApp.API.Services
{
    public interface IMacrosRepository
    {
       
        DailyMacroTargets GetDailyMacroTargets(Guid userUid);

        IEnumerable<DailyMacroIntakeHistory> GetDailyMealsHistory(Guid userUid, string Month);

        List<DailyMacroIntakeDto> GetDailyMealMacrosSummedForAllUsers();


        void AddMealMacros(MealMacros mealMacros);

        void DeleteMealMacros(MealMacros mealMacros);

         void DeleteAllMealMacros();

        void AddDailyIntakeToHistory(DailyMacroIntakeHistory dailyMacroIntake);

        MealMacros GetMealMacrosByUid(Guid mealMacroUid);

        IEnumerable<MealMacros> GetDailyMealMacrosByUser(Guid userUid);

       

        DailyMacroIntakeDto GetDailyMealMacrosSummed(Guid userUid);

        IEnumerable<SavedMeals> GetSavedMeals(Guid userUid);

        void AddSavedMeal(SavedMeals savedMeal);

        Users GetUserByUid(Guid userUid);

        Users GetUserByUsername(string username);

        void AddActiveDailyMacroTargets(DailyMacroTargets dailyMacroTargets);

        void AddUser(Users user);

        void RegisterUser(Users user);

        bool Save();
    }
}
