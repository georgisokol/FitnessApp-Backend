using FitnessApp.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Contexts
{
    public class MacrosContext :DbContext
    {
        public DbSet<DailyMacroTargets> DailyMacroTargets { get; set; }
        public DbSet<MealMacros> MealMacros { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<SavedMeals> SavedMeals { get; set; }

        public DbSet<DailyMacroIntakeHistory> DailyMacroIntakeHistory { get; set; }

       public  MacrosContext(DbContextOptions<MacrosContext> options) :base(options)
        {
            //Database.EnsureCreated();
        }

    }
}
