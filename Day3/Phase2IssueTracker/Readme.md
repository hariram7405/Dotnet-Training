
# 🐞 Issue Tracker System – .NET Console App

A simple console-based **Issue Tracker** that helps manage software issues like **Bugs**, **Tasks**, and **Feature Requests** using object-oriented principles in C#.

---

## 📌 Overview

This application is a simulation of a basic issue tracking tool. It allows you to manage different types of issues in a software project such as:

- Bugs
- Tasks
- Feature Requests

Each issue type has its own properties, reporting methods, and logic. The system uses **abstract classes**, **interfaces**, and **inheritance** to promote modular and reusable design.

---

## 🚀 Features

- 🔹 **Track Multiple Issue Types**: Bug, Task, Feature Request  
- 🧩 **Object-Oriented Design**: Abstraction, Inheritance, Polymorphism  
- 🔄 **Status Management**: Open, In Progress, Closed, Resolved  
- 📊 **Reports & Summaries**: Detailed summary reports for each issue  
- ✅ **Validation**: Ensures all fields and statuses are valid  

---

## 🧱 Class Structure

| Class / Interface   | Type           | Description |
|---------------------|----------------|-------------|
| `Issue`             | Abstract Class | Base class for all issue types. Stores Id, Title, AssignedTo, and Status. |
| `Bug`               | Class          | Inherits from `Issue`. Adds `Severity`. Implements `IReportable`. |
| `WorkTask`          | Class          | Inherits from `Issue`. Adds `EstimatedHours`. Implements `IReportable`. |
| `FeatureRequest`    | Class          | Inherits from `Issue`. Adds `RequestedBy` and `Deadline`. Implements `IReportable`. |
| `IReportable`       | Interface      | Declares `ReportStatus()` and `GetSummary()` for report generation. |
| `IIssueService`     | Interface      | Declares methods to manage issues (`Add`, `Display`, `Report`). |
| `IssueService`      | Class          | Implements `IIssueService` to manage issue operations. |
| `Program`           | Entry Point    | Creates and manages issue objects, triggers display and reporting. |

---

## 📤 Sample Output

```

Changing bug1 status to Closed:
Status changed to Closed successfully.

Displaying all issues:
[BUG] #1: App crashes on login | Severity: Critical | Assigned to: Ravi | Status: Closed

[Task] #2: Page not loading | Estimated Hours: 6 | Assigned to: Anita | Status: Open

[Feature] #3: Resolve UI feature issue | Requested By: Sunil | Deadline: 7 hours | Assigned to: Lokesh | Status: Open

Reporting status of all issues:
Bug #1 is under investigation. It is still in progress.
Summary
-------

Bug Id: 1
Bug Title: App crashes on login
Bug Severity: Critical
Bug AssignedTo: Ravi
Bug Status: Closed
Summary Generated on: 7/24/2025 4:00:00 PM

Task #2 is in progress. Estimated time: 6 hours.
Summary
-------

Task Id: 2
Task Title: Page not loading
Task AssignedTo: Anita
Task Status: Open
Task EstimationTime: 6 hours
Summary Generated on: 7/24/2025 4:00:00 PM

Feature Request #3 is being reviewed. Deadline: 7 hours
Summary
-------

Feature Id: 3
Feature Title: Resolve UI feature issue
Requested By: Sunil
Feature AssignedTo: Lokesh
Feature Status: Open
Feature Deadline: 7 hours
Summary Generated on: 7/24/2025 4:00:00 PM

## Summary of Tickets by Status:

Open Tickets: 2
Closed Tickets: 1
In Progress Tickets: 0
Resolved Tickets: 0

Changing feature1 status to Resolved:
Status changed to Resolved successfully.

```






---

## 🙋 Author

Created by **Har Ram L**  
🔗 [GitHub Profile](https://github.com/hariram7405)
```

