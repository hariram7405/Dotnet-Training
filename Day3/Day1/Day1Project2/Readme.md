
# SupportPortal Project

## Project Description

SupportPortal is a basic C# console application that simulates an internal support system. It allows support agents to handle user requests, mark them as resolved, and reassign requests to other agents.

The project uses object-oriented programming concepts such as classes, constructors, encapsulation, and method usage.

---

## Classes Used

### SupportAgent

Located in `Models/SupportAgent.cs`

* Represents a support team member.
* **Properties:**

  * `AgentId`, `Name`, `Department`
* **Method:**

  * `DisplayAgent()` – shows agent details

### SupportRequest

Located in `Models/SupportRequest.cs`

* Represents a support issue/request.
* **Properties:**

  * `RequestId`, `Issue`, `Status`, `CreatedOn`, `ResolutionTimeInHours`, `IsResolved`, `AssignedTo`
* **Methods:**

  * `MarkResolved()` – updates the status to "Resolved"
  * `Reassign(SupportAgent)` – assigns request to a different agent
  * `DisplaySummary()` – displays request details

---
