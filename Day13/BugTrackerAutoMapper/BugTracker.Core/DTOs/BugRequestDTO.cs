using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.DTOs
{
   public class BugRequestDTO
    {
      
        public required string Title { get; set; }
        public required string Description { get; set; } 
      
     
        public int ProjectId { get; set; }   
        public DateTime? DueDate { get; set; }     
    }
}
