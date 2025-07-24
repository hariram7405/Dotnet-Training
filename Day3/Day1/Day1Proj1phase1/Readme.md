
# Ticket1 Project

## Project Description

Ticket1 is a simple C# console application that simulates a basic ticketing system. It allows users to create and manage support tickets, assign them to specific users, and display ticket summaries. The project demonstrates core object-oriented programming principles such as encapsulation, class design, and constructor usage.

---

## Classes Used

### Ticket

Located in `Models/Ticket.cs`

* Represents a support ticket.
* **Key Properties:**

  * `TicketId` (read-only)
  * `Title`, `Description`, `Priority`
  * `Status` (default: "Open", read-only)
  * `AssignedTo` (User object, read-only)
  * `CreatedOn` (auto-generated, read-only)
* **Key Methods:**

  * `ReassignTicket(User newUser)` – changes assigned user
  * `DisplaySummary()` – prints ticket information to the console

### User

Located in `Models/User.cs`

* Represents a user who can be assigned to a ticket.
* **Properties:**

  * `Id`, `Name`, `Role`
* **Method:**

  * `DisplayUser()` – prints user details

---

## Enhancements Made

* Organized code with a clean folder structure (`Models` directory)
* Used constructors with optional parameters for flexibility
* Applied encapsulation using `private set` for controlled access
* Automatically sets ticket creation time with `DateTime.Now`
* Implemented ticket reassignment functionality
* Followed standard naming conventions and formatting practices

---
