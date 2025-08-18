# 🏨 Hostel Management System



## 🎯 Overview

The **Hostel Management System** is a comprehensive RESTful API built with **.NET 8** that streamlines hostel operations by automating student allocation, staff management, and room assignments. The system eliminates manual tracking overhead and ensures optimal resource utilization through intelligent capacity management.

### Key Benefits
- **Automated Allocation**: Students are automatically assigned to available staff and rooms
- **Capacity Management**: Prevents overbooking and ensures balanced workload distribution
- **Real-time Tracking**: Monitor occupancy and staff assignments in real-time
- **Scalable Architecture**: Clean architecture pattern supports future enhancements
- **Developer Friendly**: Comprehensive Swagger documentation and clear API contracts

## ✨ Features

### Core Functionality
- ✅ **Student Management**: Create, read, update, delete student records
- ✅ **Staff Management**: Manage staff members with capacity-based assignments
- ✅ **Room Management**: Handle room allocation with occupancy limits
- ✅ **Auto-Assignment**: Intelligent allocation based on availability
- ✅ **Capacity Enforcement**: Prevent over-allocation of resources
- ✅ **RESTful API**: Standard HTTP methods with proper status codes

### Advanced Features
- 🔄 **Relationship Management**: Maintain referential integrity between entities
- 📊 **Occupancy Tracking**: Real-time capacity monitoring
- 🔍 **Data Validation**: Comprehensive input validation and error handling
- 📖 **API Documentation**: Interactive Swagger UI for testing
- 🏗️ **Modular Design**: Layered architecture for maintainability

## 🏗️ Architecture


```
┌─────────────────────────────────────────────────────────────┐
│                    Presentation Layer                        │
│                 (HostelManagement.API)                      │
│  ┌─────────────┐ ┌─────────────┐ ┌─────────────────────────┐ │
│  │   Student   │ │    Staff    │ │        Room             │ │
│  │ Controller  │ │ Controller  │ │     Controller          │ │
│  └─────────────┘ └─────────────┘ └─────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                   Application Layer                          │
│               (HostelManagement.Application)                │
│  ┌─────────────┐ ┌─────────────┐ ┌─────────────────────────┐ │
│  │   Student   │ │    Staff    │ │        Room             │ │
│  │   Service   │ │   Service   │ │       Service           │ │
│  └─────────────┘ └─────────────┘ └─────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                     Core Layer                            │
│                 (HostelManagement.Core)                     │
│  ┌─────────────┐ ┌─────────────┐ ┌─────────────────────────┐ │
│  │  Entities   │ │ Interfaces  │ │         DTOs            │ │
│  │             │ │             │ │                         │ │
│  └─────────────┘ └─────────────┘ └─────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                 Infrastructure Layer                        │
│             (HostelManagement.Infrastructure)               │
│  ┌─────────────┐ ┌─────────────┐ ┌─────────────────────────┐ │
│  │   Student   │ │    Staff    │ │        Room             │ │
│  │ Repository  │ │ Repository  │ │     Repository          │ │
│  └─────────────┘ └─────────────┘ └─────────────────────────┘ │
└─────────────────────────────────────────────────────────────┘
```

### Layer Responsibilities

#### 🎨 Presentation Layer (API)
- HTTP request/response handling
- Input validation and model binding
- Authentication and authorization
- API versioning and documentation

#### 🔧 Application Layer (Services)
- Business logic implementation
- Use case orchestration
- Data transformation (Entity ↔ DTO)
- Transaction management

#### 🏛️ Domain Layer (Core)
- Business entities and value objects
- Domain interfaces and contracts
- Business rules and validations
- Domain events

#### 💾 Infrastructure Layer
- Data access implementation
- External service integrations
- Caching mechanisms
- Logging and monitoring

## 🛠️ Technology Stack

### Backend Technologies
- **Framework**: .NET 8.0
- **API**: ASP.NET Core Web API
- **Dependency Injection**: Built-in DI Container
- **Documentation**: Swagger/OpenAPI 3.0

### Development Tools
- **IDE**: Visual Studio 2022 / VS Code
- **Testing**: Postman, Swagger UI
- **Version Control**: Git
- **Package Manager**: NuGet

### Data Storage
- **Current**: In-Memory Collections
- **Future**: Entity Framework Core + SQL Server

## 📁 Project Structure

```
HostelManagement/
├── 📂 HostelManagement.API/              # 🎯 Entry Point
│   ├── 📂 Controllers/                    # API Controllers
│   │   ├── 📄 StudentController.cs        # Student endpoints
│   │   ├── 📄 StaffController.cs          # Staff endpoints
│   │   └── 📄 RoomController.cs           # Room endpoints
│   ├── 📂 Properties/
│   │   └── 📄 launchSettings.json         # Launch configuration
│   ├── 📄 Program.cs                      # Application startup
│   ├── 📄 appsettings.json               # Configuration
│   └── 📄 appsettings.Development.json   # Dev configuration
│
├── 📂 HostelManagement.Application/       # 🔧 Business Logic
│   └── 📂 Services/                       # Service implementations
│       ├── 📄 StudentService.cs           # Student business logic
│       ├── 📄 StaffService.cs             # Staff business logic
│       └── 📄 RoomService.cs              # Room business logic
│
├── 📂 HostelManagement.Core/              # 🏛️ Domain Layer
│   ├── 📂 Entities/                       # Domain models
│   │   ├── 📄 Student.cs                  # Student entity
│   │   ├── 📄 Staff.cs                    # Staff entity
│   │   └── 📄 Room.cs                     # Room entity
│   ├── 📂 DTOs/                          # Data transfer objects
│   │   ├── 📄 StudentRequestDTO.cs        # Student input model
│   │   ├── 📄 StudentResponseDTO.cs       # Student output model
│   │   ├── 📄 StaffRequestDTO.cs          # Staff input model
│   │   ├── 📄 StaffResponseDTO.cs         # Staff output model
│   │   ├── 📄 RoomRequestDTO.cs           # Room input model
│   │   └── 📄 RoomResponseDTO.cs          # Room output model
│   └── 📂 Interfaces/                     # Contracts
│       ├── 📄 IRepository.cs              # Generic repository
│       ├── 📄 IStudentService.cs          # Student service contract
│       ├── 📄 IStaffService.cs            # Staff service contract
│       └── 📄 IRoomService.cs             # Room service contract
│
├── 📂 HostelManagement.Infrastructure/    # 💾 Data Layer
│   └── 📂 Repositories/                   # Data access
│       ├── 📄 StudentRepository.cs        # Student data operations
│       ├── 📄 StaffRepository.cs          # Staff data operations
│       └── 📄 RoomRepository.cs           # Room data operations
│
├── 📄 HostelManagement.sln               # Solution file
└── 📄 README.md                          # Documentation
```

## 🚀 Getting Started

### Prerequisites
- **.NET 8 SDK** or later
- **Visual Studio 2022** or **VS Code**
- **Git** for version control
- **Postman** (optional, for API testing)

### Installation Steps

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/HostelManagement.git
   cd HostelManagement
   ```

2. **Restore Dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the Solution**
   ```bash
   dotnet build
   ```

4. **Run the Application**
   ```bash
   dotnet run --project HostelManagement.API
   ```

5. **Access Swagger UI**
   ```
   https://localhost:7126/swagger/index.html
   ```

### Development Setup

1. **Configure Development Environment**
   ```json
   // appsettings.Development.json
   {
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft.AspNetCore": "Warning"
       }
     }
   }
   ```

2. **Enable Hot Reload** (Visual Studio)
   - Debug → Start Without Debugging (Ctrl+F5)
   - Changes will be automatically applied

## 📚 API Documentation

### Base URL
```
https://localhost:7126/api
```

### Authentication
Currently, no authentication is required. Future versions will implement JWT-based authentication.

### Common Response Codes
- `200 OK` - Successful GET request
- `201 Created` - Successful POST request
- `204 No Content` - Successful PUT/DELETE request
- `400 Bad Request` - Invalid input data
- `404 Not Found` - Resource not found
- `409 Conflict` - Resource conflict (e.g., deleting assigned staff)



---
## **API Endpoints** 

### 🏠 Room Endpoints

| Method | Endpoint         | Description                    |
| ------ | ---------------- | ------------------------------ |
| GET    | `/api/Room`      | Get all rooms                  |
| GET    | `/api/Room/{id}` | Get a specific room by ID      |
| POST   | `/api/Room`      | Create a new room              |
| PUT    | `/api/Room/{id}` | Update an existing room        |
| DELETE | `/api/Room/{id}` | Delete a room (if unallocated) |

---

### 👨‍🏫 Staff Endpoints

| Method | Endpoint          | Description                |
| ------ | ----------------- | -------------------------- |
| GET    | `/api/Staff`      | Get all staff              |
| GET    | `/api/Staff/{id}` | Get a specific staff by ID |
| POST   | `/api/Staff`      | Create a new staff         |
| PUT    | `/api/Staff/{id}` | Update an existing staff   |
| DELETE | `/api/Staff/{id}` | Delete a staff member      |

---

### 👨‍🎓 Student Endpoints

| Method | Endpoint            | Description                                        |
| ------ | ------------------- | -------------------------------------------------- |
| GET    | `/api/Student`      | Get all students                                   |
| GET    | `/api/Student/{id}` | Get a specific student by ID                       |
| POST   | `/api/Student`      | Create a new student (auto allocates room & staff) |
| PUT    | `/api/Student/{id}` | Update an existing student                         |
| DELETE | `/api/Student/{id}` | Delete a student                                   |
---
## API Output


## 🏠 Room Endpoints

---

### ✅ `GET /api/Room`

**📤 Response**

```json
[
  {
    "id": 2001,
    "roomNumber": "101A",
    "capacity": 4,
    "studentNames": ["mani", "SHIVA", "Sham", "Naveen"]
  },
  {
    "id": 2002,
    "roomNumber": "102A",
    "capacity": 3,
    "studentNames": ["Sasi"]
  }
]
```

---

### ✅ `GET /api/Room/{id}`

**Example: `GET /api/Room/2001`**

**📤 Response**

```json
{
  "id": 2001,
  "roomNumber": "101A",
  "capacity": 4,
  "studentNames": ["mani", "SHIVA", "Sham", "Naveen"]
}
```

---

### ✅ `POST /api/Room`

**📥 Request**

```json
{
  "roomNumber": "102A",
  "capacity": 3
}
```

**📤 Response**

```json
{
  "id": 2002,
  "roomNumber": "102A",
  "capacity": 3,
  "studentNames": []
}
```

---

### ✅ `PUT /api/Room/{id}`

**Example: `PUT /api/Room/2002`**

**📥 Request**

```json
{
  "roomNumber": "102A",
  "capacity": 2
}
```

**📤 Response Code:** `204 No Content` (successful update, no body)

---

### ✅ `DELETE /api/Room/{id}`

**Example: `DELETE /api/Room/2002`**

If the room is allocated:

**📤 Response**

```json
{
  "error": "Room is allocated to student.Room cannot be deleted"
}
```

If unallocated, response is:

**📤 Response Code:** `204 No Content`

---

## 👨‍🏫 Staff Endpoints

---

### ✅ `GET /api/Staff`

**📤 Response**

```json
[
  {
    "id": 5001,
    "name": "Praveen",
    "role": "Warden",
    "capacity": 5,
    "studentNames": ["mani", "SHIVA", "Sham", "Naveen", "Sasi"]
  },
  {
    "id": 5002,
    "name": "Praneesh",
    "role": "Warden",
    "capacity": 5,
    "studentNames": []
  }
]
```

---

### ✅ `GET /api/Staff/{id}`

**Example: `GET /api/Staff/5003`**

**📤 Response**

```json
{
  "id": 5003,
  "name": "Shiva Sankar",
  "role": "Warden",
  "capacity": 5,
  "studentNames": []
}
```

---

### ✅ `POST /api/Staff`

**📥 Request**

```json
{
  "name": "Shiva Sankar",
  "role": "Warden"
}
```

**📤 Response**

```json
{
  "id": 5003,
  "name": "Shiva Sankar",
  "role": "Warden",
  "capacity": 5,
  "studentNames": []
}
```

---

### ✅ `PUT /api/Staff/{id}`

**Example: `PUT /api/Staff/5001`**

**📥 Request**

```json
{
  "name": "Praveen K",
  "role": "Deputy Warden"
}
```

**📤 Response Code:** `204 No Content`

---

### ✅ `DELETE /api/Staff/{id}`

**Example: `DELETE /api/Staff/5003`**

**📤 Response Code:** `204 No Content`

---

## 👨‍🎓 Student Endpoints

---

### ✅ `GET /api/Student`

**📤 Response**

```json
[
  {
    "id": 1001,
    "name": "mani",
    "department": "IT",
    "roomId": 2001,
    "roomNumber": "101A",
    "staffId": 5001,
    "staffName": "Praveen"
  },
  {
    "id": 1002,
    "name": "SHIVA",
    "department": "IT",
    "roomId": 2001,
    "roomNumber": "101A",
    "staffId": 5001,
    "staffName": "Praveen"
  },
  {
    "id": 1003,
    "name": "Sham",
    "department": "IT",
    "roomId": 2001,
    "roomNumber": "101A",
    "staffId": 5001,
    "staffName": "Praveen"
  },
  {
    "id": 1004,
    "name": "Naveen",
    "department": "IT",
    "roomId": 2001,
    "roomNumber": "101A",
    "staffId": 5001,
    "staffName": "Praveen"
  },
  {
    "id": 1005,
    "name": "Raju",
    "department": "IT",
    "roomId": 2002,
    "roomNumber": "102A",
    "staffId": 5001,
    "staffName": "Praveen"
  },
  {
    "id": 1006,
    "name": "Rakesh",
    "department": "ECE",
    "roomId": 2002,
    "roomNumber": "102A",
    "staffId": 5002,
    "staffName": "Praneesh"
  }
]
```

---

### ✅ `GET /api/Student/{id}`

**Example: `GET /api/Student/1006`**

**📤 Response**

```json
{
  "id": 1006,
  "name": "Rakesh",
  "department": "ECE",
  "roomId": 2002,
  "roomNumber": "102A",
  "staffId": 5002,
  "staffName": "Praneesh"
}
```

---

### ✅ `POST /api/Student`

**📥 Request**

```json
{
  "name": "Rakesh",
  "department": "ECE"
}
```

**📤 Response**

```json
{
  "id": 1006,
  "name": "Rakesh",
  "department": "ECE",
  "roomId": 2002,
  "roomNumber": "102A",
  "staffId": 5002,
  "staffName": "Praneesh"
}
```

---

### ✅ `PUT /api/Student/{id}`

**Example: `PUT /api/Student/1005`**

**📥 Request**

```json
{
  "name": "Sasi",
  "department": "CSE"
}
```

**📤 Response Code:** `204 No Content`

---

### ✅ `DELETE /api/Student/{id}`

**Example: `DELETE /api/Student/1006`**

**📤 Response Code:** `204 No Content`
---



## 🗄️ Database Design

### Entity Relationship Diagram
```
┌─────────────────┐         ┌─────────────────┐         ┌─────────────────┐
│      Staff      │         │     Student     │         │      Room       │
├─────────────────┤         ├─────────────────┤         ├─────────────────┤
│ Id (PK)         │◄────────┤ Id (PK)         ├────────►│ Id (PK)         │
│ Name            │    1:N  │ Name            │   N:1   │ RoomNumber      │
│ Role            │         │ Department      │         │ Capacity        │
│ Capacity        │         │ StaffId (FK)    │         │                 │
│                 │         │ RoomId (FK)     │         │                 │
└─────────────────┘         └─────────────────┘         └─────────────────┘
```

### Entity Specifications

#### Student Entity
- **Primary Key**: Id (auto-generated)
- **Required Fields**: Name, Department
- **Foreign Keys**: StaffId, RoomId
- **Relationships**: Many-to-One with Staff and Room

#### Staff Entity
- **Primary Key**: Id (auto-generated)
- **Required Fields**: Name, Role
- **Default Capacity**: 5 students
- **Relationships**: One-to-Many with Students

#### Room Entity
- **Primary Key**: Id (auto-generated)
- **Required Fields**: RoomNumber, Capacity
- **Unique Constraint**: RoomNumber
- **Relationships**: One-to-Many with Students

## 🧠 Business Logic

### Student Allocation Algorithm

1. **Validation Phase**
   - Verify required fields (Name, Department)
   - Check for null/empty values

2. **Staff Assignment**
   - Query available staff (Students.Count < Capacity)
   - Order by Id (First-Come-First-Served)
   - Select first available staff member

3. **Room Assignment**
   - Query available rooms (Students.Count < Capacity)
   - Order by Id (Sequential allocation)
   - Select first available room

4. **Assignment Execution**
   - Create student entity
   - Update staff and room collections
   - Persist changes

### Capacity Management Rules

- **Staff Capacity**: Default 5, configurable per staff member
- **Room Capacity**: Must be explicitly set during creation
- **Allocation Priority**: First available resource by ID
- **Constraint Enforcement**: No over-allocation allowed

### Error Handling Strategy

- **Validation Errors**: Return 400 Bad Request with details
- **Resource Not Found**: Return 404 Not Found
- **Business Rule Violations**: Return 409 Conflict
- **System Errors**: Return 500 Internal Server Error (logged)

## ⚙️ Configuration

### Application Settings
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Service Registration
```csharp
// Program.cs
builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Staff>, StaffRepository>();
builder.Services.AddScoped<IRepository<Room>, RoomRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IRoomService, RoomService>();
```

## 🧪 Testing

### Manual Testing with Swagger
1. Navigate to `https://localhost:7126/swagger`
2. Create a staff member and room first
3. Create a student (auto-assigned to staff and room)
4. Verify assignments in GET responses



### Test Scenarios
- ✅ Successful student creation with auto-assignment
- ✅ Capacity limit enforcement
- ✅ Error handling for invalid inputs
- ✅ CRUD operations for all entities
- ✅ Relationship integrity maintenance



## 🔧 Troubleshooting

### Common Issues

#### Port Already in Use
```bash
# Find process using port 7126
netstat -ano | findstr :7126
# Kill the process
taskkill /PID <process_id> /F
```



#### Auto-Assignment Failures
- Verify staff and rooms exist before creating students
- Check capacity limits are not exceeded
- Ensure proper service registration in DI container



---


**Author**: Hari Ram L