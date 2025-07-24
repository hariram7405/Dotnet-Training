using Day1.Proj1phase1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Proj1phase1.Models
{
    public class Ticket
    {
        public int TicketId { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; private set; }
        public User CreatedBy { get; private set; }
        public Ticket(int ticketId, string title, string description, User createdBy)
        {
            TicketId = ticketId;
            Title = title;
            Description = description;
            Status = "Open";
            CreatedBy = createdBy;
        }
        public void CloseTicket()
        {
            Status = "Closed";
        }
        public void DisplayTicket()
        {
            Console.WriteLine($"Ticket Id:{TicketId}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Status: {Status}");

        }

    }
}

