using Assessment.Services;
using Assessment.Data;
using Assessment.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static TicketService ticketService = new TicketService();

    public static void Main(string[] args)
    {
        while (true)
        {
            Menu();
            int choice = ReadInt("Enter your choice: ");

            switch (choice)
            {
                case 1:
                    ticketService.CreateUser();
                    break;
                case 2:
                    ticketService.CreateTicket();
                    break;
                case 3:
                    ticketService.AddTags();
                    break;
                case 4:
                    ticketService.ChangeStatus();
                    break;
                case 5:
                    ticketService.ViewTickets();
                    break;
                case 6:
                    ticketService.DeleteTicket();
                    break;
                case 7:
                    Console.WriteLine("Exiting application...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    public static void Menu()
    {
        Console.WriteLine("===== Bug Tracker Menu =====");
        Console.WriteLine("1. Create User");
        Console.WriteLine("2. Create Ticket");
        Console.WriteLine("3. Add Tags to Ticket");
        Console.WriteLine("4. Mark Ticket as Resolved");
        Console.WriteLine("5. View All Tickets (with User and Tags)");
        Console.WriteLine("6. Delete Ticket");
        Console.WriteLine("7. Exit");
    }

    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;

            Console.WriteLine("Invalid input! Please enter a number.");
        }
    }
}
