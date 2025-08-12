

# 🏨 Hostel Management System – Full Technical Documentation

## 1. Introduction

The **Hostel Management System** is a RESTful API built with **.NET 7** for managing **students, staff, and rooms** in a hostel environment.

It supports:

* Adding and retrieving students, staff, and rooms
* Automatic assignment of students to staff and rooms based on availability
* Capacity management to ensure no over-allocation of resources

The system uses **in-memory storage** for simplicity — ideal for prototypes, learning, and interview demonstrations.

---

## 2. Project Overview

**Purpose:**
To provide an API for hostel administrators to manage student allocations without manually tracking assignments.

**Core Idea:**
When a student is created:

* The system **automatically finds the first available staff member** (by capacity).
* The system **automatically finds the first available room** (by capacity).
* The student is assigned both at the time of creation.

---

## 3. Key Features

✅ **Automatic allocation** – No need to manually assign students to staff/rooms.

✅ **Capacity enforcement** – Prevents overfilling rooms or overloading staff.

✅ **In-memory storage** – No external database needed.

✅ **Swagger UI** – Fully documented endpoints.

✅ **Modular architecture** – Clean separation of layers.

---

## 4. Folder Structure

```
HostelManagement/
│
├── HostelManagement.API/                # API Layer - Entry point
│   ├── Controllers/                      # REST API controllers
│   │   ├── RoomController.cs
│   │   ├── StaffController.cs
│   │   └── StudentController.cs
│   │
│   ├── Program.cs                        # Application startup
│   ├── appsettings.json                  # Configurations
│   └── Properties/
│       └── launchSettings.json
│
├── HostelManagement.Core/                # Core Layer - Business models
│   ├── DTOs/                              # Request & Response DTOs
│   │   ├── RoomRequestDTO.cs
│   │   ├── RoomResponseDTO.cs
│   │   ├── StaffRequestDTO.cs
│   │   ├── StaffResponseDTO.cs
│   │   ├── StudentRequestDTO.cs
│   │   └── StudentResponseDTO.cs
│   │
│   ├── Entities/                          # Core domain models
│   │   ├── Room.cs
│   │   ├── Staff.cs
│   │   └── Student.cs
│   │
│   ├── Interfaces/                        # Abstractions for repos/services
│   │   ├── IRepository.cs
│   │   ├── IRoomService.cs
│   │   ├── IStaffService.cs
│   │   └── IStudentService.cs
│   │
│                         # Service interfaces (optional split)
│
├── HostelManagement.Infrastructure/      # Data Layer - Implementations
│   ├── Repositories/
│   │   ├── RoomRepository.cs
│   │   ├── StaffRepository.cs
│   │   └── StudentRepository.cs
│
├──---HostelManagement.Application
| ├── Services          
│ │  ├── RoomService.cs
│ │  ├── StaffService.cs
│ │  └── StudentService.cs
│
├── HostelManagement.sln                   # Solution file
└── README.md                              # Project documentation
```

---

## 5. System Architecture

### Layers

```
          ┌───────────────────────────┐
          │     Presentation Layer     │
          │ (HostelManagement.API)     │
          │────────────────────────────│
          │ Controllers:               │
          │ - RoomController           │
          │ - StaffController          │
          │ - StudentController        │
          └──────────────▲─────────────┘
                         │
                         │ Calls
                         ▼
          ┌───────────────────────────┐
          │ Application Layer          │
          │ (HostelManagement.Services)│
          │────────────────────────────│
          │ - RoomService              │
          │ - StaffService             │
          │ - StudentService           │
          │ Handles use cases & rules  │
          └──────────────▲─────────────┘
                         │
                         │ Depends on abstractions
                         ▼
          ┌───────────────────────────┐
          │ Domain Layer               │
          │ (HostelManagement.Core)    │
          │────────────────────────────│
          │ Entities:                  │
          │  - Room                    │
          │  - Staff                   │
          │  - Student                 │
          │ Interfaces:                │
          │  - IRepository             │
          │  - IRoomService            │
          │  - IStaffService           │
          │  - IStudentService         │
          │ DTOs for requests/responses│
          └──────────────▲─────────────┘
                         │
                         │ Implementations of abstractions
                         ▼
          ┌───────────────────────────┐
          │ Infrastructure Layer       │
          │ (HostelManagement.Infrastructure) │
          │────────────────────────────│
          │ - RoomRepository           │
          │ - StaffRepository          │
          │ - StudentRepository        │
          │ (In-memory or DB storage)  │
          └────────────────────────────┘
```


### Explanation

- **Presentation Layer (API):**  
  Handles incoming HTTP requests, delegates actions to Application Layer services.

- **Application Layer (Services):**  
  Contains business rules, orchestrates workflows, validates inputs, and uses Domain Layer interfaces.

- **Domain Layer (Core):**  
  Defines business entities, interfaces, and DTOs. Pure domain logic is isolated here.

- **Infrastructure Layer:**  
  Implements repository interfaces to interact with data storage (in-memory or database).


## Data Flow 

When a client interacts with the system (for example, creating a new student), the data flows as follows:

1. **Client Request:**  
   The client sends an HTTP POST request to the API endpoint (e.g., `/api/Student`).

2. **Presentation Layer:**  
   The `StudentController` receives the request and maps input data to a DTO.

3. **Application Layer:**  
   The controller calls `StudentService` to handle the business logic.

4. **Domain Layer:**  
   `StudentService` uses Domain Layer interfaces to apply business rules and validation.  
   It requests the first available staff and room that have free capacity.

5. **Infrastructure Layer:**  
   The service calls repository implementations (e.g., `StaffRepository`, `RoomRepository`) to retrieve and update data.

6. **Back through Layers:**  
   Data is processed, saved, and a response DTO is created.

7. **Response:**  
   The Presentation Layer returns the response to the client with status codes and data.



This layered flow ensures:

- **Separation of Concerns:** Each layer has a specific responsibility.  
- **Testability:** Business rules can be tested without dependencies on data storage or UI.  
- **Maintainability:** Layers can evolve independently.  
- **Flexibility:** Infrastructure can be swapped (e.g., from in-memory to a real database) without affecting core logic.

---


---

## 6. Entity Relationship Diagram (ERD)

```
   +---------+         +-----------+        +---------+
   |  Staff  |1-------<|  Student  |>-------1|  Room   |
   +---------+         +-----------+        +---------+
   | id      |         | id        |        | id      |
   | name    |         | name      |        | roomNum |
   | role    |         | department|        | capacity|
   | capacity|         | roomId    |        | students|
   | students|         | staffId   |        |         |
   +---------+         +-----------+        +---------+
```

### Relationships

1. **Staff to Student (One-to-Many):**  
   - One staff member can be assigned to many students.  
   - Each student is assigned to exactly one staff member.  
   - Represented by the `staffId` foreign key in the `Student` entity.  
   - The `capacity` property in `Staff` limits how many students a staff member can supervise.

2. **Room to Student (One-to-Many):**  
   - One room can accommodate many students (up to its capacity).  
   - Each student is assigned to exactly one room.  
   - Represented by the `roomId` foreign key in the `Student` entity.  
   - The `capacity` property in `Room` limits the number of students per room.




---

## 7. Entities & Data Models

### Student Entity

```csharp
public class Student {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public int StaffId { get; set; }
    public Staff Staff { get; set; }
}
```

### Staff Entity

```csharp
public class Staff {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Role { get; set; }
    public int Capacity { get; set; } = 5;
    public List<Student> Students { get; set; } = new List<Student>();
}
```

### Room Entity

```csharp
public class Room {
    public int Id { get; set; }
    public string RoomNumber { get; set; }
    public int Capacity { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
}
```

---

## 8. Business Rules

1. **Student Creation:**

   * Automatically assigns first available **staff** and **room**.
   * Checks that both have available capacity.

2. **Capacity Rules:**

   * Staff capacity defaults to **5** unless set manually.
   * Room capacity must be explicitly set when creating a room.
   * If no available staff/room → request fails with a descriptive error.

3. **Uniqueness:**

   * Room numbers are unique.
   * Staff names can repeat (though not recommended).
   * Student IDs auto-generate.

---

## 9. API Design

The API follows **REST principles**:

* **GET** → Retrieve resources
* **POST** → Create resources
* **JSON** request & response bodies
* **HTTP Status Codes** to indicate success/error

---

## 10. API Endpoints

### Room Endpoints

| Method | Endpoint         | Description       |
| ------ | ---------------- | ----------------- |
| POST   | `/api/Room`      | Create a new room |
| GET    | `/api/Room`      | Get all rooms     |
| GET    | `/api/Room/{id}` | Get a room by ID  |

### Staff Endpoints

| Method | Endpoint          | Description               |
| ------ | ----------------- | ------------------------- |
| POST   | `/api/Staff`      | Create a new staff member |
| GET    | `/api/Staff`      | Get all staff             |
| GET    | `/api/Staff/{id}` | Get staff by ID           |

### Student Endpoints

| Method | Endpoint            | Description                                      |
| ------ | ------------------- | ------------------------------------------------ |
| POST   | `/api/Student`      | Create a new student (auto-assigns staff & room) |
| GET    | `/api/Student`      | Get all students                                 |
| GET    | `/api/Student/{id}` | Get student by ID                                |

---

## 11. Request & Response Examples

### Create Room

**Request:**

```json
POST /api/Room
{
  "roomNumber": "121",
  "capacity": 4
}
```

**Response:**

```json
{
  "id": 2001,
  "roomNumber": "121",
  "capacity": 4,
  "studentNames": []
}
```

### Create Staff

**Request:**

```json
POST /api/Staff
{
  "name": "Ghella",
  "role": "warden",
  "capacity": 4
}
```

**Response:**

```json
{
  "id": 5001,
  "name": "Ghella",
  "role": "warden",
  "capacity": 4,
  "studentNames": []
}
```

### Create Student

**Request:**

```json
POST /api/Student
{
  "name": "Hari",
  "department": "IT"
}
```

**Response:**

```json
{
  "id": 1001,
  "name": "Hari",
  "department": "IT",
  "roomId": 2001,
  "roomNumber": "121",
  "staffId": 5001,
  "staffName": "Ghella"
}
```

---

## 12. Data Flow Example

```
User POST /api/Student {"name":"Hari","department":"IT"}
        |
        v
StudentController → StudentService
        |
        v
Find first staff with Students.Count < Capacity
Find first room with Students.Count < Capacity
        |
        v
Assign staffId & roomId to new student
Save to in-memory repository
        |
        v
Return StudentResponse DTO
```

---

## 13. Technology Stack

* **Language:** C# (.NET 7)
* **Framework:** ASP.NET Core Web API
* **Documentation:** Swagger / OpenAPI 3.0
* **Storage:** In-memory collections
* **Tools:** Visual Studio / VS Code, Postman, Swagger UI

---

## 14. Setup & Running the Project

1. Clone the repository:

```bash
git clone https://github.com/example/HostelManagement.git
```

2. Open in Visual Studio or VS Code.

3. Run:

```bash
dotnet run --project HostelManagement.API
```

4. Access Swagger UI:

```
https://localhost:7126/swagger/index.html
```

---

## 15. Future Improvements

* [ ] Use **Entity Framework Core** with a database
* [ ] Add **PUT** and **DELETE** endpoints
* [ ] Implement authentication & authorization
* [ ] Add search & filtering for students
* [ ] Improve allocation strategy (round-robin / least-load)

---

## 16. Author
Hari Ram L