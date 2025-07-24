
# SupportDeskPro

SupportDeskPro is a C# console application designed to simulate a basic support desk ticketing system. It allows for the creation, management, and reporting of different types of support tickets, including general issues, bug reports, and feature requests.

## Features

- **Create Support Tickets**: Create tickets for issues, bugs, or feature requests.
- **Display Ticket Details**: Shows details such as ID, title, description, creator, and status.
- **Close Tickets**: Ability to close tickets by their ID.
- **Report Ticket Status**: Display detailed status reports for tickets that implement the `IReportable` interface (e.g., `BugReport` and `FeatureRequest`).



## Classes Overview

| **Class Name**     | **Description**                                                                                                           | **Methods**                                                                                                                |
| ------------------ | ------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------- |
| **SupportTicket**  | The base class for creating support tickets. It contains basic ticket details such as ID, title, description, and status. | - `DisplayDetails()` : Displays the ticket details. <br> - `closeTicket(int tid)` : Closes the ticket by ID.               |
| **BugReport**      | Inherits from `SupportTicket` and adds additional severity for bug-related tickets.                                       | - `DisplayDetails()` : Displays the bug report details. <br> - `ReportStatus()` : Reports the status with severity.        |
| **FeatureRequest** | Inherits from `SupportTicket` and adds information about who requested the feature.                                       | - `DisplayDetails()` : Displays the feature request details. <br> - `ReportStatus()` : Reports the feature request status. |
| **IReportable**    | Interface for reporting ticket status. Implemented by `BugReport` and `FeatureRequest`.                                   | - `ReportStatus()` : Defines the method for reporting the status of the ticket.                                            |

## Sample Output

When the application runs, it generates output similar to the following:

```
Id :1001| Title: UX issue| Description: Page is UnResponsive
Created By: lokesh | status: open

Id :1002| Title: VPN Issue | Description: VPN Disconnects often
Created By: hari | status: open

Id :1003| Title: Data Migration | Description: DB connectivity Issue
Created By: siva | status: open

Ticket id 1001 has been closed

========BUG REPORT==========
---------------------------------------------------------------
Id: 1002
Title: VPN Issue
Description: VPN Disconnects often
Created By: hari
Severity: High

========FEATURE REQUEST REPORT==========
---------------------------------------------------------------
Id: 1003
Title: Data Migration
Description: DB connectivity Issue
Created By: siva
Requested By: Client: XYZ associates

Ticket id 1002 has been closed
```

## Dependencies

* .NET SDK version 5.0 or later
* C# programming language



```
