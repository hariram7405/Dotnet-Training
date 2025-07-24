using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDeskPro.Models
{
    public class SupportTicket
    {

        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string createdBy { get; set; }
        public string status { get; set; }
        public SupportTicket(int id, string title, string description, string createdBy) 
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.createdBy = createdBy;
            status = "open";
        }

        public virtual void DisplayDetails()
        {
            
            Console.WriteLine($"Id :{id}| Title: {title}| Description: {description}");
            Console.WriteLine($"Created By:{createdBy}| status: {status}");
            Console.WriteLine();

        }

        public void closeTicket(int tid)
        {
            status = "closed";
            Console.WriteLine($"Ticket id {tid} has been closed");
            Console.WriteLine();

        }
    }
}
