using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTOs
{
  
        public class RegisterRequest
        {
            public  required string Username { get; set; }
            public required string Password { get; set; }
        }

    
}
