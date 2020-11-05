using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Models
{
    public class UserForUpdateDto
    {
        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public ExerciseFrequencyEnum Frequency { get; set; }

        public ExerciseTypeEnum Type { get; set; }

        public ExerciseGoalEnum Goal { get; set; }
    }
}

