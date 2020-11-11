using FitnessApp.API.Contexts;
using FitnessApp.API.Entities;
using FitnessApp.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

        public DailyMacroTargets GetDailyMacroTargets(Guid userUid)
        {
            return _context.DailyMacroTargets.Where(c => c.DeletedOn == null && c.UserFk == userUid).FirstOrDefault();
        }

        public DailyMacroIntakeDto GetDailyMealMacrosSummed(Guid userUid)
        {
            var sums = _context.MealMacros.Where(mm => mm.UserFk == userUid).GroupBy(x => true).Select(x => new DailyMacroIntakeDto()
            {
                Protein = x.Sum(y => y.Protein),
                Carbs = x.Sum(y => y.Carbs),
                Fats = x.Sum(y => y.Fats)
            });

            return sums.FirstOrDefault();
        }

        public IEnumerable<DailyMacroIntakeHistory> GetDailyMealsHistory(Guid userUid, string Month)
        {
            return _context.DailyMacroIntakeHistory.Where(h => h.UserFk == userUid && h.CreatedOn.Month.ToString("d2") == Month ).ToList();
        }

        public IEnumerable<MealMacros> GetMealMacros(Guid userUid)
        {
            return _context.MealMacros.Where(mm => mm.UserFk == userUid).OrderBy(c => c.CreatedOn).ToList();
        }

        public MealMacros GetMealMacrosByUid(Guid mealMacroUid)
        {
            return _context.MealMacros.Where(c => c.UId == mealMacroUid).FirstOrDefault();
        }

        public IEnumerable<SavedMeals> GetSavedMeals(Guid userUid)
        {
            return _context.SavedMeals.Where(m => m.UserFk == userUid).ToList();
        }

        public Users GetUserByUid(Guid userUid)
        {
            return _context.Users.Where(c => c.DeletedOn == null && c.Uid == userUid).FirstOrDefault();
        }

        public Users GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username.Equals(username));
        }

        public void RegisterUser(Users user)
        {
            _context.Users.Add(user);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
