using FitnessApp.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Entities
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Guid UId { get; set; }

        [Required]
        public System.DateTime CreatedOn { get; set; }

        public System.DateTime? DeletedOn { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public Gender Gender {get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public ExerciseFrequencyEnum Frequency { get; set; }

        [Required]
        public ExerciseTypeEnum Type { get; set; }

        [Required]
        public ExerciseGoalEnum Goal { get; set; }



    }
}
