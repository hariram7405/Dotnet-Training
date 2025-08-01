using Assessment.Data;
using Assessment.Models;
using Microsoft.EntityFrameworkCore;
using Assessment.Utilities;

namespace Assessment.Services
{
    public class TicketService:ITicketService
    {
        public void CreateUser()
        {
            using var context = new AppDBContext();
            string name = InputHelper.ReadNonEmptyString("Enter User Name: ");
            var user = new User { UserName = name };
            context.Users.Add(user);
            context.SaveChanges();
            Console.WriteLine("User added successfully.");
        }


        public void CreateTicket()
        {
            using var context = new AppDBContext();

            string title = InputHelper.ReadNonEmptyString("Enter Ticket Title: ");
            string description = InputHelper.ReadNonEmptyString("Enter Ticket Description: ");
            int userId = InputHelper.ReadInt("Enter User ID to assign the ticket to: ");

            if (!context.Users.Any(u => u.UserId == userId))
            {
                Console.WriteLine("Invalid User ID.");
                return;
            }

            var ticket = new Ticket
            {
                Title = title,
                Description = description,
                Status = "Open",
                CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                UserId = userId
            };

            context.Tickets.Add(ticket);
            context.SaveChanges();

            Console.WriteLine("Ticket created successfully.");
        }

        public void AddTags()
        {
            using var context = new AppDBContext();

            int ticketId = InputHelper.ReadInt("Enter Ticket ID: ");
            var ticket = context.Tickets.FirstOrDefault(t => t.TicketId == ticketId);
            if (ticket == null)
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            Console.WriteLine("1. Create new Tag");
            Console.WriteLine("2. Choose from Existing Tags");
            int choice = InputHelper.ReadInt("Enter your choice: ");

            if (choice == 1)
            {
                string tagName = InputHelper.ReadNonEmptyString("Enter Tag Name: ");
                var newTag = new Tag { TagName = tagName };
                context.Tags.Add(newTag);
                context.SaveChanges();

                var ticketTag = new TicketTag { TicketId = ticketId, TagId = newTag.TagId };
                context.TicketTags.Add(ticketTag);
                context.SaveChanges();

                Console.WriteLine($"Tag '{tagName}' created and added to ticket.");
            }
            else if (choice == 2)
            {
                var tags = context.Tags.ToList();

                if (!tags.Any())
                {
                    Console.WriteLine("No tags found. Please create a tag first.");
                    return;
                }

                Console.WriteLine("Available Tags:");
                foreach (var tag in tags)
                {
                    Console.WriteLine($"{tag.TagId} - {tag.TagName}");
                }

                int tagId = InputHelper.ReadInt("Enter Tag ID to assign: ");
                if (!tags.Any(t => t.TagId == tagId))
                {
                    Console.WriteLine("Invalid Tag ID.");
                    return;
                }

                bool exists = context.TicketTags.Any(tt => tt.TicketId == ticketId && tt.TagId == tagId);
                if (exists)
                {
                    Console.WriteLine("This tag is already assigned to the ticket.");
                    return;
                }

                var ticketTag = new TicketTag { TicketId = ticketId, TagId = tagId };
                context.TicketTags.Add(ticketTag);
                context.SaveChanges();

                Console.WriteLine("Tag assigned to ticket successfully.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        public void ChangeStatus()
        {
            using var context = new AppDBContext();
            int ticketId = InputHelper.ReadInt("Enter Ticket ID: ");
            var ticket = context.Tickets.FirstOrDefault(t => t.TicketId == ticketId);

            if (ticket == null)
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            ticket.Status = "Resolved";
            context.SaveChanges();

            Console.WriteLine($"Ticket {ticket.TicketId} marked as Resolved.");
        }

        public void ViewTickets()
        {
            using var context = new AppDBContext();

            var tickets = context.Tickets
                .Select(t => new
                {
                    t.TicketId,
                    t.Title,
                    t.Description,
                    t.Status,
                    t.CreatedDate,
                    UserName = t.User.UserName,
                    Tags = t.TicketTags.Select(tt => tt.Tag.TagName).ToList()
                })
                .ToList();

            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Ticket ID: {ticket.TicketId}");
                Console.WriteLine($"Title: {ticket.Title}");
                Console.WriteLine($"Description: {ticket.Description}");
                Console.WriteLine($"Status: {ticket.Status}");
                Console.WriteLine($"Created Date: {ticket.CreatedDate:d}");
                Console.WriteLine($"Assigned User: {ticket.UserName}");
                Console.WriteLine("Tags: " + (ticket.Tags.Any() ? string.Join(", ", ticket.Tags) : "None"));
                Console.WriteLine("------------------------------------------");
            }
        }

        public void DeleteTicket()
        {
            using var context = new AppDBContext();
            int ticketId = InputHelper.ReadInt("Enter Ticket ID to delete: ");

            var ticket = context.Tickets
                .Include(t => t.TicketTags)
                .FirstOrDefault(t => t.TicketId == ticketId);

            if (ticket == null)
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            context.TicketTags.RemoveRange(ticket.TicketTags); // remove related tags
            context.Tickets.Remove(ticket);
            context.SaveChanges();

            Console.WriteLine("Ticket deleted successfully.");
        }
    }
     

}
