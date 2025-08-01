using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string ActionTaken { get; set; } = "";

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}
