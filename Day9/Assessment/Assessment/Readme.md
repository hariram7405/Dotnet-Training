

# 🐞 Bug Tracker Lite

## 📖 Overview

**Bug Tracker Lite** is a lightweight, console-based application designed to help teams track bugs and manage tickets efficiently. It supports full CRUD operations for users, tickets, and tags with a many-to-many relationship between tickets and tags. Built using **.NET 8** and **Entity Framework Core**, the app stores data in **SQL Server**.

---

## ✨ Features

* 👤 Create and manage users
* 📝 Create tickets and assign them to users
* 🏷️ Create and assign multiple tags to tickets
* 🔄 Update ticket status (Open, Resolved, Closed)
* 🔍 View tickets with user and tag details
* 🗑️ Delete tickets from the system

---

## 🛠️ Prerequisites

Ensure you have the following installed:

* [.NET SDK 8+](https://dotnet.microsoft.com/en-us/download)
* SQL Server (LocalDB or full instance)
* Azure Data Studio or SQL Server Management Studio
* Visual Studio or VS Code
* EF Core CLI Tools

---

## 📁 Project Structure

```
Assessment/
│
├── Program.cs                   # Main entry point with console UI
│
├── Data/
│   └── AppDBContext.cs         # EF Core DbContext configuration
│
├── Models/
│   ├── User.cs                 # User model
│   ├── Ticket.cs               # Ticket model
│   ├── Tag.cs                  # Tag model
│   └── TicketTag.cs            # Many-to-many relationship model
│
├── Services/
│   ├── ITicketService.cs       # Interface for ticket service
│   └── TicketService.cs        # Business logic implementation
│
├── Utilities/
│   └── InputHelper.cs          # Console input validation helpers
│
└── Assessment.csproj           # Project configuration file
```

---

## 🧱 Step 1: Database Schema

Create a database named **BugTrackerLite** with the following tables:

| Table       | Columns                                                                         | Description                     |
| ----------- | ------------------------------------------------------------------------------- | ------------------------------- |
| `Users`     | `UserId` (PK), `UserName`                                                       | Stores user info                |
| `Tickets`   | `TicketId` (PK), `Title`, `Description`, `Status`, `CreatedDate`, `UserId` (FK) | Stores bug reports              |
| `Tags`      | `TagId` (PK), `TagName`                                                         | Stores tags                     |
| `TicketTag` | `TicketId` (FK), `TagId` (FK) – Composite PK                                    | Junction table for many-to-many |

---

## ⚙️ Step 2: Setup Entity Framework Core

Install EF Core packages:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

To scaffold models from your existing database (optional):

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=BugTrackerLite;User=sa;Password=YourPassword;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -f
```

Replace `YourPassword` accordingly.

---

## 🧩 Step 3: Define `TicketTag.cs`

```csharp
public class TicketTag
{
    public int TicketId { get; set; }
    public int TagId { get; set; }

    public virtual Tag Tag { get; set; } = null!;
    public virtual Ticket Ticket { get; set; } = null!;
}
```

---

## 📝 Step 4: Update Models

In both `Ticket.cs` and `Tag.cs`, add:

```csharp
public virtual ICollection<TicketTag> TicketTags { get; set; } = new List<TicketTag>();
```

---

## 💾 Step 5: Configure `AppDBContext.cs`

```csharp
public class AppDBContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<TicketTag> TicketTags => Set<TicketTag>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=BugTrackerLite;User=sa;Password=YourPassword;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketTag>().HasKey(tt => new { tt.TicketId, tt.TagId });

        modelBuilder.Entity<TicketTag>()
            .HasOne(tt => tt.Ticket)
            .WithMany(t => t.TicketTags)
            .HasForeignKey(tt => tt.TicketId);

        modelBuilder.Entity<TicketTag>()
            .HasOne(tt => tt.Tag)
            .WithMany(t => t.TicketTags)
            .HasForeignKey(tt => tt.TagId);
    }
}
```

---

## 📟 Step 6: Console Menu UI

```text
===== Bug Tracker Menu =====
1. Create User
2. Create Ticket
3. Add Tags to Ticket
4. Mark Ticket as Resolved
5. View All Tickets
6. Delete Ticket
7. Exit
Enter your choice:
```

Each option maps to a method in `TicketService`.

---

## 🚀 How to Run the App

Open Command Prompt in the project folder and run:

```bash
dotnet build
```

```bash
dotnet run
```

## OUPTUT


## 🚀 Build & Run Output

```bash
PS C:\Users\harirl\source\repos\.Net Training\Day9\Assessment\Assessment> dotnet build
Restore complete (0.4s)
  Assessment succeeded (0.3s) → bin\Debug\net8.0\Assessment.dll

Build succeeded in 1.5s

PS C:\Users\harirl\source\repos\.Net Training\Day9\Assessment\Assessment> dotnet run
```

---

### 🧑‍💼 User Creation

```
===== Bug Tracker Menu =====
1. Create User
2. Create Ticket
3. Add Tags to Ticket
4. Mark Ticket as Resolved
5. View All Tickets (with User and Tags)
6. Delete Ticket
7. Exit
Enter your choice: 1
Enter User Name: Akash
User added successfully.
```

---

### 🎫 Ticket Creation

```
===== Bug Tracker Menu =====
Enter your choice: 2
Enter Ticket Title: endpoint issue
Enter Ticket Description: Port is blocked by IT team. Endpoint is not accessible
Enter User ID to assign the ticket to: 4
Ticket created successfully.
```

---

### 🏷️ Tag Assignment

```
===== Bug Tracker Menu =====
Enter your choice: 3
Enter Ticket ID: 5
1. Create new Tag
2. Choose from Existing Tags
Enter your choice: 2
Available Tags:
1 - Security
2 - Design
3 - Configuration
Enter Tag ID to assign: 3
Tag assigned to ticket successfully.
```

---

### ✅ Mark Ticket as Resolved

```
===== Bug Tracker Menu =====
Enter your choice: 4
Enter Ticket Id: 5
Ticket 5 status changed to Resolved.
```

---

### 🗑️ Delete Ticket

```
===== Bug Tracker Menu =====
Enter your choice: 6
Enter Ticket ID to delete: 4
Ticket ID 4 deleted successfully.
```

---

### 📋 View All Tickets

```
===== Bug Tracker Menu =====
Enter your choice: 5
Ticket ID: 1
Title: Login Failed  
Description: My Login is not Working in recent ERP migration  
Status: Resolved  
Created Date: 8/1/2025  
Assigned User: Hari Ram L  
Tags: Security  
-------------------------------------
Ticket ID: 2  
Title: DB error  
Description: Database connection string invalid  
Status: Resolved  
Created Date: 8/1/2025  
Assigned User: Mani  
Tags: Design  
-------------------------------------
Ticket ID: 3  
Title: Build Failed in C#  
Description: The build is failed with C# version 4 due to client requirement  
Status: Open  
Created Date: 8/1/2025  
Assigned User: Janani  
Tags: Security, Configuration  
-------------------------------------
Ticket ID: 5  
Title: vpn  
Description: vpn failed  
Status: Resolved  
Created Date: 8/1/2025  
Assigned User: s  
Tags: Security  
-------------------------------------
Ticket ID: 6  
Title: endpoint issue  
Description: Port is blocked by IT team. Endpoint is not accessible  
Status: Open  
Created Date: 8/1/2025  
Assigned User: Mithran  
Tags: None  
-------------------------------------
```

---

### 👋 Exit Application

```
===== Bug Tracker Menu =====
1. Create User
2. Create Ticket
3. Add Tags to Ticket
4. Mark Ticket as Resolved
5. View All Tickets (with User and Tags)
6. Delete Ticket
7. Exit
Enter your choice: 7
Exiting application...
```

---
---
### SAMPLE SCREENSHOTS

![Application Output](https://github.com/hariram7405/Dotnet-Training/blob/main/Day9/Assessment/Assessment/Screenshots/Output.png?raw=true)

### AUTHOR
**Hari Ram L**