using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Models
{
    public class SavedMealsDto
    {
     

        public Guid UId { get; set; }

        public System.DateTime CreatedOn { get; set; }

        public System.DateTime? DeletedOn { get; set; }

        public int Protein { get; set; }

      
        public int Carbs { get; set; }

   
        public int Fats { get; set; }

        public string MealName { get; set; }
    }
}
