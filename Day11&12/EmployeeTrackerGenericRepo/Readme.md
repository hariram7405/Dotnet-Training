

# 🧾 EmployeeMapperRepo

A clean, modular **.NET 6 Console Application** for managing Employees and Departments using the **Generic Repository Pattern**, **AutoMapper**, and **Onion Architecture**.

---

## 🎯 Project Goal

To demonstrate:

* ✅ Clean layered architecture with separation of concerns
* ✅ Generic repository pattern implementation
* ✅ AutoMapper usage between entities and DTOs
* ✅ Interface-driven programming (SOLID principles)
* ✅ Manual dependency injection
* ✅ In-memory data management (no DB required)

---

## 📦 Tech Stack

| Technology         | Usage                      |
| ------------------ | -------------------------- |
| .NET 6             | Core runtime & SDK         |
| C#                 | Programming language       |
| Console App        | Presentation/UI layer      |
| AutoMapper         | Entity <-> DTO conversion  |
| Generic Repository | Abstract data access logic |
| Onion Architecture | Modular layering           |

---

## 🛠 Setup Instructions

### 📁 Create Solution and Projects

```bash
cd "C:\Users\harirl\source\repos\.Net Training\Day11"

mkdir EmployeeMapper
cd EmployeeMapper

dotnet new sln -n EmployeeMapperRepo

dotnet new classlib -n EmployeeMapper.Core
dotnet new classlib -n EmployeeMapper.Infrastructure
dotnet new classlib -n EmployeeMapper.Application
dotnet new console -n EmployeeMapper.ConsoleUI
```

### ➕ Add Projects to Solution

```bash
dotnet sln add EmployeeMapper.ConsoleUI/EmployeeMapper.ConsoleUI.csproj
dotnet sln add EmployeeMapper.Application/EmployeeMapper.Application.csproj
dotnet sln add EmployeeMapper.Infrastructure/EmployeeMapper.Infrastructure.csproj
dotnet sln add EmployeeMapper.Core/EmployeeMapper.Core.csproj
```

### 🔗 Add Project References

```bash
dotnet add EmployeeMapper.Infrastructure/EmployeeMapper.Infrastructure.csproj reference EmployeeMapper.Core/EmployeeMapper.Core.csproj

dotnet add EmployeeMapper.Application/EmployeeMapper.Application.csproj reference EmployeeMapper.Core/EmployeeMapper.Core.csproj
dotnet add EmployeeMapper.Application/EmployeeMapper.Application.csproj reference EmployeeMapper.Infrastructure/EmployeeMapper.Infrastructure.csproj

dotnet add EmployeeMapper.ConsoleUI/EmployeeMapper.ConsoleUI.csproj reference EmployeeMapper.Application/EmployeeMapper.Application.csproj
```

### 📦 Install NuGet Packages

Install AutoMapper in Application and ConsoleUI:

```bash
# In Application
cd EmployeeMapper.Application
dotnet add package AutoMapper --version 12.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

# In ConsoleUI
cd ../EmployeeMapper.ConsoleUI
dotnet add package AutoMapper --version 12.0.0
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

---

## 🧱 Final Project Structure

```
EmployeeMapperRepo/
│
├── EmployeeMapper.Core/
│   ├── DTOs/
│   │   ├── DepartmentRequest.cs
│   │   ├── DepartmentResponse.cs
│   │   ├── EmployeeRequest.cs
│   │   └── EmployeeResponse.cs
│   ├── Entities/
│   │   ├── Employee.cs
│   │   └── Department.cs
│   └── Interfaces/
│       ├── IRepository<T>.cs
│       ├── IDepartmentRepository.cs
│       ├── IEmployeeRepository.cs
│       ├── IEmployeeService.cs
│       └── IDepartmentService.cs
│
├── EmployeeMapper.Infrastructure/
│   └── Repositories/
│       ├── DepartmentRepository.cs
│       └── EmployeeRepository.cs
│
├── EmployeeMapper.Application/
│   ├── Services/
│   │   ├── DepartmentService.cs
│   │   └── EmployeeService.cs
│   └── Mapping/
│       └── MappingProfile.cs
│
├── EmployeeMapper.ConsoleUI/
│   ├── Program.cs
│   └── Menu.cs (optional)
│
└── EmployeeMapperRepo.sln
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

---
## 🧱 Entities

| Entity         | Description                                              | Key Properties                                                                                               |
| -------------- | -------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------ |
| **Employee**   | Represents an individual employee in the company.        | - Unique ID <br> - Full Name <br> - Job Designation <br> - Department ID (links to Department) <br> - Salary |
| **Department** | Represents a department or unit within the organization. | - Unique DeptId <br> - Department Name                                                                       |
---

## 🧩 Features

### 🔹 Department

* Add Department
* View All Departments
* Update Department
* Delete Department

### 🔹 Employee

* Add Employee
* View All Employees
* Update Employee
* Delete Employee

---

## 🔁 AutoMapper Profile

**MappingProfile.cs** (inside `EmployeeMapper.Application.Mapping`):

```csharp
using AutoMapper;
using EmployeeMapper.Core.DTOs;
using EmployeeMapper.Core.Entities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeResponse>().ReverseMap();
        CreateMap<EmployeeRequest, Employee>().ReverseMap();

        CreateMap<Department, DepartmentResponse>().ReverseMap();
        CreateMap<DepartmentRequest, Department>().ReverseMap();
    }
}
```

---

## 🖥 Sample Console Output

```
--- Employee Mapper Menu ---
1. Add Department
2. Add Employee
3. View All Departments
4. View All Employees
5. Update Department
6. Update Employee
7. Delete Department
8. Delete Employee
9. Exit
Select an option: 1

Enter Department Name (required): IT
Department added successfully.

Select an option: 2
Enter Employee Name (required): HARI RAM L
Enter Designation (required): TRAINEE
Enter Department Id (must exist): 1
Enter Salary (positive number): 20000
Employee added successfully.

--- Departments ---
ID    Name
--------------------
1     IT

--- Employees ---
ID    Name          Designation    DeptId   Salary
----------------------------------------------------
1     HARI RAM L    TRAINEE        1        $20,000.00

Select an option: 5
Enter Department Id to update: 1
Enter New Name: Information Technology
Department updated.

Select an option: 1
Enter Department Name: HR
Department added successfully.

Select an option: 3

--- Departments ---
ID    Name
--------------------
1     Information Technology
2     HR

Select an option: 7
Enter Department Id to delete: 2
Department deleted.

Select an option: 2
Enter Employee Name: ARUN
Enter Designation: DEVELOPER
Enter Department Id: 2
Department Id does not exist.
Enter Department Id: 1
Enter Salary: 20000
Employee added successfully.

Select an option: 4

--- Employees ---
ID    Name          Designation    DeptId   Salary
----------------------------------------------------
1     HARI RAM L    TRAINEE        1        $20,000.00
2     ARUN          DEVELOPER      1        $20,000.00

Select an option: 9
Exiting...
```

---

## ✅ Learning Outcomes

* ✅ Implemented Generic Repository pattern
* ✅ Understood AutoMapper for DTO mapping
* ✅ Built a complete Console UI following Onion Architecture
* ✅ Practiced clean architecture and SOLID principles
* ✅ Manual DI without third-party frameworks
* ✅ Validated inputs with clear user feedback

---

## 👨‍💻 Author

**Hari Ram L**