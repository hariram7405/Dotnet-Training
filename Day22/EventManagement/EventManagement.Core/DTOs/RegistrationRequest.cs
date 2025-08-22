using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.Core.DTOs
{
   public  class RegistrationRequest
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
    }
}
