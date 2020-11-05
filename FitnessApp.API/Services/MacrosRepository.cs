using FitnessApp.API.Contexts;
using FitnessApp.API.Entities;
using FitnessApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Services
{
    public class MacrosRepository : IMacrosRepository
    {
        private readonly MacrosContext _context;

        public  MacrosRepository(MacrosContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddActiveDailyMacroTargets(DailyMacroTargets dailyMacroTargets)
        {
            _context.DailyMacroTargets.Add(dailyMacroTargets);
        }

        public void AddDailyIntakeToHistory(DailyMacroIntakeHistory dailyMacroIntake)
        {
            _context.DailyMacroIntakeHistory.Add(dailyMacroIntake);
        }

        public void AddMealMacros(MealMacros mealMacros)
        {
            _context.MealMacros.Add(mealMacros);
        }

        public void AddSavedMeal(SavedMeals savedMeal)
        {
            _context.SavedMeals.Add(savedMeal);
        }

        public void AddUser(Users user)
        {
            _context.Users.Add(user);
        }

        public  void DeleteAllMealMacros()
        {
            _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [MealMacros]");
        }

        public void DeleteMealMacros(MealMacros mealMacros)
        {
            _context.MealMacros.Remove(mealMacros);
        }

        public DailyMacroTargets GetDailyMacroTargets()
        {
            return _context.DailyMacroTargets.Where(c => c.DeletedOn == null).FirstOrDefault();
        }

        public DailyMacroIntakeDto GetDailyMealMacrosSummed()
        {

            var sums = _context.MealMacros.GroupBy(x => true).Select(x => new DailyMacroIntakeDto()
            {
                Protein = x.Sum(y => y.Protein),
                Carbs = x.Sum(y => y.Carbs),
                Fats = x.Sum(y => y.Fats)


            });
            return sums.FirstOrDefault();
        }

        public IEnumerable<DailyMacroIntakeHistory> GetDailyMealsHistory()
        {
            return _context.DailyMacroIntakeHistory.OrderBy(c => c.CreatedOn).ToList();
        }

        public IEnumerable<MealMacros> GetMealMacros()
        {
            return _context.MealMacros.OrderBy(c => c.CreatedOn).ToList();
        }

        public MealMacros GetMealMacrosByUid(Guid Uid)
        {
            return _context.MealMacros.Where(c => c.UId == Uid).FirstOrDefault();
        }

        public IEnumerable<SavedMeals> GetSavedMeals()
        {
            return _context.SavedMeals.ToList();
        }

        public Users GetUsers()
        {
            return _context.Users.Where(c => c.DeletedOn == null).FirstOrDefault();
        }

      

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
