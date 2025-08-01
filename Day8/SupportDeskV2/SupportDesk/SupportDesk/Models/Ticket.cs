using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDesk.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = "Open";

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<SupportAgent> SupportAgents { get; set; } = new List<SupportAgent>();
        public ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
    }
}
