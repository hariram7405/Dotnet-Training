



# SupportDeskPro Project Documentation

## Overview
SupportDeskPro is a simple C# console application designed to simulate a basic support desk ticketing system.
The application allows the creation, management, and reporting of different types of support tickets, such as
general issues, bug reports, and feature requests.

## Features
1. **SupportTicket**: Basic ticket containing general issue details.
2. **BugReport**: A specific type of support ticket that includes a severity level.
3. **FeatureRequest**: A specific type of support ticket that includes requester information.
4. **Display Ticket Details**: Shows the ticket ID, title, description, creator, and status.
5. **Close Tickets**: Ability to close tickets by their ID.
6. **Report Ticket Status**: Displays detailed reports for tickets implementing the `IReportable` interface (e.g., BugReport and FeatureRequest).

## Classes Overview

### 1. SupportTicket Class
The base class for creating tickets.
#### Properties:
- `id`: Ticket ID (int)
- `title`: Ticket Title (string)
- `description`: Ticket Description (string)
- `createdBy`: The person who created the ticket (string)
- `status`: Current status of the ticket (open/closed) (string)

#### Methods:
- `DisplayDetails()`: Displays the details of the support ticket.
- `closeTicket(int tid)`: Closes the ticket by ID and changes its status to "closed".

### 2. BugReport Class (Inherits from `SupportTicket`, Implements `IReportable`)
Represents a ticket for bug reports with additional severity level.

#### Additional Property:
- `severity`: The severity level of the bug (string, e.g., "High", "Low")

#### Methods:
- `DisplayDetails()`: Displays the details of the bug report.
- `ReportStatus()`: Displays detailed status including severity for bug tickets.

### 3. FeatureRequest Class (Inherits from `SupportTicket`, Implements `IReportable`)
Represents a feature request ticket with additional "RequestedBy" field.

#### Additional Property:
- `RequestedBy`: The entity or client that requested the feature (string)

#### Methods:
- `DisplayDetails()`: Displays the details of the feature request.
- `ReportStatus()`: Displays detailed status including requested by for feature request tickets.

### 4. IReportable Interface
This interface is used to implement status reporting functionality for `BugReport` and `FeatureRequest`.

#### Method:
- `ReportStatus()`: Displays detailed status information for a ticket.

## Main Program Flow
1. **Ticket Creation**: Initializes three different types of tickets:
   - **SupportTicket**: General issue.
   - **BugReport**: Bug report with severity.
   - **FeatureRequest**: Feature request with requester information.
   
2. **Display Ticket Details**: Each ticket's `DisplayDetails()` method is called to print details to the console.

3. **Close Ticket**: The `closeTicket()` method is called to close tickets by their IDs.

4. **Report Ticket Status**: Tickets implementing `IReportable` (i.e., `BugReport` and `FeatureRequest`) will call `ReportStatus()` to print detailed status reports.



## Code Implementation

### 1. **SupportTicket.cs**

```csharp
using System;

namespace SupportDeskPro.Models
{
    public class SupportTicket
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string createdBy { get; set; }
        public string status { get; set; }

        public SupportTicket(int id, string title, string description, string createdBy)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.createdBy = createdBy;
            status = "open";
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Id :{id}| Title: {title}| Description: {description}");
            Console.WriteLine($"Created By:{createdBy}| status: {status}");
            Console.WriteLine();
        }

        public void closeTicket(int tid)
        {
            status = "closed";
            Console.WriteLine($"Ticket id {tid} has been closed");
            Console.WriteLine();
        }
    }
}
```

### 2. **BugReport.cs**

```csharp
using System;

namespace SupportDeskPro.Models
{
    public class BugReport : SupportTicket, IReportable
    {
        string severity;

        public BugReport(int id, string title, string description, string createdBy, string severity)
            : base(id, title, description, createdBy)
        {
            this.severity = severity;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Id :{id}| Title: {title}| Description: {description}");
            Console.WriteLine($"Created By:{createdBy}| status: {status}");
            Console.WriteLine();
        }

        public void ReportStatus()
        {
            Console.WriteLine("========BUG REPORT==========");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Title: {title} ");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Created By: {createdBy}");
            Console.WriteLine($"Severity: {severity}");
            Console.WriteLine();
        }
    }
}
```

### 3. **FeatureRequest.cs**

```csharp
using System;

namespace SupportDeskPro.Models
{
    public class FeatureRequest : SupportTicket, IReportable
    {
        string RequestedBy;

        public FeatureRequest(int id, string title, string description, string createdBy, string RequestedBy)
            : base(id, title, description, createdBy)
        {
            this.RequestedBy = RequestedBy;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Id :{id}| Title: {title}| Description: {description}");
            Console.WriteLine($"Created By:{createdBy}| status: {status}");
            Console.WriteLine();
        }

        public void ReportStatus()
        {
            Console.WriteLine("========FEATURE REQUEST REPORT==========");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"Id: {id}");
            Console.WriteLine($"Title: {title} ");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Created By: {createdBy}");
            Console.WriteLine($"Requested By: {RequestedBy}");
            Console.WriteLine();
        }
    }
}
```

### 4. **IReportable.cs**

```csharp
namespace SupportDeskPro.Models
{
    public interface IReportable
    {
        void ReportStatus();
    }
}
```

### 5. **Program.cs**

```csharp
using System;
using System.Collections.Generic;
using SupportDeskPro.Models;

class Program
{
    public static void Main(string[] args)
    {
        List<SupportTicket> Issues = new List<SupportTicket>();
        SupportTicket s1 = new SupportTicket(1001, "UX issue", "Page is UnResponsive", "lokesh");
        BugReport b1 = new BugReport(1002, "VPN Issue", "VPN Disconnects often", "hari", "High");
        FeatureRequest f1 = new FeatureRequest(1003, "Data Migration", "DB connectivity Issue", "siva", "Client: XYZ associates");

        Issues.Add(s1);
        Issues.Add(b1);
        Issues.Add(f1);
        s1.DisplayDetails();
        b1.DisplayDetails();
       f1.DisplayDetails();
     s1.closeTicket(1001);
    b1.DisplayDetails();

    foreach (SupportTicket ticket in Issues)
    {
        if (ticket is IReportable reportable)
        {
            reportable.ReportStatus();
        }
        Console.WriteLine();
    }

    b1.closeTicket(1002);
    b1.DisplayDetails();
}


}

```
## Sample Output
The following is the output of running the application:

```

Id :1001| Title: UX issue| Description: Page is UnResponsive
Created By: lokesh | status: open

Id :1002| Title: VPN Issue | Description: VPN Disconnects often
Created By: hari | status: open

Id :1003| Title: Data Migration | Description: DB connectivity Issue
Created By: siva | status: open

Ticket id 1001 has been closed

Id :1002| Title: VPN Issue | Description: VPN Disconnects often
Created By: hari | status: open

## ========BUG REPORT==========

Id: 1002
Title: VPN Issue
Description: VPN Disconnects often
Created By: hari
Severity: High

## ========FEATURE REQUEST REPORT==========

Id: 1003
Title: Data Migration
Description: DB connectivity Issue
Created By: siva
Requested By: Client: XYZ associates

Ticket id 1002 has been closed

Id :1002 | Title: VPN Issue | Description: VPN Disconnects often
Created By: hari | status: closed

````
