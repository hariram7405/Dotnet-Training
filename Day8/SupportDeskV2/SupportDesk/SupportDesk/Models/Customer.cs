using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Models
{
    public class Customer : User
    {
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public CustomerProfile? CustomerProfile { get; set; }
    }
}
