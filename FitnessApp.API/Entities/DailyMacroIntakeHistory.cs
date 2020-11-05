using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Entities
{
    public class DailyMacroIntakeHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid UId { get; set; }

        public System.DateTime CreatedOn { get; set; }

        public System.DateTime? DeletedOn { get; set; }

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
