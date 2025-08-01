using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Entities;
using SupportDesk.Infrastructure.Data;
using System;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        using var context = new AppDBContext();


        // Create and save users
        var ram = new User { Name = "Ram" };
        var shiva = new User { Name = "Shiva" };
        context.Users.AddRange(ram, shiva);
        context.SaveChanges();

        // Create and save tickets
        var ticket1 = new Ticket
        {
            TicketTitle = "Login Issue",
            UserId = shiva.UserId
        };

        var ticket2 = new Ticket
        {
            TicketTitle = "UI Issue",
            UserId = ram.UserId
        };

        context.Tickets.AddRange(ticket1, ticket2);
        context.SaveChanges();

        // Create and save tags
        var tag1 = new Tag { TagName = "bug" };
        var tag2 = new Tag { TagName = "ui" };
        context.Tags.AddRange(tag1, tag2);
        context.SaveChanges();

        // Assign tags to ticket1
        var ticketTag1 = new TicketTag { TicketId = ticket1.TicketId, TagId = tag1.TagId };
        var ticketTag2 = new TicketTag { TicketId = ticket1.TicketId, TagId = tag2.TagId };
        context.TicketTags.AddRange(ticketTag1, ticketTag2);
        context.SaveChanges();

        // Fetch and print tickets with user and tags
        var tickets = context.Tickets
            .Include(t => t.User)
            .Include(t => t.TicketTags)
                .ThenInclude(tt => tt.Tag)
            .ToList();

        foreach (var t in tickets)
        {
            Console.WriteLine($"Ticket: \"{t.TicketTitle}\"");
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
