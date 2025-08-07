using AutoMapper;
using EmployeeMapper.Application.Mapping;
using EmployeeMapper.Application.Services;
using EmployeeMapper.Core.DTOs;
using EmployeeMapper.Infrastructure.Repositories;
using System;

namespace EmployeeMapper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            IMapper mapper = config.CreateMapper();

            var employeeRepo = new EmployeeRepository();
            var departmentRepo = new DepartmentRepository();

            var employeeService = new EmployeeService(employeeRepo, mapper);
            var departmentService = new DepartmentService(departmentRepo, mapper);

            while (true)
            {
                Console.WriteLine("\n--- Employee Mapper Menu ---");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Add Employee");
                Console.WriteLine("3. View All Departments");
                Console.WriteLine("4. View All Employees");
                Console.WriteLine("5. Update Department");
                Console.WriteLine("6. Update Employee");
                Console.WriteLine("7. Delete Department");
                Console.WriteLine("8. Delete Employee");
                Console.WriteLine("9. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddDepartment(departmentService);
                        break;
                    case "2":
                        AddEmployee(employeeService, departmentService);
                        break;
                    case "3":
                        departmentService.DisplayDepartment();
                        break;
                    case "4":
                        employeeService.DisplayEmployee();
                        break;
                    case "5":
                        UpdateDepartment(departmentService);
                        break;
                    case "6":
                        UpdateEmployee(employeeService, departmentService);
                        break;
                    case "7":
                        DeleteDepartment(departmentService);
                        break;
                    case "8":
                        DeleteEmployee(employeeService);
                        break;
                    case "9":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }


        static void AddDepartment(DepartmentService service)
        {
            string name;
            do
            {
                Console.Write("Enter Department Name (required): ");
                name = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Department name cannot be empty.");
                }
            } while (string.IsNullOrEmpty(name));

            var dto = new DepartmentRequestDTO
            {
                Name = name
            };

            service.AddDepartment(dto);
            Console.WriteLine("Department added successfully.");
        }

        static void AddEmployee(EmployeeService service, DepartmentService departmentService)
        {
            string name;
            do
            {
                Console.Write("Enter Employee Name (required): ");
                name = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(name))
                    Console.WriteLine("Employee name cannot be empty.");
            } while (string.IsNullOrEmpty(name));

            string designation;
            do
            {
                Console.Write("Enter Designation (required): ");
                designation = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(designation))
                    Console.WriteLine("Designation cannot be empty.");
            } while (string.IsNullOrEmpty(designation));

            int deptId;
            do
            {
                Console.Write("Enter Department Id (must exist): ");
                var deptInput = Console.ReadLine();
                if (!int.TryParse(deptInput, out deptId) || deptId <= 0)
                {
                    Console.WriteLine("Invalid Department Id.");
                    continue;
                }
                // Check if department exists
                if (!departmentService.Exists(deptId))
                {
                    Console.WriteLine("Department Id does not exist.");
                    continue;
                }
                break;
            } while (true);

            decimal salary;
            do
            {
                Console.Write("Enter Salary (positive number): ");
                var salaryInput = Console.ReadLine();
                if (!decimal.TryParse(salaryInput, out salary) || salary <= 0)
                {
                    Console.WriteLine("Invalid salary. Must be a positive number.");
                    continue;
                }
                break;
            } while (true);

            var dto = new EmployeeRequestDTO
            {
                Name = name,
                Designation = designation,
                DepartmentId = deptId,
                Salary = salary
            };

            service.AddEmployee(dto);
            Console.WriteLine("Employee added successfully.");
        }

        static void UpdateDepartment(DepartmentService service)
        {
            int id;
            do
            {
                Console.Write("Enter Department Id to update: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out id) || id <= 0)
                {
                    Console.WriteLine("Invalid Id.");
                    continue;
                }
                if (!service.Exists(id) )
                {
                    Console.WriteLine("Department with this Id does not exist.");
                    continue;
                }
                break;
            } while (true);

            string name;
            do
            {
                Console.Write("Enter New Name (required): ");
                name = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(name))
                    Console.WriteLine("Department name cannot be empty.");
            } while (string.IsNullOrEmpty(name));

            var dto = new DepartmentRequestDTO
            {
                Name = name
            };

            service.UpdateDepartment(dto);
            Console.WriteLine("Department updated.");
        }

        static void UpdateEmployee(EmployeeService employeeService, DepartmentService departmentService)
        {
            int id;
            do
            {
                Console.Write("Enter Employee Id to update: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out id) || id <= 0)
                {
                    Console.WriteLine("Invalid Id.");
                    continue;
                }
                if (!employeeService.Exists(id))
                {
                    Console.WriteLine("Employee with this Id does not exist.");
                    continue;
                }
                break;
            } while (true);

            string name;
            do
            {
                Console.Write("Enter New Name (required): ");
                name = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(name))
                    Console.WriteLine("Employee name cannot be empty.");
            } while (string.IsNullOrEmpty(name));

            string designation;
            do
            {
                Console.Write("Enter New Designation (required): ");
                designation = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(designation))
                    Console.WriteLine("Designation cannot be empty.");
            } while (string.IsNullOrEmpty(designation));

            int deptId;
            do
            {
                Console.Write("Enter New Department Id (must exist): ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out deptId) || deptId <= 0)
                {
                    Console.WriteLine("Invalid Department Id.");
                    continue;
                }
                if (!departmentService.Exists(deptId))
                {
                    Console.WriteLine("Department Id does not exist.");
                    continue;
                }
                break;
            } while (true);

            decimal salary;
            do
            {
                Console.Write("Enter New Salary (positive number): ");
                var input = Console.ReadLine();
                if (!decimal.TryParse(input, out salary) || salary <= 0)
                {
                    Console.WriteLine("Invalid salary. Must be positive.");
                    continue;
                }
                break;
            } while (true);

            var dto = new EmployeeRequestDTO
            {

                Name = name,
                Designation = designation,
                DepartmentId = deptId,
                Salary = salary
            };

            employeeService.UpdateEmployee(dto);
            Console.WriteLine("Employee updated.");
        }

        static void DeleteDepartment(DepartmentService service)
        {
            int id;
            do
            {
                Console.Write("Enter Department Id to delete: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out id) || id <= 0)
                {
                    Console.WriteLine("Invalid Id.");
                    continue;
                }
                if (!service.Exists(id))
                {
                    Console.WriteLine("Department with this Id does not exist.");
                    continue;
                }
                break;
            } while (true);

            service.DeleteDepartment(id);
            Console.WriteLine("Department deleted.");
        }

        static void DeleteEmployee(EmployeeService service)
        {
            int id;
            do
            {
                Console.Write("Enter Employee Id to delete: ");
                var input = Console.ReadLine();
                if (!int.TryParse(input, out id) || id <= 0)
                {
                    Console.WriteLine("Invalid Id.");
                    continue;
                }
                if (!service.Exists(id) )
                {
                    Console.WriteLine("Employee with this Id does not exist.");
                    continue;
                }
                break;
            } while (true);

            service.DeleteEmployee(id);
            Console.WriteLine("Employee deleted.");
        }
    }

}