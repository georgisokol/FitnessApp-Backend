using FitnessApp.API.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.API.Entities
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public Guid Uid { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Salt { get; set; }

        public int Age { get; set; }

        public Gender Gender {get; set; }

        public int Height { get; set; }

        public int Weight { get; set; }

        public ExerciseFrequencyEnum Frequency { get; set; }

        public ExerciseTypeEnum Type { get; set; }

        public ExerciseGoalEnum Goal { get; set; }
    }
}
