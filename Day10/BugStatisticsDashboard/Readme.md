
# BugDashboardStats

A modular, layered console application designed to manage and analyze bug reports efficiently. The project follows Domain-Driven Design principles and implements a clean architecture to ensure maintainability, extensibility, and testability.

---



## Project Overview


BugDashboardStats is a console-based bug tracking dashboard that enables teams to track bug statuses, priorities, assignments, and projects. It provides statistical insights by grouping and filtering bugs based on different criteria.

The system is designed with clean separation of concerns: domain entities and interfaces are isolated from application business logic, which itself is separate from infrastructure (data access and DTOs) and presentation layers.

This approach helps create a robust, testable, and maintainable codebase suitable for further enhancements like database integration or web frontends.


---

## Architecture


| **Layer**                | **Responsibility**                           | **Key Components / Folders**                             | **Description**                                                                                                                      |
| ------------------------ | -------------------------------------------- | -------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------ |
| **Core Layer**           | Domain entities and repository interfaces    | `Core/Entities/`<br>`Core/Interfaces/`                   | Defines business models (`Bug`, `User`, `Project`) and contracts (`IBugRepository`) representing the core domain logic.              |
| **Application Layer**    | Business logic and application services      | `Application/Services/`                                  | Contains services (`BugService`) that implement use cases like filtering, grouping, and managing bugs based on business rules.       |
| **Infrastructure Layer** | Data access and data transfer objects (DTOs) | `Infrastructure/Repositories/`<br>`Infrastructure/DTOs/` | Provides concrete implementations for repositories (`BugRepository`) and DTOs for decoupling data representation from domain models. |
| **Presentation Layer**   | User interface and interaction logic         | `Program.cs`                                             | Console-based UI that interacts with users, presenting menus, capturing inputs, and displaying results.                              |


---

## Features

* Manage bugs with CRUD (Create, Read, Update, Delete) capabilities.
* Filter bugs by criteria such as priority, status, and assigned user.
* Group bugs to generate statistical summaries by project or status.
* User-friendly console menu interface for easy navigation and interaction.
* Modular design allowing for easy swapping of data sources or UI layers.
* Extensible with minimal impact on existing code due to layered design.

---

## Project Structure

```
BugDashboardStats/
├── Core/
│   ├── Entities/           # Domain models: Bug, User, Project
│   │   ├── Bug.cs
│   │   ├── User.cs
│   │   └── Project.cs
│   └── Interfaces/         # Repository interfaces
│       └── IBugRepository.cs
├── Application/
│   └── Services/           # Business logic and application services
│       └── BugService.cs
├── Infrastructure/
│   ├── Repositories/       # Concrete repository implementations (in-memory)
│   │   └── BugRepository.cs
│   └── DTOs/               # Data Transfer Objects
│       ├── BugDto.cs
│       └── BugGroupedStatsDto.cs
└── Program.cs              # Console UI entry point and interaction logic
```

---

## Project Setup Instructions


## Step 1: Create Root Solution

```bash
mkdir BugDashboardStats
cd BugDashboardStats
dotnet new sln -n BugDashboardStats
````

Creates a new folder and a solution file `BugDashboardStats.sln`.

---

## Step 2: Create Core Class Library

```bash
dotnet new classlib -n Core
dotnet sln add Core/Core.csproj
mkdir Core/Entities Core/Interfaces
```

Structure inside **Core**:

* `Entities/` — for domain models like `Bug.cs`, `User.cs`, `Project.cs`
* `Interfaces/` — for repository interfaces like `IBugRepository.cs`

---

## Step 3: Create Application Class Library

```bash
dotnet new classlib -n Application
dotnet sln add Application/Application.csproj
mkdir Application/Services
```

---

## Step 4: Create Infrastructure Class Library

```bash
dotnet new classlib -n Infrastructure
dotnet sln add Infrastructure/Infrastructure.csproj
mkdir Infrastructure/Repositories Infrastructure/DTOs
```

---

## Step 5: Create Console Application for UI

```bash
dotnet new console -n BugDashboardStats.Console
dotnet sln add BugDashboardStats.Console/BugDashboardStats.Console.csproj
```

---

## Step 6: Add Project References to Reflect Dependencies

```bash
dotnet add Application/Application.csproj reference Core/Core.csproj
dotnet add Infrastructure/Infrastructure.csproj reference Core/Core.csproj
dotnet add Infrastructure/Infrastructure.csproj reference Application/Application.csproj
dotnet add BugDashboardStats.Console/BugDashboardStats.Console.csproj reference Application/Application.csproj
dotnet add BugDashboardStats.Console/BugDashboardStats.Console.csproj reference Infrastructure/Infrastructure.csproj
```

---

## Step 7: Build the Solution

```bash
dotnet build
```

---

## Step 8: Run the Console Application

```bash
dotnet run --project BugDashboardStats.Console
```

---



## How To Run


### Installation Steps

1. **Clone the repository:**

   ```bash
   git clone https://github.com/yourusername/BugDashboardStats.git
   cd BugDashboardStats
   ```

2. **Build the project:**

   ```bash
   dotnet build
   ```

3. **Run the application:**

   ```bash
   dotnet run --project BugDashboardStats
   ```

---

## Usage

* On launching, the console displays a main menu with options such as:

  * View all bugs
  * Add a new bug
  * Update existing bugs
  * Delete bugs
  * Filter bugs by status, priority, or user
  * Display grouped bug statistics
  * Exit the application

* Select options by entering the corresponding number or key.

* Follow on-screen prompts for entering details like bug description, status, assigned user, etc.

* Use the menus iteratively to explore bug data and perform operations.

---

## Technology Stack

* **Language:** C#
* **Platform:** .NET 6.0 Console Application
* **Design:** Layered architecture with Domain-Driven Design principles
* **Data Storage:** Currently uses in-memory data repository for simplicity, allowing quick testing and iteration.

---

## Extensibility and Future Work

* **Database Integration:** Replace the in-memory repository with a persistent database (e.g., SQL Server, SQLite, or NoSQL options) by implementing `IBugRepository`.
* **Web or GUI Frontend:** Develop a web interface (e.g., ASP.NET Core MVC, Blazor) or a desktop GUI for enhanced usability.
* **Authentication & Authorization:** Add user authentication to manage access control for bug management.
* **Reporting:** Export reports in formats like CSV, Excel, or PDF for offline analysis.
* **API Layer:** Create RESTful APIs to allow integration with other tools or automated workflows.

---

## SAMPLE OUTPUT
```
Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 1

=== All Bugs ===
------------------------------------------------------------------------------------------------------------------------
Title                     Project              Assigned To     Status          Priority   Created
------------------------------------------------------------------------------------------------------------------------
Login fails               Website Redesign     Alice           Open            High       7/30/2025
UI not responsive         Mobile App           Bob             In Progress     Medium     8/2/2025
Crash on submit           Website Redesign     Alice           Closed          High       7/25/2025
Data not saving           Mobile App           Bob             Open            Low        8/3/2025
------------------------------------------------------------------------------------------------------------------------

Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 2
Enter project name: mobile app

=== Bugs for Project 'mobile app' ===
------------------------------------------------------------------------------------------------------------------------
Title                     Project              Assigned To     Status          Priority   Created
------------------------------------------------------------------------------------------------------------------------
UI not responsive         Mobile App           Bob             In Progress     Medium     8/2/2025
Data not saving           Mobile App           Bob             Open            Low        8/3/2025
------------------------------------------------------------------------------------------------------------------------

Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 3
Enter status (Open, Closed, In Progress): open

=== Bugs with Status 'Open' ===
------------------------------------------------------------------------------------------------------------------------
Title                     Project              Assigned To     Status          Priority   Created
------------------------------------------------------------------------------------------------------------------------
Login fails               Website Redesign     Alice           Open            High       7/30/2025
Data not saving           Mobile App           Bob             Open            Low        8/3/2025
------------------------------------------------------------------------------------------------------------------------

Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 4
Enter priority (High, Medium, Low): high

=== Bugs with Priority 'High' ===
------------------------------------------------------------------------------------------------------------------------
Title                     Project              Assigned To     Status          Priority   Created
------------------------------------------------------------------------------------------------------------------------
Login fails               Website Redesign     Alice           Open            High       7/30/2025
Crash on submit           Website Redesign     Alice           Closed          High       7/25/2025
------------------------------------------------------------------------------------------------------------------------

Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 5

=== All Bugs (Sorted by Created Date) ===
------------------------------------------------------------------------------------------------------------------------
Title                     Project              Assigned To     Status          Priority   Created
------------------------------------------------------------------------------------------------------------------------
Crash on submit           Website Redesign     Alice           Closed          High       7/25/2025
Login fails               Website Redesign     Alice           Open            High       7/30/2025
UI not responsive         Mobile App           Bob             In Progress     Medium     8/2/2025
Data not saving           Mobile App           Bob             Open            Low        8/3/2025
------------------------------------------------------------------------------------------------------------------------

Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 6

=== Bug Count by Status ===
Key                       Count
-----------------------------------
Open                      2
In Progress               1
Closed                    1

Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 7

=== Bug Count by Priority ===
Key                       Count
-----------------------------------
High                      2
Medium                    1
Low                       1

Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 8

=== Bug Count by Project ===
Key                       Count
-----------------------------------
Website Redesign          2
Mobile App                2

Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 9

=== Bug Count by Project ===
Key                       Count
-----------------------------------
Website Redesign          2
Mobile App                2

=== Bug Count by Priority ===
Key                       Count
-----------------------------------
High                      2
Medium                    1
Low                       1

=== Bug Count by Status ===
Key                       Count
-----------------------------------
Open                      2
In Progress               1
Closed                    1

Bug Stats Dashboard
-------------------
1. View All Bugs
2. View Bugs by Project
3. View Bugs by Status
4. View Bugs by Priority
5. View All Bugs Sorted by Created Date
6. Group by Status
7. Group by Priority
8. Group by Project
9. Show All Grouped Stats
10. Exit

Select an option: 10
Exiting...

C:\Users\harirl\source\repos\.Net Training\Day10\BugDashboardStats\BugDashboardStats.ConsoleUI\bin\Debug\net8.0\BugDashboardStats.ConsoleUI.exe (process 29936) exited with code 0 (0x0).
To automatically close the console when debugging stops, enable Tools->Options->Debugging->Automatically close the console when debugging stops.
 */
```

## AUTHOR
HARI RAM L

---