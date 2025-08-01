using Microsoft.EntityFrameworkCore;
using SupportDesk.Data;
using SupportDesk.Models;
using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        using var context = new AppDBContext();

        // Create a new user
        var alice = new User { Name = "Alice" };
        context.Users.Add(alice);
        context.SaveChanges();

        // Create a new ticket assigned to Alice
        var newTicket = new Ticket
        {
            TicketTitle = "Login Issue",
            UserId = alice.UserId
        };
        context.Tickets.Add(newTicket);
        context.SaveChanges();

        // Create tags
        var tag1 = new Tag { TagName = "bug" };
        var tag2 = new Tag { TagName = "ui" };
        context.Tags.AddRange(tag1, tag2);
        context.SaveChanges();

        // Create TicketTag mappings
        var ticketTag1 = new TicketTag { TicketId = newTicket.TicketId, TagId = tag1.TagId };
        var ticketTag2 = new TicketTag { TicketId = newTicket.TicketId, TagId = tag2.TagId };
        context.TicketTags.AddRange(ticketTag1, ticketTag2);
        context.SaveChanges();

        // Fetch all tickets with related data
        var tickets = context.Tickets
            .Include(t => t.User)
            .Include(t => t.TicketTags)
                .ThenInclude(tt => tt.Tag)
            .ToList();

        // Loop and print
        foreach (var t in tickets)
        {
            Console.WriteLine($"Ticket: {t.TicketTitle}");
            Console.WriteLine($"Raised by: {t.User?.Name}");
            Console.WriteLine("Tags:");
            foreach (var tag in t.TicketTags.Select(tt => tt.Tag))
            {
                Console.WriteLine($" - {tag.TagName}");
            }
            Console.WriteLine("----------------------------");
        }
    }
}
