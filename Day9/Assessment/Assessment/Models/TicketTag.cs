using Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Models
{
   public class TicketTag
    {
        public int TicketId { get; set; }
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; } = null!;
        public virtual Ticket Ticket { get; set; } = null!;
    }
}

