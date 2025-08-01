
# SupportDeskProV2

## Project Overview

SupportDeskProV2 is a simple yet comprehensive customer support ticket management system developed using .NET and Entity Framework Core. The project models a real-world support desk scenario with users, departments, tickets, categories, and ticket history tracking. It showcases inheritance, complex relationships, and database integrity rules using EF Core.

---

## Features

- **User Inheritance:** Base `User` class extended by `Customer` and `SupportAgent`.
- **Customer Profiles:** One-to-one relationship between a `Customer` and their `CustomerProfile`.
- **Department Management:** Support agents assigned to departments.
- **Ticket Categories:** Organize tickets by categories.
- **Ticket Management:** Tickets linked to customers, assigned to multiple support agents.
- **Ticket History:** Logs actions and changes on tickets with timestamps.
- **Proper Cascade and Restriction Rules:** Ensures data integrity during deletes.

---

## Project Structure

```

SupportDeskProV2/
├── Models/
│   ├── User.cs               # Base class for users
│   ├── Customer.cs           # Customer inherits User
│   ├── SupportAgent.cs       # SupportAgent inherits User
│   ├── CustomerProfile.cs    # Profile details for Customer
│   ├── Department.cs         # Departments for SupportAgents
│   ├── Category.cs           # Ticket categories
│   ├── Ticket.cs             # Support tickets
│   └── TicketHistory.cs      # Ticket action logs
├── Data/
│   └── AppDbContext.cs       # EF Core DbContext and model configuration
├── Program.cs                # Main app with data seeding and display logic
└── SupportDeskProV2.csproj   # Project file

````

---

## Entity Relationships

- **User (abstract)**
  - `Customer` and `SupportAgent` inherit from `User`.

- **Customer**
  - One-to-one with `CustomerProfile`.
  - One-to-many with `Ticket`.

- **SupportAgent**
  - Many-to-one with `Department`.
  - Many-to-many with `Ticket`.

- **Department**
  - One-to-many with `SupportAgent`.

- **Category**
  - One-to-many with `Ticket`.

- **Ticket**
  - Many-to-many with `SupportAgent`.
  - One-to-many with `TicketHistory`.

- **TicketHistory**
  - Many-to-one with `Ticket`.

---

## Setup Instructions

### Prerequisites

- [.NET 7.0 SDK or later](https://dotnet.microsoft.com/download)
- SQL Server instance (local or remote)

### Required NuGet Packages

Run the following commands inside the project directory:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
````

### Database Configuration

Edit `Data/AppDbContext.cs`:

```csharp
optionsBuilder.UseSqlServer("Server=localhost;Database=SupportPro;User=sa;Password=YourPassword;TrustServerCertificate=True");
```

Replace `"YourPassword"` with your SQL Server password.

### Create and Update Database

Generate migration and apply to your database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Build and Run

```bash
dotnet build
dotnet run
```

---

## Sample Output

```
Departments:
- Cyber Security
- Customer Support

Customers:
- Hari, Email: hari@example.com, Phone: 1234567890
- Priya, Email: priya@gmail.com, Phone: 0987654321

Support Agents:
- Shiva, Department: Cyber Security
- Jnanni, Department: Customer Support

Tickets:
- Password reset issue (Customer: Hari, Agents: Shiva, Category: General Inquiry)
- Login error (Customer: Priya, Agents: Jnanni, Category: General Inquiry)

Detailed Tickets:

Ticket ID: 1
Title: Password reset issue
Description: Cannot reset my password
Created Date: 8/1/2025 8:27:53 AM
Status: Open
Customer: Hari (hari@example.com)
Category: General Inquiry
Support Agents: Shiva
Ticket History:
  - [8/1/2025 8:27:53 AM] Ticket created
  - [8/1/2025 8:57:53 AM] Assigned to Shiva

Ticket ID: 2
Title: Login error
Description: Getting error when logging in
Created Date: 8/1/2025 8:27:53 AM
Status: Open
Customer: Priya (priya@gmail.com)
Category: General Inquiry
Support Agents: Jnanni
Ticket History: (No actions recorded yet)
```

---
## Author
Hari Ram L