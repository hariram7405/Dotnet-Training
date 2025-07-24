using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class CasualLeave : LeaveRequest, IApprovable
    {
        string reason { get; set; }
        public CasualLeave(int id, string name, int daysRequested, string reason) :
             base(id, name, daysRequested)
        {
            this.reason = reason;
        }

        public override void Display()
        {
            Console.WriteLine($"[CASUAL LEAVE]: #{id}| EmployeeName {name} | Days:{daysRequested}");

        }
        public void showApprovableStatus()
        {
            Console.WriteLine($"[CASUAL] :#{id} |Reason :{reason} |Status: {status}");
          

        }
    }
}
