using EmployeeTracker.Core.Entities;
using EmployeeTracker.Application.Services;
using EmployeeTracker.Infrastructure.Repositories;
using System;

class Program
{
    private static int empIdCounter = 100;
    private static int deptIdCounter = 1;

    public static void Main(string[] args)
    {
        var empRepo = new EmployeeRepository();
        var deptRepo = new DepartmentRepository();
        var empService = new EmployeeService(empRepo);
        var deptService = new DepartmentService(deptRepo);

        while (true)
        {
            Menu();
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Add Employee
                    Console.Write("Enter Employee Name: ");
                    var name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty.\n");
                        break;
                    }

                    Console.Write("Enter Designation: ");
                    var designation = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(designation))
                    {
                        Console.WriteLine("Designation cannot be empty.\n");
                        break;
                    }

                    Console.Write("Enter Department ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int deptId))
                    {
                        Console.WriteLine("Invalid Department ID.\n");
                        break;
                    }

                    if (deptService.Exists(deptId) == 1)
                    {
                        Console.WriteLine("Department ID not found. Please add department first.\n");
                        break;
                    }

                    Console.Write("Enter Salary: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal salary) || salary <= 0)
                    {
                        Console.WriteLine("Invalid or negative salary.\n");
                        break;
                    }

                    var newEmp = new Employee
                    {
                        Id = empIdCounter++,
                        Name = name,
                        Designation = designation,
                        DepartmentId = deptId,
                        Salary = salary
                    };
                    empService.AddEmployee(newEmp);
                    Console.WriteLine($"{newEmp.Name}:{newEmp.Id} added.\n");
                    break;

                case "2": // Update Employee
                    Console.Write("Enter Employee ID to update: ");
                    if (!int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.WriteLine("Invalid ID.\n");
                        break;
                    }

                    if (empService.Exists(updateId) == 1)
                    {
                        Console.WriteLine("Employee ID not found.\n");
                        break;
                    }

                    Console.Write("Enter Name: ");
                    var newName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newName))
                    {
                        Console.WriteLine("Name cannot be empty.\n");
                        break;
                    }

                    Console.Write("Enter Designation: ");
                    var newDesignation = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newDesignation))
                    {
                        Console.WriteLine("Designation cannot be empty.\n");
                        break;
                    }

                    Console.Write("Enter Department ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int newDeptId))
                    {
                        Console.WriteLine("Invalid Department ID.\n");
                        break;
                    }

                    if (deptService.Exists(newDeptId) == 1)
                    {
                        Console.WriteLine("Department ID not found.\n");
                        break;
                    }

                    Console.Write("Enter Salary: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal newSalary) || newSalary <= 0)
                    {
                        Console.WriteLine("Invalid or negative salary.\n");
                        break;
                    }

                    empService.UpdateEmployee(new Employee
                    {
                        Id = updateId,
                        Name = newName,
                        Designation = newDesignation,
                        DepartmentId = newDeptId,
                        Salary = newSalary
                    });
                    Console.WriteLine("Employee Updated.\n");
                    break;

                case "3": // Delete Employee
                    Console.Write("Enter Employee ID to delete: ");
                    if (!int.TryParse(Console.ReadLine(), out int delId))
                    {
                        Console.WriteLine("Invalid ID.\n");
                        break;
                    }

                    if (empService.Exists(delId) == 1)
                    {
                        Console.WriteLine("Employee ID not found.\n");
                        break;
                    }

                    empService.DeleteEmployee(delId);
                    Console.WriteLine("Employee Deleted.\n");
                    break;

                case "4": // Get Employee Count
                    Console.WriteLine($"Total Employees: {empService.GetEmployeeCount()}\n");
                    break;

                case "5": // Get Employees by Dept
                    Console.Write("Enter Department ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int searchDeptId))
                    {
                        Console.WriteLine("Invalid ID.\n");
                        break;
                    }

                    var emps = empService.GetEmployeesByDepartment(searchDeptId);
                    if (emps == null )
                    {
                        
                        Console.WriteLine("No employees found in this department.\n");
                        break;
                    }

                    foreach (var e in emps)
                    {
                        Console.WriteLine($"{e.Id} | {e.Name} | {e.Designation} | DeptID: {e.DepartmentId} | Salary: {e.Salary:C}");
                    }
                    break;

                case "6": // Show All Employees
                    empService.DisplayEmployee();
                    break;

                case "7": // Add Department
                    Console.Write("Enter Department Name: ");
                    var deptName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(deptName))
                    {
                        Console.WriteLine("Department name cannot be empty.\n");
                        break;
                    }

                    var newDept = new Department { DeptId = deptIdCounter++, DeptName = deptName };
                    deptService.AddDepartment(newDept);
                    Console.WriteLine($"{newDept.DeptName}:{newDept.DeptId} added.\n");
                    break;

                case "8": // Update Department
                    Console.Write("Enter Department ID to update: ");
                    if (!int.TryParse(Console.ReadLine(), out int dUpdateId))
                    {
                        Console.WriteLine("Invalid ID.\n");
                        break;
                    }

                    if (deptService.Exists(dUpdateId) == 1)
                    {
                        Console.WriteLine("Department ID not found.\n");
                        break;
                    }

                    Console.Write("Enter New Department Name: ");
                    var newDeptName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(newDeptName))
                    {
                        Console.WriteLine("Department name cannot be empty.\n");
                        break;
                    }

                    deptService.UpdateDepartment(new Department { DeptId = dUpdateId, DeptName = newDeptName });
                    Console.WriteLine("Department Updated.\n");
                    break;

                case "9": // Delete Department
                    Console.Write("Enter Department ID to delete: ");
                    if (!int.TryParse(Console.ReadLine(), out int dDelId))
                    {
                        Console.WriteLine("Invalid ID.\n");
                        break;
                    }

                    if (deptService.Exists(dDelId) == 1)
                    {
                        Console.WriteLine("Department ID not found.\n");
                        break;
                    }

                    deptService.DeleteDepartment(dDelId);
                    Console.WriteLine("Department Deleted.\n");
                    break;

                case "10": // Department Count
                    Console.WriteLine($"Total Departments: {deptService.GetDepartmentCount()}\n");
                    break;

                case "11": // Show All Departments
                    deptService.DisplayDepartment();
                    break;

                case "12": // Exit
                    Console.WriteLine("Exiting application...");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.\n");
                    break;
            }
        }
    }

    public static void Menu()
    {
        Console.WriteLine("\n======= Employee Tracker Application =======");
        Console.WriteLine("1. Add Employee");
        Console.WriteLine("2. Update Employee");
        Console.WriteLine("3. Delete Employee");
        Console.WriteLine("4. Get Employee Count");
        Console.WriteLine("5. Search Employees By Department");
        Console.WriteLine("6. Show All Employees");
        Console.WriteLine("7. Add Department");
        Console.WriteLine("8. Update Department");
        Console.WriteLine("9. Delete Department");
        Console.WriteLine("10. Get Department Count");
        Console.WriteLine("11. Show All Departments");
        Console.WriteLine("12. Exit");
        Console.WriteLine("============================================");
    }
}
