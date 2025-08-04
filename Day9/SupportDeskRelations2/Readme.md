

# SupportDeskRelations

SupportDeskRelations is a simple ticket management system demonstrating a layered architecture using Entity Framework Core, with features to manage tickets, users, and tags. It shows how to query related data with Entity Framework Core and perform typical CRUD operations.

---

## Project Structure
```
SupportDeskRelations/
│
├── SupportDesk.Application/
│   ├── Services/
│   │   └── TicketService.cs
│   ├── Class1.cs
│   └── SupportDesk.Application.csproj
│
├── SupportDesk.ConsoleUI/
│   ├── Program.cs
│   └── SupportDesk.ConsoleUI.csproj
│
├── SupportDesk.Core/
│   ├── Entities/
│   │   ├── Tag.cs
│   │   ├── Ticket.cs
│   │   ├── TicketTag.cs
│   │   └── User.cs
│   ├── Interfaces/
│   ├── Class1.cs
│   └── SupportDesk.Core.csproj
│
└── SupportDesk.Infrastructure/
    ├── Data/
    │   └── AppDBContext.cs
    ├── Models/
    ├── Class1.cs
    └── SupportDesk.Infrastructure.csproj
```

---

## Features

* Manage Tickets, Users, and Tags.
* Retrieve tickets with related users and tags.
* Get counts of tickets per tag and per user.
* Query tickets by user or tag.
* Output tickets with associated user names and tags.

---

## Technologies Used

* .NET Core / .NET 6 (or later)
* C#
* Entity Framework Core (EF Core)
* Console Application

---



## Setup and Build Instructions

### 1. Create the solution and projects

```bash
dotnet new sln -n SupportDesk

dotnet new classlib -n SupportDesk.Core
dotnet new classlib -n SupportDesk.Infrastructure
dotnet new classlib -n SupportDesk.Application
dotnet new console -n SupportDesk.ConsoleUI
```

### 2. Add projects to the solution

```bash
dotnet sln add ./SupportDesk.Core/SupportDesk.Core.csproj
dotnet sln add ./SupportDesk.Infrastructure/SupportDesk.Infrastructure.csproj
dotnet sln add ./SupportDesk.Application/SupportDesk.Application.csproj
dotnet sln add ./SupportDesk.ConsoleUI/SupportDesk.ConsoleUI.csproj
```

### 3. Add project references

```bash
dotnet add ./SupportDesk.Infrastructure/SupportDesk.Infrastructure.csproj reference ./SupportDesk.Core/SupportDesk.Core.csproj

dotnet add ./SupportDesk.Application/SupportDesk.Application.csproj reference ./SupportDesk.Core/SupportDesk.Core.csproj

dotnet add ./SupportDesk.ConsoleUI/SupportDesk.ConsoleUI.csproj reference ./SupportDesk.Application/SupportDesk.Application.csproj

dotnet add ./SupportDesk.ConsoleUI/SupportDesk.ConsoleUI.csproj reference ./SupportDesk.Infrastructure/SupportDesk.Infrastructure.csproj

dotnet add ./SupportDesk.ConsoleUI/SupportDesk.ConsoleUI.csproj reference ./SupportDesk.Core/SupportDesk.Core.csproj  # Optional
```

### 4. Add EF Core packages to Infrastructure

```bash
cd SupportDesk.Infrastructure

dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### 5. Scaffold existing database (if needed, replace connection string)

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=SupportDeskDB;User=sa;Password=YourPassword;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -f
```

### 6. Organize Entities

* Create an `Entities` folder inside `SupportDesk.Core`.
* Move all entity classes (e.g., `Ticket.cs`, `User.cs`, `Tag.cs`, etc.) from `SupportDesk.Infrastructure` to `SupportDesk.Core/Entities`.
* Update namespaces inside these entity files from `SupportDesk.Infrastructure` to `SupportDesk.Core`.

### 7. Set ConsoleUI output type (if ConsoleUI was created as class library)

Edit `SupportDesk.ConsoleUI.csproj` and add the following inside the `<Project>` tag:

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

## LINQ Query Methods

| Method Signature                                                | Return Type                                     | Description                                         |
|----------------------------------------------------------------|------------------------------------------------|-----------------------------------------------------|
| `List<Ticket> GetAllTickets()`                                  | List of all tickets                             | Retrieve all tickets                                 |
| `List<Ticket> GetAllTicketsWithUsers()`                         | List of tickets with associated users          | Retrieve tickets including user details             |
| `List<Ticket> GetAllTicketsWithTags()`                          | List of tickets with associated tags           | Retrieve tickets including tag details               |
| `List<Ticket> GetUsersWithTickets()`                            | List of tickets with user info                   | Retrieve tickets grouped by users                    |
| `List<(string TagName, int TicketCount)> GetTagTicketCounts()`  | Tag names and their ticket counts                | Count tickets per tag                                |
| `List<(string UserName, int TicketCount)> GetTagTicketCountByUser()` | User names and their ticket counts               | Count tickets per user                               |
| `List<Ticket> GetTicketsByUserId(int userId)`                   | List of tickets filtered by user ID              | Retrieve tickets created by a specific user         |
| `List<Ticket> GetTicketsByTagId(int tagId)`                     | List of tickets filtered by tag ID               | Retrieve tickets associated with a specific tag     |
| `List<object> GetTicketsWithUserandTagNames()`                  | List of dynamic objects with ticket, user and tag info | Retrieve tickets with user and tag names dynamically |


## Sample Output

```
GetAllTickets:
- Login Issue
- UI Issue
- VPN Issue

GetAllTicketsWithUsers:
- Login Issue by Shiva
- UI Issue by Ram
- VPN Issue by Janani

GetAllTicketsWithTags:
- Login Issue with tags: bug, ui
- UI Issue with tags: 
- VPN Issue with tags: security

GetUsersWithTickets:
- Shiva raised ticket: Login Issue
- Ram raised ticket: UI Issue
- Janani raised ticket: VPN Issue

GetTagTicketCounts:
- bug: 1
- ui: 1
- security: 1

GetTagTicketCountByUser:
- Ram: 1
- Shiva: 1
- Janani: 1

GetTicketsByUserId (46):
- UI Issue

GetTicketsByTagId (47):
- Login Issue

GetTicketsWithUserandTagNames:
- { TicketId = 45, Title = Login Issue, UserName = Shiva, Tags = [bug, ui] }
- { TicketId = 46, Title = UI Issue, UserName = Ram, Tags = [] }
- { TicketId = 47, Title = VPN Issue, UserName = Janani, Tags = [security] }
```



---

## Author

Hari Ram L
