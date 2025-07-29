
# BugTrackerDB

**BugTrackerDB** is a relational database designed for managing bugs, users, and projects in a software development environment. It helps track the lifecycle of bugs reported in various projects, their statuses, and who is responsible for addressing them.

## 📁 Database Schema Overview

The schema includes the following tables:

### 1. `Users`
Stores information about individuals involved in the bug tracking process (e.g., developers, testers, managers).

| Column Name | Data Type     | Description                      |
|-------------|---------------|----------------------------------|
| UserId      | INT (PK)      | Unique user ID (starts at 1000) |
| UserName    | NVARCHAR(100) | Full name of the user           |
| UserEmail   | NVARCHAR(100) | Unique email address            |
| Role        | NVARCHAR(50)  | Role of the user                |

---

### 2. `Projects`
Represents projects under which bugs may be reported.

| Column Name        | Data Type     | Description                         |
|--------------------|---------------|-------------------------------------|
| ProjectId          | INT (PK)      | Unique project ID (starts at 2000)  |
| ProjectName        | NVARCHAR(100) | Name of the project                 |
| ProjectDomain      | NVARCHAR(100) | Domain/Category of the project      |
| ProjectStartDate   | DATE          | Project start date                  |
| ProjectEndDate     | DATE          | Project end date                    |
| ProjectDescription | NVARCHAR(MAX) | Brief description of the project    |

---

### 3. `Status`
Defines the current state of a bug.

| Column Name | Data Type     | Description                        |
|-------------|---------------|------------------------------------|
| StatusId    | INT (PK)      | Unique status ID (starts at 3000)  |
| StatusName  | NVARCHAR(50)  | Status (`OPEN`, `IN PROGRESS`, `CLOSED`) |

---

### 4. `Bugs`
Stores individual bug records and links them to projects, reporters, assignees, and status.

| Column Name      | Data Type     | Description                            |
|------------------|---------------|----------------------------------------|
| BugId            | INT (PK)      | Unique bug ID (starts at 4000)         |
| BugName          | NVARCHAR(100) | Title of the bug                       |
| BugDescription   | NVARCHAR(MAX) | Detailed bug information               |
| BugReported      | DATE          | Date the bug was reported              |
| BugProjectId     | INT (FK)      | Project associated with the bug        |
| BugReportedBy    | NVARCHAR(100) | Name of the reporter (text field)      |
| BugAssignedTo    | INT (FK)      | User ID of the assigned developer/tester |
| BugStatus        | INT (FK)      | Status ID of the current bug state     |

---

## 📦 Sample Data

The database comes pre-loaded with:
- 4 users
- 3 projects
- 3 status types
- 4 bug entries

---

## 🛠️ Setup Instructions

1. Open SQL Server Management Studio (SSMS).
2. Run the full SQL script in a new query window:
   - Drops and recreates `BugTrackerDB`
   - Creates all tables with constraints
   - Inserts sample data

```sql
DROP DATABASE BugTrackerDB;
CREATE DATABASE BugTrackerDB;
-- (Then continue with the rest of the script)
````

---

## ✅ Features

* Enforces referential integrity using foreign keys.
* Ensures bug status is always valid (`CHECK` constraint).
* Uses `IDENTITY` columns for unique ID generation.
* Sample data helps in quick testing and development.

---


---

## OUTPUT


 **1. Users Table**

| UserId | UserName | UserEmail                                               | Role               |
| ------ | -------- | ------------------------------------------------------- | ------------------ |
| 1000   | HariRam  | [hariram.7405@gmail.com](mailto:hariram.7405@gmail.com) | Software Developer |
| 1001   | Mani     | [mani@gmail.com](mailto:mani@gmail.com)                 | Team Manager       |
| 1002   | Shiva    | [shiv3467@gmail.com](mailto:shiv3467@gmail.com)         | Tester             |
| 1003   | Priya    | [priya@gmail.com](mailto:priya@gmail.com)               | Developer          |

---

 **2. Projects Table**

| ProjectId | ProjectName   | ProjectDomain           | ProjectStartDate | ProjectEndDate | ProjectDescription                                                  |
| --------- | ------------- | ----------------------- | ---------------- | -------------- | ------------------------------------------------------------------- |
| 2000      | AI Analytics  | Artificial Intelligence | 2025-10-05       | 2025-12-05     | AI-powered analytics dashboard for real-time business intelligence. |
| 2001      | Smart 4.0     | IoT & Automation        | 2025-11-12       | 2025-12-12     | Smart automation platform integrating IoT devices.                  |
| 2002      | Issue Tracker | Software Tools          | 2024-10-11       | 2025-10-11     | Bug and issue tracking system for software teams.                   |

---

 **3. Status Table**

| StatusId | StatusName  |
| -------- | ----------- |
| 3000     | OPEN        |
| 3001     | IN PROGRESS |
| 3002     | CLOSED      |

---

 **4. Bugs Table**

| BugId | BugName          | BugDescription                                        | BugReported | BugProjectId | BugReportedBy | BugAssignedTo | BugStatus |
| ----- | ---------------- | ----------------------------------------------------- | ----------- | ------------ | ------------- | ------------- | --------- |
| 4000  | UI Overlap Issue | Buttons overlap on smaller screen resolutions.        | 2025-10-11  | 2000         | HariRam       | 1003          | 3000      |
| 4001  | Database Timeout | The database times out under high load.               | 2025-08-11  | 2001         | Mani          | 1002          | 3001      |
| 4002  | Login Failure    | Users unable to login after recent deployment.        | 2025-07-15  | 2002         | Priya         | 1000          | 3001      |
| 4003  | Email Not Sent   | Notification emails are not sent on new bug creation. | 2025-07-20  | 2000         | Shiva         | 1001          | 3002      |

---
