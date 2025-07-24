
# 🐞 IssueTracker

**IssueTracker** is a simple C# console application designed to manage and track software issues, such as bugs and work-related tasks. This project serves as an educational demonstration of object-oriented programming (OOP) concepts including abstraction, inheritance, interfaces, and polymorphism.

---

## 🔍 Overview

The application allows users to:

- Define and manage different types of issues (e.g. bugs, tasks)
- Display issue details dynamically
- Report the current status of each issue using a shared interface

The codebase is modular and easily extendable, making it suitable for both beginners and developers interested in applying solid OOP principles in C#.

---

## 📁 Project Structure

```

IssueTracker/
│
├── Models/
│   ├── Bug.cs           # Represents a software bug with severity
│   ├── Issue.cs         # Abstract base class for all issues
│   ├── WorkTask.cs      # Represents a work task with estimated hours
│   └── IReportable.cs   # Interface for issues that can report status
│
└── Program.cs           # Main console application logic

```

---

## 🚀 Features

- Tracks and manages two issue types: **Bugs** and **Work Tasks**
- Displays formatted output in the console for each issue
- Implements the **IReportable** interface for consistent status reporting
- Demonstrates **inheritance**, **abstraction**, and **polymorphism**
- Designed for clarity and educational use

---

## 🛠 How to Run

1. Open the project in Visual Studio or any compatible .NET IDE.
2. Build the solution.
3. Run the application.
4. View a list of issues and their statuses in the console output.

---

## 📌 Use Cases

- Ideal for learning and teaching object-oriented design in C#
- Can be extended into a full-fledged issue tracking system
- Useful as a starting point for larger project or system architecture

---

