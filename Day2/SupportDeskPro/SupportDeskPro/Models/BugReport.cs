using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDeskPro.Models
{    public class BugReport :SupportTicket,IReportable
    {
        string severity;
        public BugReport(int id, string title, string description, string createdBy,string severity)
        : base(id,title, description, createdBy)
        {
            this.severity=severity;
        }
        public override void DisplayDetails()
        {

            Console.WriteLine($"Id :{id}| Title: {title}| Description: {description}");
            Console.WriteLine($"Created By:{createdBy}| status: {status}");
            Console.WriteLine();
            

        }
        public void ReportStatus()
        {
            Console.WriteLine("========BUG REPORT==========");
            Console.WriteLine("---------------------------------------------------------------");

            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Title: {title} ");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Created By: {createdBy}");
            Console.WriteLine($"Severity:{severity}");
            Console.WriteLine(); Console.WriteLine();
        }
    }
}
