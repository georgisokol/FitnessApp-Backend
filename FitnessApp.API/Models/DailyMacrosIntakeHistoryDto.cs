using System;

namespace FitnessApp.API.Models
{
    public class DailyMacrosIntakeHistoryDto
    {
        public Guid UId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int Protein { get; set; }

        public int Carbs { get; set; }

        public int Fats { get; set; }

        public Guid UserFk { get; set; }
    }
}
