using Day1.Proj1phase1.Models;
using Day1Proj1phase1.Models;
using System;
public class Program
{
    public static void Main(string[] args)
    {

        User user = new User(1, "Shyam", "DataEngineer");
        Ticket ticket = new Ticket(101, "Data Migration", "Migrate data from old system to new system", user);
        ticket.DisplayTicket();

        ticket.CloseTicket();
        Console.WriteLine("After closing the ticket:");
        ticket.DisplayTicket();
    }
}