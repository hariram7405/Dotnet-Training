using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable enable
namespace BugStatistics.Core.Entities
{
    public class Bug
    {
        public required int Id { get; set; } 
        public required string Title { get; set; }


        public required  string Priority { get; set; } 
        public required string ProjectName { get; set; }
       
        public required string Status { get; set; }

        public required  string CreatedBy { get; set; }

        public required DateTime CreatedOn { get; set; }
    }
}
