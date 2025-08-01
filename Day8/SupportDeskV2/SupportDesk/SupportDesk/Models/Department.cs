using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public ICollection<SupportAgent> SupportAgents { get; set; } = new List<SupportAgent>();
    }
}
