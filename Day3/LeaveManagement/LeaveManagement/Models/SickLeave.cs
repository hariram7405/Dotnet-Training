using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    public class SickLeave : LeaveRequest, IApprovable
    {
        public string doctorNote { get; set; }
     
        public SickLeave(int id, string name, int daysRequested, string doctorNote) :
             base(id, name, daysRequested)
        {
            this.doctorNote = doctorNote;
        }

        public override void Display()
        {
            Console.WriteLine($"[SICK]: #{id}| EmployeeName {name} | Days:{daysRequested}");

        }
        public void showApprovableStatus()
        {
            Console.WriteLine($"[SICK] :#{id}|Doctor Note:{doctorNote} | Status:{status}");

        }
    }
}
