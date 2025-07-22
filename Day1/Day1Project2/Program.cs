using System;
using SupportPortal.Models;

namespace SupportPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create agents
            var agent1 = new SupportAgent(1, "Anu", "IT");
            var agent2 = new SupportAgent(2, "Babu", "Networking");

            // Display agents
            Console.WriteLine("Support Agents:");
            agent1.DisplayAgent();
            agent2.DisplayAgent();

            // Create requests
            var request1 = new SupportRequest(101, "Cannot access Firewall", "Open", DateTime.Now, 4.5, agent1);
            var request2 = new SupportRequest(102, "outlook and email not syncing", "Open", DateTime.Now, 3, agent2);

            // Display initial summaries
            Console.WriteLine("\nInitial Support Requests:");
            request1.DisplaySummary();
            request2.DisplaySummary();

            // Test MarkResolved
            request1.MarkResolved();
            request2.MarkResolved();


            request1.Reassign(agent2);
            request2.Reassign(agent1);


            Console.WriteLine("\nUpdated Support Requests:");
            request1.DisplaySummary();
            request2.DisplaySummary();
        }
    }
}
