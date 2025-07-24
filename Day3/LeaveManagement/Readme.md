
# 🗂️ Leave Management System – .NET Console App

A console-based **Leave Management System** built with C# and .NET. This project demonstrates OOP concepts like **abstraction**, **inheritance**, **interfaces**, and **polymorphism** in the context of managing different types of employee leave requests.

---

## 📌 Purpose

This project is a mini HR tool to simulate managing leave applications. It supports:

- **Casual Leave**
- **Sick Leave**

Each leave can be approved or rejected, and the system cleanly separates general leave data from approval-specific logic using interfaces.

---

## ✅ Features

- **Abstract Class**: Shared structure for all leave types  
- **Inheritance**: `SickLeave` and `CasualLeave` extend `LeaveRequest`  
- **Interface Implementation**: Leaves that can be approved implement `IApprovable`  
- **Service Layer**: Handles display logic, separation of concerns  
- **Console Output**: Clear and readable output for leave data and approval status  

---

## 🧱 Project Structure

```

LeaveManagement/
│
├── Program.cs               # Entry point
│
├── Models/
│   ├── LeaveRequest.cs      # Abstract class
│   ├── SickLeave.cs         # Subclass for sick leaves
│   ├── CasualLeave.cs       # Subclass for casual leaves
│   └── IApprovable.cs       # Interface for approval logic
│
└── Services/
├── ILeaveService.cs     # Service interface
└── LeaveService.cs      # Service implementation

```

---

## 📘 Class Overview

| Class/Interface    | Type          | Description                                                                 |
|--------------------|---------------|-----------------------------------------------------------------------------|
| `LeaveRequest`     | Abstract Class| Base class for all leave types. Holds common properties like ID, Name, Days, Reason. |
| `SickLeave`        | Class          | Inherits from `LeaveRequest` and implements `IApprovable`. Represents a sick leave request. |
| `CasualLeave`      | Class          | Inherits from `LeaveRequest` and implements `IApprovable`. Represents a casual leave request. |
| `IApprovable`      | Interface      | Declares methods for setting and checking leave approval status.           |
| `ILeaveService`    | Interface      | Defines methods for displaying leaves and their statuses.                  |
| `LeaveService`     | Class          | Implements `ILeaveService`. Handles console output logic.                  |
| `Program`          | Class          | Entry point of the application. Creates leave objects and runs the service methods. |

---

## 👀 Sample Output

```

\---- All Leave Requests ----
Leave ID: 5001
Employee: Priya
Days Requested: 4
Reason: Viral Fever
-------------------

Leave ID: 1
Employee: Shiva
Days Requested: 5
Reason: Marriage
----------------

\---- Approval Status ----
Employee: Priya
Status: Pending
---------------

Employee: Shiva
Status: Pending
---------------

\---- Approval Status ----
Employee: Priya
Status: Approved
----------------

Employee: Shiva
Status: Rejected
----------------

````

---

## 🚀 Getting Started

### 🛠 Prerequisites

- .NET 6.0 SDK or later  
- Visual Studio or Visual Studio Code


---

## 🙋 Author

Created by **Hari Ram L**
🔗 [GitHub Profile](https://github.com/hariram7405)

```


