using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportDeskPro.Models
{
    public class FeatureRequest:SupportTicket,IReportable
    {
        string RequestedBy;
       public FeatureRequest(int id, string title, string description, string createdBy,string RequestedBy):base (id, title, description, createdBy)
        {
            this.RequestedBy=RequestedBy;
        }
        public  override void DisplayDetails()
        {

            Console.WriteLine($"Id :{id}| Title: {title}| Description: {description}");
            Console.WriteLine($"Created By:{createdBy}| status: {status}");
            Console.WriteLine();
            Console.WriteLine();
        }
        public void ReportStatus()
        {
            Console.WriteLine("========FEATURE REQUEST REPORT==========");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Title: {title} ");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Created By: {createdBy}");
            Console.WriteLine($"Requested By:{RequestedBy}");
            Console.WriteLine();

        }
     
    }

}
