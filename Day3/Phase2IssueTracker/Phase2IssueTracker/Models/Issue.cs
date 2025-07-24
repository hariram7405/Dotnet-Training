using System;
using System.Collections.Generic;

namespace Phase2IssueTracker.Models
{
    public abstract class Issue
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Assignedto { get; set; }
        public string Status { get; protected set; }

        public Issue(int id, string title, string assignedto)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException("Title cannot be empty");
            if (string.IsNullOrWhiteSpace(assignedto)) throw new ArgumentNullException("AssignedTo cannot be empty");

            Id = id;
            Title = title;
            Assignedto = assignedto;
            Status = "Open";
        }

        public abstract void Display();

        public virtual void ChangeStatus(string newStatus)
        {
            List<string> validStatus = new List<string> { "Open", "In Progress", "Closed", "Resolved" };
            if (validStatus.Contains(newStatus))
            {
                Status = newStatus;
                Console.WriteLine($"Status changed to {newStatus} successfully.");
            }
            else
            {
                Console.WriteLine("Status is invalid.");
            }
        }
    }
}
