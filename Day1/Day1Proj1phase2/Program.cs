using System;
using Day1Proj1phase2.Models;

namespace Day1Proj1phase2
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            
            User user1 = new User(1, "Praveen", "Analyst");
            User user2 = new User(2, "Rahul", "Developer");

            
            Ticket ticket1 = new Ticket(101, "Data Migration", "Migrate data from old system", user1, "High");
            Ticket ticket2 = new Ticket(102, "UI Update", "Update UI for dashboard", user2, "Medium");
            Ticket ticket3 = new Ticket(103, "Testing", "Perform unit testing", user1, "Low");

            ticket3.ReassignTicket(user2);

           
            Console.WriteLine("Ticket Summaries:\n");
            ticket1.DisplaySummary();
            ticket2.DisplaySummary();
            ticket3.DisplaySummary();
        }
    }
}
