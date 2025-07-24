
# Phase2IssueTracker

A straightforward console application in C# for managing and tracking issues like bugs, work tasks, and feature requests.  
This project demonstrates core OOP principles such as inheritance, interfaces, and encapsulation in a practical context.

---

## 🚀 Features

- Manage multiple types of issues:
  - **Bug**: Tracks severity and status.
  - **WorkTask**: Includes estimated hours for completion.
  - **FeatureRequest**: Tracks requester and planned release date.
- Modify issue statuses with validation against allowed values.
- Display detailed issue information.
- Generate reports and summaries using the `IReportable` interface.
- Calculate and display counts of issues grouped by their current status (Open, Closed, In Progress, Resolved).

---

## 🗂 Project Structure

```plaintext
Phase2IssueTracker/
│
├── Program.cs                # Main execution file, demonstrates usage
├── Models/
│   ├── Issue.cs             # Base class for all issues
│   ├── Bug.cs               # Bug issue subclass implementing IReportable
│   ├── WorkTask.cs          # Work task subclass implementing IReportable
│   ├── FeatureRequest.cs    # Feature request subclass implementing IReportable
│   └── IReportable.cs       # Interface defining report methods
└── README.md                # This documentation file
````

---

## ⚙️ Getting Started

### Prerequisites

* .NET SDK installed (version 6.0 or above recommended)
* IDE or text editor (Visual Studio, VS Code, Rider, etc.)

### Build and Run

1. Clone or download the repository.
2. Open the project folder in your preferred IDE.
3. Build the solution/project.
4. Run the executable or start debugging.
5. Watch the console for issue details and summaries.

---

## 📋 Usage Overview

The application creates several issues, updates statuses, displays their information, and outputs a summary of ticket counts by status.

Example:

```plaintext
Changing bug1 status to Closed:
Status changed to Closed successfully.

[BUG] #1: App crashes on login | Severity: Critical | Assigned to: Ravi | Status: Closed
Bug #1 is under investigation. It is still in progress.
Summary
------------------------
Bug Id: 1
Bug Title: App crashes on login
Bug Severity: Critical
Bug AssignedTo: Ravi
Bug Status: Closed
Summary Generated on: 2025-07-24 15:30:00

[Task] #2: Page not loading | Estimated Hours: 6 | Assigned to: Anita | Status: Open
Task #2 is in progress. Estimated time: 6 hours.
Summary
------------------------
Task Id: 2
Task Title: Page not loading
Task AssignedTo: Anita
Task Status: Open
Task EstimationTime: 6 hours
Summary Generated on: 2025-07-24 15:30:00

[Feature] #3: Resolve UI feature issue | Assigned to: Lokesh | Requested By: Sunil | Release Date: 7hours | Status: Open
Feature Request #3 is ongoing. It is still in progress.
Summary
------------------------
Feature Id: 3
Feature Title: Resolve UI feature issue
Feature AssignedTo: Lokesh
Feature Status: Open
Feature RequestedBy: Sunil
Feature ReleaseDate: 7hours
Summary Generated on: 2025-07-24 15:30:00

Summary of Tickets by Status:
----------------------------
Open Tickets: 2
Closed Tickets: 1
In Progress Tickets: 0
Resolved Tickets: 0

Changing feature1 status to Resolved:
Status changed to Resolved successfully.
```


## 🛠 How It Works

* **Issue** is the base class with common properties like Id, Title, AssignedTo, and status.
* **Bug**, **WorkTask**, and **FeatureRequest** inherit from Issue and implement `IReportable` interface for reporting capabilities.
* Status changes are controlled via the `changeStatus` method, validating against a list of acceptable states.
* The program counts how many issues are in each status and displays a summary at runtime.

---
Thank you for exploring **Phase2IssueTracker**!
Happy coding! 🚀


