using EFCoreDbFirstDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCoreDbFirstDemo { 

    class Program
    {
        public static void Main(string[] args)
        {

            while (true)
            {
                Menu();
                Console.WriteLine("Enter your choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice) {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        AddDepartment();
                        break;
                    case 3:
                        DisplayEmployee();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;


                }
            }


        }
        public static void Menu()
        {
            Console.WriteLine("---------Menu----------");
            Console.WriteLine("1.Add Employee");
            Console.WriteLine("2.Add Department");
            Console.WriteLine("3.Display Employee");
            Console.WriteLine("4.Exit");
        }
        public static void AddEmployee()
        {
            using var context = new CompanyContext();
            Console.WriteLine("Enter Number of Employees to insert");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter Employee Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Age");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Department Name:");
                string deptName = Console.ReadLine();

                var dept = context.Departments.FirstOrDefault(d => d.DepartmentName == deptName);
                if (dept == null)
                {
                    Console.WriteLine("Department not found.Add the Department first");
                    return;

                }


                var employee = new Employee
                {
                    Employeename = name,
                    Age = age,
                    DepartmentId = dept.DepartmentId,
                };
                context.Employees.Add(employee);
                

            }
                context.SaveChanges();
            Console.WriteLine("Employees Added Successfully");
        }
            public static void AddDepartment()
        {
            using var context=new CompanyContext();
            Console.Write("Enter Number of Departments to insert");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
               
                Console.WriteLine("Enter Department Name");
                string deptname=Console.ReadLine();

                var department = new Department
                {
                  
                    DepartmentName = deptname,
                };
                context.Departments.Add(department);
            }
                context.SaveChanges();

            Console.WriteLine("Department Added Successfully");

        }
        public static void DisplayEmployee()
        {
            var context = new CompanyContext();

            var employee = context.Employees
            .Include(e => e.Department)
            .Select(e => new
                {
                    e.EmployeeId,
                    e.Employeename,
                    DepartmentName = e.Department != null ? e.Department.DepartmentName : "No Department"
                }).ToList();

            if (employee.Any()) {
                Console.WriteLine("{0,-20}{1,-30}{2,-30}", "Employee id", "Employee Name", "Department");
                Console.WriteLine(new string('-', 80));
                foreach (var x in employee) {
                    Console.WriteLine("{0,-20}{1,-30}{2,-40}",x.EmployeeId,x.Employeename,x.DepartmentName);
             }
            }
            else
            {
                Console.WriteLine("No Records to display");
            }
            }
        }
    
}


