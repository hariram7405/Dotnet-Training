using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeaveManagement.Models;

namespace LeaveManagement.Services
{
   public  interface ILeaveService
    {
        void DisplayAll(List<LeaveRequest> requests);
        void showApprovals(List<IApprovable> approvables);

    }
}
