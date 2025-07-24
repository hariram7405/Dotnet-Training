using LeaveManagement.Models;
using System;
using System.Collections.Generic;
public class  LeaveService
{ 
public void DisplayAll(List<LeaveRequest> requests)
{
    if (requests == null)
    {
        Console.WriteLine("No leave requests to display.");
        return;
    }
    foreach (var req in requests)
    {
        req.Display();
    }
}

public void ShowApprovals(List<IApprovable> approvable)
{
    Console.WriteLine("=== APPROVAL STATUS ===");
    if (approvable == null)
    {
        Console.WriteLine("No approvable leave requests.");
        return;
    }
    foreach (var req in approvable)
    {
            req.showApprovableStatus();
        }
}
}