using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Models
{
    public class SupportAgent : User
    {
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
