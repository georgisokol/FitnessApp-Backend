using System;

namespace FitnessApp.API.Models
{
    public class DailyMacroIntakeDto
    {
        public int Protein { get; set; }

        public int Carbs { get; set; }

        public int Fats { get; set; }

        public Guid UserFk { get; set; }

    }
}
