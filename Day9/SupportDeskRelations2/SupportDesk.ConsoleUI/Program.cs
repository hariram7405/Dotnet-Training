using Microsoft.EntityFrameworkCore;
using SupportDesk.Core.Entities;
using SupportDesk.Infrastructure.Data;
using System;
using System.Linq;
using SupportDesk.Application.Services;

class Program
{
    public static void Main(string[] args)
    {
        using var context = new AppDBContext();
        var service = new TicketService(context);

        // Clear previous data
        context.TicketTags.RemoveRange(context.TicketTags);
        context.Tickets.RemoveRange(context.Tickets);
        context.Tags.RemoveRange(context.Tags);
        context.Users.RemoveRange(context.Users);
        context.SaveChanges();

        // Seed data
        var ram = new User { Name = "Ram" };
        var shiva = new User { Name = "Shiva" };
        var Janani = new User { Name = "Janani" };
        context.Users.AddRange(ram, shiva,Janani);
        context.SaveChanges();

        var ticket1 = new Ticket { TicketTitle = "Login Issue", UserId = shiva.UserId };
        var ticket2 = new Ticket { TicketTitle = "UI Issue", UserId = ram.UserId };
        var ticket3 = new Ticket { TicketTitle = "VPN Issue", UserId = Janani.UserId };
        context.Tickets.AddRange(ticket1, ticket2,ticket3);
        context.SaveChanges();

        var tag1 = new Tag { TagName = "bug" };
        var tag2 = new Tag { TagName = "ui" };
        var tag3 = new Tag { TagName = "security" };
        context.Tags.AddRange(tag1, tag2,tag3);
        context.SaveChanges();

        var ticketTag1 = new TicketTag { TicketId = ticket1.TicketId, TagId = tag1.TagId };
        var ticketTag2 = new TicketTag { TicketId = ticket1.TicketId, TagId = tag2.TagId };
         var ticketTag3 = new TicketTag { TicketId = ticket3.TicketId, TagId = tag3.TagId };


        context.TicketTags.AddRange(ticketTag1, ticketTag2,ticketTag3);
        context.SaveChanges();



        int ramId = ram.UserId;
        int bugTagId = tag1.TagId;


     
        Console.WriteLine("\nGetAllTickets:");
        foreach (var t in service.GetAllTickets())
            Console.WriteLine($"- {t.TicketTitle}");

        Console.WriteLine("\nGetAllTicketsWithUsers:");
        foreach (var t in service.GetAllTicketsWithUsers())
            Console.WriteLine($"- {t.TicketTitle} by {t.User?.Name}");

        Console.WriteLine("\nGetAllTicketsWithTags:");
        foreach (var t in service.GetAllTicketsWithTags())
            Console.WriteLine($"- {t.TicketTitle} with tags: {string.Join(", ", t.TicketTags.Select(tt => tt.Tag.TagName))}");

        Console.WriteLine("\nGetUsersWithTickets:");
        foreach (var t in service.GetUsersWithTickets())
            Console.WriteLine($"- {t.User?.Name} raised ticket: {t.TicketTitle}");

        Console.WriteLine("\nGetTagTicketCounts:");
        foreach (var tag in service.GetTagTicketCounts())
            Console.WriteLine($"- {tag.TagName}: {tag.TicketCount}");

        Console.WriteLine("\nGetTagTicketCountByUser:");
        foreach (var user in service.GetTagTicketCountByUser())
            Console.WriteLine($"- {user.UserName}: {user.TicketCount}");
        Console.WriteLine($"\nGetTicketsByUserId ({ramId}):");
        foreach (var t in service.GetTicketsByUserId(ramId))  
            Console.WriteLine($"- {t.TicketTitle}");

        Console.WriteLine($"\nGetTicketsByTagId ({bugTagId}):");
        foreach (var t in service.GetTicketsByTagId(bugTagId))  
            Console.WriteLine($"- {t.TicketTitle}");


        Console.WriteLine("\nGetTicketsWithUserandTagNames:");
        foreach (dynamic t in service.GetTicketsWithUserandTagNames())
        {
            Console.WriteLine($"- {{ TicketId = {t.TicketId}, Title = {t.Title}, UserName = {t.UserName}, Tags = [{string.Join(", ", t.Tags)}] }}");
        }



        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
