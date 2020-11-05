﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Models
{
    public class DailyMacroTargetsDto
    {
        public System.DateTime CreatedOn { get; set; }

        public System.DateTime? DeletedOn { get; set; }
        public Guid UId { get; set; }
        public int TProtein { get; set; }

        public int TCarbs { get; set; }

        public int TFats { get; set; }

        public int RProtein { get; set; }

        public int RCarbs { get; set; }

        public int RFats { get; set; }

        public bool CustomMacros { get; set; }
    }
}