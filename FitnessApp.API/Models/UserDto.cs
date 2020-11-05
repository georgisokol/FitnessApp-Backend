using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Models
{
    public class UserDto
    {
        public System.DateTime CreatedOn { get; set; }

        public System.DateTime? DeletedOn { get; set; }
        public Guid UId { get; set; }


        public int Age { get; set; }
        
        public Gender Gender { get; set; }
    
        public int Height { get; set; }
 
        public int Weight { get; set; }

        public ExerciseFrequencyEnum Frequency { get; set; }

        public ExerciseTypeEnum Type { get; set; }

        public ExerciseGoalEnum Goal { get; set; }
    }
}
