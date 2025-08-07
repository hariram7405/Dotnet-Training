

# 🧾 EmployeeTrackerGenericRepo

A clean, modular **.NET 6 Console Application** to manage Employees and Departments using the **Generic Repository Pattern** and **Onion Architecture**.

---

## 🎯 Project Goal

To demonstrate:

* Clean separation of concerns with **Layered Architecture**
* Implementation of a reusable **Generic Repository**
* Use of **SOLID principles** (especially Dependency Inversion and Interface Segregation)
* In-memory simulation of CRUD operations before integrating a real database

---

## 📦 Tech Stack

| Technology                                                       | Usage                        |
| ---------------------------------------------------------------- | ---------------------------- |
| [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) | Core framework               |
| C#                                                               | Programming language         |
| Console Application                                              | UI Layer                     |
| Generic Repository Pattern                                       | Abstraction over data access |
| Manual Dependency Injection                                      | No third-party DI tools      |

---

## 🧱 Project Structure

```
EmployeeTrackerGenericRepo/
│
├── EmployeeTracker.Core/
│   ├── Entities/
│   │   ├── Employee.cs
│   │   └── Department.cs
│   ├── Interfaces/
│   │   ├── IRepository<T>.cs
│   │   ├── IEmployeeRepository.cs
│   │   ├── IDepartmentRepository.cs
│   │   ├── IEmployeeService.cs
│   │   └── IDepartmentService.cs
│
├── EmployeeTracker.Infrastructure/
│   └── Repositories/
│       ├── EmployeeRepository.cs
│       └── DepartmentRepository.cs
│
├── EmployeeTracker.Application/
│   └── Services/
│       ├── EmployeeService.cs
│       └── DepartmentService.cs
│
├── EmployeeTracker.ConsoleUI/
│   ├── Program.cs
│   └── Menu.cs (optional)
│
└── EmployeeTrackerGenericRepo.sln
```

---

## 🏗️ Architecture Overview

This project follows the **Onion Architecture** (a layered approach) to ensure separation of concerns:

| Layer              | Description                                                                                      |
| ------------------ | ------------------------------------------------------------------------------------------------ |
| **Core**           | Contains Entities and Interfaces (Repository & Service interfaces) - independent of other layers |
| **Infrastructure** | Concrete implementations of repositories and data access logic                                   |
| **Application**    | Business logic implemented via Services layer; depends on Core and Infrastructure                |
| **ConsoleUI**      | Presentation layer that depends on Application, interacts with users via Console UI              |

---

## 🛠️ Solution Setup Guide

### Step 1: Create Solution and Projects

```bash
cd "C:\Users\harirl\source\repos\.Net Training\Day11"

mkdir EmployeeTrackerGenericRepo
cd EmployeeTrackerGenericRepo

dotnet new sln -n EmployeeTrackergenericRepo

dotnet new classlib -n EmployeeTracker.Core
dotnet new classlib -n EmployeeTracker.Infrastructure
dotnet new classlib -n EmployeeTracker.Application
dotnet new console -n EmployeeTracker.ConsoleUI
```

### Step 2: Add Projects to Solution

```bash
dotnet sln add EmployeeTracker.Core/EmployeeTracker.Core.csproj
dotnet sln add EmployeeTracker.Infrastructure/EmployeeTracker.Infrastructure.csproj
dotnet sln add EmployeeTracker.Application/EmployeeTracker.Application.csproj
dotnet sln add EmployeeTracker.ConsoleUI/EmployeeTracker.ConsoleUI.csproj
```

### Step 3: Add Project References

```bash
# Infrastructure depends on Core
dotnet add EmployeeTracker.Infrastructure/EmployeeTracker.Infrastructure.csproj reference EmployeeTracker.Core/EmployeeTracker.Core.csproj

# Application depends on Core and Infrastructure
dotnet add EmployeeTracker.Application/EmployeeTracker.Application.csproj reference EmployeeTracker.Core/EmployeeTracker.Core.csproj
dotnet add EmployeeTracker.Application/EmployeeTracker.Application.csproj reference EmployeeTracker.Infrastructure/EmployeeTracker.Infrastructure.csproj

# Console UI depends on Application
dotnet add EmployeeTracker.ConsoleUI/EmployeeTracker.ConsoleUI.csproj reference EmployeeTracker.Application/EmployeeTracker.Application.csproj
```

---

## 🧱 Entities

| Entity         | Description                                              | Key Properties                                                                                               |
| -------------- | -------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------ |
| **Employee**   | Represents an individual employee in the company.        | - Unique ID <br> - Full Name <br> - Job Designation <br> - Department ID (links to Department) <br> - Salary |
| **Department** | Represents a department or unit within the organization. | - Unique DeptId <br> - Department Name                                                                       |

---

## 🧩 Features

### Department Module

* Add, Update, Delete Departments
* View all Departments
* Get Department count

### Employee Module

* Add, Update, Delete Employees
* View all Employees
* Search Employees by Department
* Get total Employee count

---

## 🔍 Concepts Applied

* Generic Repository (`IRepository<T>`)
* Concrete Repositories (`EmployeeRepository`, `DepartmentRepository`)
* Business Logic implemented via Services layer
* Interface-driven architecture promoting loose coupling
* Manual dependency injection (without external frameworks)
* Clean Console UI with input validation

---

## 🔧 Setup & Run Instructions

1. **Clone the repository**

```bash
git clone https://github.com/yourusername/EmployeeTrackerGenericRepo.git
cd EmployeeTrackerGenericRepo
```

2. **Build the solution**

```bash
dotnet build
```

3. **Run the application**

```bash
cd EmployeeTracker.ConsoleUI
dotnet run
```

---

## 📷 Console Preview

```text
======= Employee Tracker Application =======
1. Add Employee
2. Update Employee
3. Delete Employee
4. Get Employee Count
5. Search Employees By Department
6. Show All Employees
7. Add Department
8. Update Department
9. Delete Department
10. Get Department Count
11. Show All Departments
12. Exit
============================================
```

## SAMPLE OUTPUT
```


> Choice: 7  
  Enter Department Name: HR  
  HR:1 added.

> Choice: 7  
  Enter Department Name: IT  
  IT:2 added.

> Choice: 1  
  Enter Employee Name: Hari  
  Enter Designation: Intern Software  
  Enter Department ID: 1  
  Enter Salary: 75000  
  Hari:100 added.

> Choice: 1  
  Enter Employee Name: Lokesh  
  Enter Designation: Intern Software  
  Enter Department ID: 1  
  Enter Salary: 75000  
  Lokesh:101 added.

> Choice: 2  
  Enter Employee ID to update: 101  
  Enter Name: Lokeshwaran  
  Enter Designation: Software Intern  
  Enter Department ID: 1  
  Enter Salary: 80000  
  Employee Updated.

> Choice: 3  
  Enter Employee ID to delete: 100  
  Employee Deleted.

> Choice: 4  
  Total Employees: 1

> Choice: 5  
  Enter Department ID: 1

  101 | Lokeshwaran | Software Intern | DeptID: 1 | Salary: $80,000.00

> Choice: 6  

--- Employee List ---

ID     Name           Designation       DeptId     Salary
-------------------------------------------------------------
101    Lokeshwaran    Software Intern   1          $80,000.00

> Choice: 8  
  Enter Department ID to update: 2  
  Enter New Department Name: Information Technology  
  Department Updated.

> Choice: 9  
  Enter Department ID to delete: 1  
  Department Deleted.

> Choice: 10  
  Total Departments: 1

> Choice: 11  

--- Department List ---

Dept ID    Department Name
---------------------------
2          Information Technology

> Choice: 12  
  Exiting application...


---
````

## 🔍 Learning Outcomes

* Deep understanding of the **Generic Repository Pattern**
* Improved code modularity using **interface segregation**
* Practical experience with **Clean Architecture** and layered design
* Simulated business logic for real-world HR modules

---


## 👤 Author

Hari Ram L

---
