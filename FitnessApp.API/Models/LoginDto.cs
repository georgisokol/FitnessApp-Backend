using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.API.Models
{
    public class LoginDto
    {
        public string message { get; set; }

        public Guid? userUid { get; set; }
    }
}
