using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.API.Entities
{
    public class DailyMacroIntakeHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid UId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public Guid UserFk { get; set; }

        [MaxLength(4)]
        [Required]
        public int Protein { get; set; }

        [MaxLength(4)]
        [Required]
        public int Carbs { get; set; }

        [MaxLength(4)]
        [Required]
        public int Fats { get; set; }
    }
}
