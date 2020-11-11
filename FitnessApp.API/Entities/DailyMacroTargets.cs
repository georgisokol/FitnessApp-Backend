using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessApp.API.Entities
{
    public class DailyMacroTargets 
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
        public int TProtein { get; set; }

        [Required]
        public int TCarbs { get; set; }

        [Required]
        public int TFats { get; set; }

        [Required]
        public int RProtein { get; set; }

        [Required]
        public int RCarbs { get; set; }

        [Required]
        public int RFats { get; set; }

        [Required]
        public bool CustomMacros { get; set; }

        public Guid UserFk { get; set; }
    }
}
