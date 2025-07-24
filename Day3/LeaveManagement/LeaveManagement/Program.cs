using System;
using System.Collections.Generic;
using LeaveManagement.Models;
using LeaveManagement.Services;

class Program
{
    public static void Main(string[] args)
    {
       
        SickLeave s1 = new SickLeave(5001, "Priya", 4, "Viral Fever");
        CasualLeave c1 = new CasualLeave(1, "Shiva", 5, "Marriage");

        List<LeaveRequest> leaves = new List<LeaveRequest> { s1, c1 };
        List<IApprovable> approvables = new List<IApprovable> { s1, c1 };

       
        LeaveService service = new LeaveService();
        service.DisplayAll(leaves);
        Console.WriteLine();
   
        service.ShowApprovals(approvables);
        Console.WriteLine();



        s1.Approve();
        c1.Reject();

        service.ShowApprovals(approvables);

    }
}
