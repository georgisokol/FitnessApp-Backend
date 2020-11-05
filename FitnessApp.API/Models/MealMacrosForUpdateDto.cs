using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Models
{
    public class MealMacrosForUpdateDto
    {
        public int Protein { get; set; }


        public int Carbs { get; set; }


        public int Fats { get; set; }


        public string MealName { get; set; }
    }
}
