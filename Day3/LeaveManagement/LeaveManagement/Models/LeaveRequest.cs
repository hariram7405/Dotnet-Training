using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaveManagement.Models
{
    
    public  abstract class LeaveRequest
    {

        public int id { get; set; }
        public string name { get; set; }
        public int daysRequested { get; set; }
        public string status { get; set; }
        public LeaveRequest(int id,string name,int daysRequested)
        {
            this.id = id;
            this.name = name;
            this.daysRequested = daysRequested;
            status = "Pending";
        }
        public  void Approve()
        {
            status = "Approved";
        }
        public void Reject()
        {
            status = "Rejected";
        }
        public abstract void Display();

    }
}
