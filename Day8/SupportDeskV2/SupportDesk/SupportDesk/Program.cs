using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SupportDesk.Data;
using SupportDesk.Models;

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        context.Database.EnsureDeleted();

        context.Database.EnsureCreated();

        // Seed data if not already present
        if (!context.Departments.Any())
        {
            var cyberSecurityDept = new Department { Name = "Cyber Security" };
            var customerSupportDept = new Department { Name = "Customer Support" };

            var category = new Category { Name = "General Inquiry" };

            var customer1 = new Customer
            {
                Name = "Hari",
                Email = "hari@example.com",
                CustomerProfile = new CustomerProfile
                {
                    Address = "123 Main St",
                    Phone = "1234567890"
                }
            };

            var customer2 = new Customer
            {
                Name = "Priya",
                Email = "priya@gmail.com",
                CustomerProfile = new CustomerProfile
                {
                    Address = "456 Maple Ave",
                    Phone = "0987654321"
                }
            };

            var agent1 = new SupportAgent
            {
                Name = "Shiva",
                Email = "shiva@gmail.com",
                Department = cyberSecurityDept
            };

            var agent2 = new SupportAgent
            {
                Name = "Jnanni",
                Email = "jnanni@gmail.com",
                Department = customerSupportDept
            };

            var ticket1 = new Ticket
            {
                Title = "Password reset issue",
                Description = "Cannot reset my password",
                CreatedDate = DateTime.Now,
                Customer = customer1,
                Category = category,
                Status = "Open",
                SupportAgents = new List<SupportAgent> { agent1 }
            };

            var ticket2 = new Ticket
            {
                Title = "Login error",
                Description = "Getting error when logging in",
                CreatedDate = DateTime.Now,
                Customer = customer2,
                Category = category,
                Status = "Open",
                SupportAgents = new List<SupportAgent> { agent2 }
            };

            // Add Ticket History
            var history1 = new TicketHistory
            {
                TimeStamp = DateTime.Now,
                ActionTaken = "Ticket created",
                Ticket = ticket1
            };

            var history2 = new TicketHistory
            {
                TimeStamp = DateTime.Now.AddMinutes(30),
                ActionTaken = "Assigned to Shiva",
                Ticket = ticket1
            };

            context.Departments.AddRange(cyberSecurityDept, customerSupportDept);
            context.Categories.Add(category);
            context.Customers.AddRange(customer1, customer2);
            context.SupportAgents.AddRange(agent1, agent2);
            context.Tickets.AddRange(ticket1, ticket2);
            context.TicketHistories.AddRange(history1, history2);

            context.SaveChanges();
        }

        // Display Main Tables
        Console.WriteLine("\nDepartments:");
        foreach (var dept in context.Departments.Include(d => d.SupportAgents))
        {
            Console.WriteLine($"- {dept.Name}");
        }

        Console.WriteLine("\nCustomers:");
        foreach (var customer in context.Customers.Include(c => c.CustomerProfile))
        {
            Console.WriteLine($"- {customer.Name}, Email: {customer.Email}, Phone: {customer.CustomerProfile?.Phone}");
        }

        Console.WriteLine("\nSupport Agents:");
        foreach (var agent in context.SupportAgents.Include(a => a.Department))
        {
            Console.WriteLine($"- {agent.Name}, Department: {agent.Department?.Name}");
        }

        Console.WriteLine("\nTickets:");
        foreach (var ticket in context.Tickets
            .Include(t => t.Customer)
            .Include(t => t.SupportAgents)
            .Include(t => t.Category))
        {
            var agentNames = string.Join(", ", ticket.SupportAgents.Select(a => a.Name));
            Console.WriteLine($"- {ticket.Title} (Customer: {ticket.Customer.Name}, Agents: {agentNames}, Category: {ticket.Category.Name})");
        }

        
        Console.WriteLine("\nDetailed Tickets:");
        var detailedTickets = context.Tickets
            .Include(t => t.Customer)
            .Include(t => t.SupportAgents)
            .Include(t => t.Category)
            .Include(t => t.TicketHistories)
            .ToList();

        foreach (var ticket in detailedTickets)
        {
            var agentNames = string.Join(", ", ticket.SupportAgents.Select(a => a.Name));
            Console.WriteLine($"\nTicket ID: {ticket.Id}");
            Console.WriteLine($"Title: {ticket.Title}");
            Console.WriteLine($"Description: {ticket.Description}");
            Console.WriteLine($"Created Date: {ticket.CreatedDate}");
            Console.WriteLine($"Status: {ticket.Status}");
            Console.WriteLine($"Customer: {ticket.Customer.Name} ({ticket.Customer.Email})");
            Console.WriteLine($"Category: {ticket.Category.Name}");
            Console.WriteLine($"Support Agents: {agentNames}");

            if (ticket.TicketHistories.Any())
            {
                Console.WriteLine("Ticket History:");
                foreach (var history in ticket.TicketHistories.OrderBy(h => h.TimeStamp))
                {
                    Console.WriteLine($"  - [{history.TimeStamp}] {history.ActionTaken}");
                }
            }
            else
            {
                Console.WriteLine("Ticket History: (No actions recorded yet)");
            }
        }
    }
}
