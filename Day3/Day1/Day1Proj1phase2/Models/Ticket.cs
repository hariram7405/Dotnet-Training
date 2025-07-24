using System;

namespace Day1Proj1phase2.Models
{
    public class Ticket
    {
        public int TicketId { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; private set; }
        public string Priority { get; set; }
        public User AssignedTo { get; private set; }
        public DateTime CreatedOn { get; private set; }

        public Ticket(int ticketId, string title, string description, User assignedTo, string priority = "Medium")
        {
            TicketId = ticketId;
            Title = title;
            Description = description;
            Status = "Open";
            AssignedTo = assignedTo;
            Priority = priority;
            CreatedOn = DateTime.Now;
        }

        public void ReassignTicket(User newUser)
        {
            AssignedTo = newUser;
        }

        public void DisplaySummary()
        {
            Console.WriteLine($"Ticket #{TicketId}: {Title} - {Status} - {Priority} - Assigned to: {AssignedTo.Name}");
            Console.WriteLine($"Created On: {CreatedOn}");
            Console.WriteLine();
        }
    }
}
