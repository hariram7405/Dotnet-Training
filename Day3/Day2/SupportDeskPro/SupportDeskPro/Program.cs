using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportDeskPro.Models;
class Program
{
   
        public static void Main(String[] args)
        {
            List<SupportTicket> Issues = new List<SupportTicket>();
            SupportTicket s1 = new SupportTicket(1001, "UX issue", "Page is UnResponsive", "lokesh");
            BugReport b1 = new BugReport(1002, "VPN Issue", "VPN Disconnects often", "hari", "High");
            FeatureRequest f1 = new FeatureRequest(1003, "Data Migration", "DB connctivity Issue", "siva", "Client:XYZ associates");

            Issues.Add(s1);
            Issues.Add(b1);
            Issues.Add(f1);
            s1.DisplayDetails();
            b1.DisplayDetails();
            f1.DisplayDetails();
            s1.closeTicket(1001);
            b1.DisplayDetails();

            
        foreach (SupportTicket ticket in Issues)
        {
            if (ticket is IReportable reportable)
            {
                reportable.ReportStatus();
              
            }

            Console.WriteLine();
        }


        b1.closeTicket(1002);
        b1.DisplayDetails();





    }
    }
