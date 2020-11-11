using System.ComponentModel.DataAnnotations;

namespace FitnessApp.API.Models
{
    public class DailyMacroTargetsForCreationDto
    {
        
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
    }
}
