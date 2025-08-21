# 🏨 Hostel Management System

## 🎯 Overview
The Hostel Management System is a comprehensive solution built with .NET 8 that provides both **RESTful API** and **MVC Web Application** interfaces for streamlining hostel operations. The system automates student allocation, staff management, and room assignments while offering both programmatic API access and user-friendly web interface.

### Key Benefits
- **Dual Interface**: RESTful API for integration + MVC Web App for user interaction
- **Automated Allocation**: Students are automatically assigned to available staff and rooms
- **Capacity Management**: Prevents overbooking and ensures balanced workload distribution
- **Real-time Tracking**: Monitor occupancy and staff assignments in real-time
- **Clean Architecture**: Layered architecture pattern supports future enhancements
- **Exception Handling**: Comprehensive error handling with custom exceptions and global middleware
- **Developer Friendly**: Comprehensive Swagger documentation and intuitive web interface

## ✨ Features

### Core Functionality
✅ **Student Management**: Create, read, update, delete student records  
✅ **Staff Management**: Manage staff members with capacity-based assignments  
✅ **Room Management**: Handle room allocation with occupancy limits  
✅ **Auto-Assignment**: Intelligent allocation based on availability  
✅ **Capacity Enforcement**: Prevent over-allocation of resources  
✅ **RESTful API**: Standard HTTP methods with proper status codes  
✅ **MVC Web Interface**: User-friendly web application for data management  

### Advanced Features
🔄 **Relationship Management**: Maintain referential integrity between entities  
📊 **Occupancy Tracking**: Real-time capacity monitoring  
🔍 **Data Validation**: Comprehensive input validation and error handling  
🚨 **Exception Handling**: Custom exceptions with global middleware for consistent error responses  
📖 **API Documentation**: Interactive Swagger UI for testing  
🌐 **Web Interface**: Responsive MVC application with Bootstrap styling  
🏗️ **Modular Design**: Layered architecture for maintainability  
🛡️ **Error Management**: Structured error responses with correlation IDs for debugging  

## 🏗️ Architecture

The system follows **Clean Architecture** principles with clear separation of concerns:

```
┌─────────────────────────────────────────────────────────────┐
│                    Presentation Layer                        │
│            (API Controllers + MVC Controllers)              │
│  ┌─────────────┐ ┌─────────────┐ ┌─────────────────────────┐ │
│  │   Student   │ │    Staff    │ │        Room             │ │
│  │ Controllers │ │ Controllers │ │     Controllers         │ │
│  │ (API + MVC) │ │ (API + MVC) │ │     (API + MVC)         │ │
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
│                     Core Layer                              │
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

🎨 **Presentation Layer**
- **API Controllers**: HTTP request/response handling, Swagger documentation
- **MVC Controllers**: Web page rendering, form handling, user interaction
- Input validation and model binding
- Authentication and authorization

🔧 **Application Layer (Services)**
- Business logic implementation
- Use case orchestration
- Data transformation (Entity ↔ DTO)
- Transaction management

🏛️ **Domain Layer (Core)**
- Business entities and value objects
- Domain interfaces and contracts
- Business rules and validations
- Domain events

💾 **Infrastructure Layer**
- Data access implementation
- External service integrations
- Caching mechanisms
- Logging and monitoring

## 🛠️ Technology Stack

### Backend Technologies
- **Framework**: .NET 8.0
- **API**: ASP.NET Core Web API
- **MVC**: ASP.NET Core MVC
- **Database**: Entity Framework Core + SQL Server
- **Dependency Injection**: Built-in DI Container
- **Documentation**: Swagger/OpenAPI 3.0

### Frontend Technologies (MVC)
- **UI Framework**: Bootstrap 5
- **JavaScript**: jQuery
- **CSS**: Custom styling with Bootstrap
- **Validation**: Client-side and server-side validation

### Development Tools
- **IDE**: Visual Studio 2022 / VS Code
- **Testing**: Postman, Swagger UI, Browser testing
- **Version Control**: Git
- **Package Manager**: NuGet

## 📁 Project Structure

```
Solution1/
├── 📂 HostelManagement.API/              # 🎯 RESTful API
│   ├── 📂 Controllers/                    # API Controllers
│   │   ├── 📄 StudentController.cs        # Student API endpoints
│   │   ├── 📄 StaffController.cs          # Staff API endpoints
│   │   └── 📄 RoomController.cs           # Room API endpoints
│   ├── 📂 Middleware/                     # Custom middleware
│   │   └── 📄 GlobalExceptionMiddleware.cs # Global exception handler
│   ├── 📂 Extension/                      # Extension methods
│   │   └── 📄 MiddlewareExtension.cs      # Middleware registration
│   ├── 📄 Program.cs                      # API startup configuration
│   └── 📄 appsettings.json               # API configuration
│
├── 📂 HostelManagement.MVC/               # 🌐 Web Application
│   ├── 📂 Controllers/                    # MVC Controllers
│   │   ├── 📄 HomeController.cs           # Home page controller
│   │   ├── 📄 StudentViewController.cs    # Student web interface
│   │   ├── 📄 StaffViewController.cs      # Staff web interface
│   │   └── 📄 RoomViewController.cs       # Room web interface
│   ├── 📂 Models/                         # View Models
│   │   ├── 📄 StudentViewModel.cs         # Student display model
│   │   ├── 📄 StaffViewModel.cs           # Staff display model
│   │   └── 📄 RoomViewModel.cs            # Room display model
│   ├── 📂 Views/                          # Razor Views
│   │   ├── 📂 Home/                       # Home page views
│   │   ├── 📂 StudentView/                # Student management views
│   │   ├── 📂 StaffView/                  # Staff management views
│   │   ├── 📂 RoomView/                   # Room management views
│   │   └── 📂 Shared/                     # Shared layout and partials
│   ├── 📂 wwwroot/                        # Static files
│   │   ├── 📂 css/                        # Stylesheets
│   │   ├── 📂 js/                         # JavaScript files
│   │   └── 📂 lib/                        # Client libraries
│   └── 📄 Program.cs                      # MVC startup configuration
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
│   │   ├── 📄 RoomResponseDTO.cs          # Room output model
│   │   └── 📄 ErrorResponseDTO.cs         # Error response model
│   ├── 📂 Exceptions/                     # Custom exceptions
│   │   ├── 📄 NotFoundException.cs        # Resource not found
│   │   ├── 📄 ValidationException.cs      # Input validation errors
│   │   ├── 📄 RoomFullException.cs        # Room capacity exceeded
│   │   ├── 📄 RoomHasStudentsException.cs # Room deletion conflict
│   │   ├── 📄 StaffOverloadException.cs   # Staff capacity exceeded
│   │   ├── 📄 StaffHasStudentsException.cs # Staff deletion conflict
│   │   ├── 📄 DeleteOperationException.cs # General deletion conflicts
│   │   └── 📄 StudentNotAssignedException.cs # Assignment failures
│   └── 📂 Interfaces/                     # Contracts
│       ├── 📄 IRepository.cs              # Generic repository
│       ├── 📄 IStudentService.cs          # Student service contract
│       ├── 📄 IStaffService.cs            # Staff service contract
│       └── 📄 IRoomService.cs             # Room service contract
│
├── 📂 HostelManagement.Infrastructure/    # 💾 Data Layer
│   ├── 📂 Data/                          # Database context
│   │   └── 📄 AppDBContext.cs            # Entity Framework context
│   ├── 📂 Migrations/                    # Database migrations
│   └── 📂 Repositories/                  # Data access
│       ├── 📄 StudentRepository.cs        # Student data operations
│       ├── 📄 StaffRepository.cs          # Staff data operations
│       └── 📄 RoomRepository.cs           # Room data operations
│
├── 📄 HostelManagement.sln               # Solution file
└── 📄 README.md                          # This documentation
```

## 🚀 Getting Started

### Prerequisites
- **.NET 8 SDK** or later
- **Visual Studio 2022** or VS Code
- **SQL Server** (LocalDB or full instance)
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

3. **Update Database Connection**
   ```json
   // appsettings.json (both API and MVC projects)
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HostelManagementDB;Trusted_Connection=true;"
     }
   }
   ```

4. **Apply Database Migrations**
   ```bash
   dotnet ef database update --project HostelManagement.Infrastructure --startup-project HostelManagement.API
   ```

5. **Build the Solution**
   ```bash
   dotnet build
   ```

6. **Run the Applications**

   **Option A: Run API Only**
   ```bash
   dotnet run --project HostelManagement.API
   ```
   Access Swagger UI: `https://localhost:7074/swagger`

   **Option B: Run MVC Only**
   ```bash
   dotnet run --project HostelManagement.MVC
   ```
   Access Web App: `https://localhost:7126`

   **Option C: Run Both (Recommended)**
   - Start API first: `dotnet run --project HostelManagement.API`
   - Start MVC in new terminal: `dotnet run --project HostelManagement.MVC`

## 🌐 MVC Web Application

### Features
- **Responsive Design**: Bootstrap-based UI that works on all devices
- **Intuitive Navigation**: Easy-to-use interface for managing hostel data
- **Real-time Data**: Consumes API endpoints for live data display
- **Form Validation**: Client and server-side validation
- **Error Handling**: User-friendly error messages and pages

### MVC Architecture Components

#### Controllers
- **HomeController**: Landing page and general navigation
- **StudentViewController**: Student management interface
- **StaffViewController**: Staff management interface  
- **RoomViewController**: Room management interface

#### Models (ViewModels)
- **StudentViewModel**: Student data for views
- **StaffViewModel**: Staff data for views
- **RoomViewModel**: Room data for views

#### Views
- **Shared Layout**: Common header, navigation, and footer
- **Index Views**: List all entities with search and filter
- **Details Views**: Show detailed information for specific entities
- **Responsive Design**: Mobile-friendly interface

### MVC Configuration
```csharp
// Program.cs (MVC)
builder.Services.AddControllersWithViews();

// HttpClient for API communication
builder.Services.AddHttpClient("HostelAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7074/api/");
});

// Routing configuration
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

### Web Interface URLs
- **Home**: `https://localhost:7126/`
- **Students**: `https://localhost:7126/StudentView`
- **Staff**: `https://localhost:7126/StaffView`
- **Rooms**: `https://localhost:7126/RoomView`

## 📚 API Documentation

### Base URL
```
https://localhost:7074/api
```

### Authentication
Currently, no authentication is required. Future versions will implement JWT-based authentication.

### Common Response Codes
- `200 OK` - Successful GET request
- `201 Created` - Successful POST request
- `204 No Content` - Successful PUT/DELETE request
- `400 Bad Request` - Validation errors (ValidationException)
- `404 Not Found` - Resource not found (NotFoundException)
- `409 Conflict` - Business rule violations (capacity/assignment conflicts)
- `422 Unprocessable Entity` - Assignment failures
- `500 Internal Server Error` - System errors

### Error Response Format
All errors return a structured ErrorResponseDTO:
```json
{
  "correlationId": "unique-request-id",
  "statusCode": 400,
  "message": "Validation failed",
  "details": "Stack trace (development only)"
}
```



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
    "roomId": 2001,
    "roomNumber": "101A",
    "capacity": 4,
    "students": ["mani", "SHIVA", "Sham", "Naveen"]
  },
  {
    "roomId": 2002,
    "roomNumber": "102A",
    "capacity": 3,
    "students": ["Sasi"]
  }
]
```

---

### ✅ `GET /api/Room/{id}`

**Example: `GET /api/Room/2001`**

**📤 Response (Success)**

```json
{
  "roomId": 2001,
  "roomNumber": "101A",
  "capacity": 4,
  "students": ["mani", "SHIVA", "Sham", "Naveen"]
}
```

**📤 Response (Not Found)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 404,
  "message": "Room not found",
  "details": null
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

**📤 Response (Success)**

```json
{
  "roomId": 2002,
  "roomNumber": "102A",
  "capacity": 3,
  "students": []
}
```

**📤 Response (Validation Error)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 400,
  "message": "Room Number is Required",
  "details": null
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

**📤 Response (Success)**

```json
{
  "roomId": 2002,
  "roomNumber": "102A",
  "capacity": 2,
  "students": ["Sasi"]
}
```

**📤 Response (Room Not Found)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 404,
  "message": "Room not found",
  "details": null
}
```
---

### ✅ `DELETE /api/Room/{id}`

**Example: `DELETE /api/Room/2002`**

**📤 Response (Success):** `204 No Content`

**📤 Response (Room Has Students)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 409,
  "message": "Room is allocated to student.Room cannot be deleted",
  "details": null
}
```

**📤 Response (Room Not Found)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 404,
  "message": "Room not found",
  "details": null
}
```
---

## 👨‍🏫 Staff Endpoints

---

### ✅ `GET /api/Staff`

**📤 Response**

```json
[
  {
    "staffId": 5001,
    "name": "Praveen",
    "role": "Warden",
    "students": ["mani", "SHIVA", "Sham", "Naveen", "Sasi"]
  },
  {
    "staffId": 5002,
    "name": "Praneesh",
    "role": "Warden",
    "students": []
  }
]
```

---

### ✅ `GET /api/Staff/{id}`

**Example: `GET /api/Staff/5003`**

**📤 Response (Success)**

```json
{
  "staffId": 5003,
  "name": "Shiva Sankar",
  "role": "Warden",
  "students": []
}
```

**📤 Response (Not Found)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 404,
  "message": "Staff not found.",
  "details": null
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

**📤 Response (Success)**

```json
{
  "staffId": 5003,
  "name": "Shiva Sankar",
  "role": "Warden",
  "students": []
}
```

**📤 Response (Validation Error)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 400,
  "message": "Staff Name is required.",
  "details": null
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

**📤 Response (Success)**

```json
{
  "staffId": 5001,
  "name": "Praveen K",
  "role": "Deputy Warden",
  "students": ["mani", "SHIVA", "Sham", "Naveen", "Sasi"]
}
```

**📤 Response (Staff Not Found)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 404,
  "message": "Staff not found.",
  "details": null
}
```
---

### ✅ `DELETE /api/Staff/{id}`

**Example: `DELETE /api/Staff/5003`**

**📤 Response (Success):** `204 No Content`

**📤 Response (Staff Has Students)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 409,
  "message": "This staff member is assigned to students and cannot be deleted.",
  "details": null
}
```

**📤 Response (Staff Not Found)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 404,
  "message": "Staff not found.",
  "details": null
}
```
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

**📤 Response (Success)**

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

**📤 Response (Student Not Found)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 404,
  "message": "Student with the given ID not found.",
  "details": null
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

**📤 Response (Success)**

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

**📤 Response (No Available Staff)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 409,
  "message": "No available staff to assign",
  "details": null
}
```

**📤 Response (No Available Room)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 409,
  "message": "No available room to assign",
  "details": null
}
```

**📤 Response (Validation Error)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 400,
  "message": "Name is required",
  "details": null
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

**📤 Response (Success)**

```json
{
  "id": 1005,
  "name": "Sasi",
  "department": "CSE",
  "roomId": 2002,
  "roomNumber": "102A",
  "staffId": 5001,
  "staffName": "Praveen"
}
```

**📤 Response (Student Not Found)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 404,
  "message": "Student with the given ID not found.",
  "details": null
}
```
---

### ✅ `DELETE /api/Student/{id}`

**Example: `DELETE /api/Student/1006`**

**📤 Response (Success):** `204 No Content`

**📤 Response (Student Not Found)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 404,
  "message": "Student with the given ID not found.",
  "details": null
}
```
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

#### Custom Exception Types
- **ValidationException**: Input validation failures (400 Bad Request)
- **NotFoundException**: Resource not found (404 Not Found)
- **RoomFullException**: No available rooms (409 Conflict)
- **StaffOverloadException**: No available staff (409 Conflict)
- **RoomHasStudentsException**: Room deletion conflicts (409 Conflict)
- **StaffHasStudentsException**: Staff deletion conflicts (409 Conflict)
- **DeleteOperationException**: General deletion conflicts (409 Conflict)
- **StudentNotAssignedException**: Assignment failures (422 Unprocessable Entity)
- **System Errors**: Unexpected errors (500 Internal Server Error)

#### Global Exception Middleware
- **Centralized Handling**: All exceptions processed through GlobalExceptionMiddleware
- **Structured Responses**: Consistent ErrorResponseDTO format
- **Correlation IDs**: Unique identifiers for request tracking
- **Environment-Aware**: Detailed stack traces in development only
- **Comprehensive Logging**: All exceptions logged with context
## ⚙️ Configuration

### API Configuration
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HostelManagementDB;Trusted_Connection=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### MVC Configuration
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HostelManagementDB;Trusted_Connection=true;"
  },
  "ApiSettings": {
    "BaseUrl": "https://localhost:7074/api/"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

### Service Registration
```csharp
// API Program.cs
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Staff>, StaffRepository>();
builder.Services.AddScoped<IRepository<Room>, RoomRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IRoomService, RoomService>();

// MVC Program.cs
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("HostelAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7074/api/");
});
```

## 🧪 Testing

### Manual Testing Options

#### 1. API Testing with Swagger
- Navigate to `https://localhost:7074/swagger`
- Create staff member and room first
- Create student (auto-assigned to staff and room)
- Verify assignments in GET responses

#### 2. Web Interface Testing
- Navigate to `https://localhost:7126`
- Use the web interface to manage students, staff, and rooms
- Test form validation and error handling
- Verify responsive design on different screen sizes

#### 3. Integration Testing
- Start both API and MVC applications
- Verify MVC app correctly consumes API endpoints
- Test data consistency between API and web interface

### Test Scenarios
✅ Successful student creation with auto-assignment  
✅ Capacity limit enforcement  
✅ Error handling for invalid inputs  
✅ CRUD operations for all entities  
✅ Relationship integrity maintenance  
✅ Web interface functionality  
✅ API-MVC integration  

## 🔧 Troubleshooting

### Common Issues

#### Port Already in Use
```bash
# Find process using port
netstat -ano | findstr :7074  # For API
netstat -ano | findstr :7126  # For MVC

# Kill the process
taskkill /PID <process_id> /F
```

#### Auto-Assignment Failures
- Verify staff and rooms exist before creating students
- Check capacity limits are not exceeded
- Ensure proper service registration in DI container

#### MVC-API Communication Issues
- Verify API is running on correct port (7074)
- Check HttpClient configuration in MVC Program.cs
- Ensure API endpoints are accessible

#### Database Connection Issues
- Verify SQL Server is running
- Check connection string in appsettings.json
- Run database migrations if needed

---

## 👨‍💻 Author
**Hari Ram L**  




---
