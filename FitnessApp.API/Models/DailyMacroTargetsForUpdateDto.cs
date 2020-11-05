using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Models
{
    public class DailyMacroTargetsForUpdateDto
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
