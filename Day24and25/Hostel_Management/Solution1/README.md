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

## 🔐 JWT Authentication & Authorization System

### Authentication Implementation
✅ **JWT Authentication Controller**: Created AuthController with register and login endpoints  
✅ **JWT Configuration**: Added JWT settings in appsettings.json with Key, Issuer, and Audience  
✅ **Token Generation**: Implemented JWT token creation with 1-hour expiration  
✅ **Bearer Token Validation**: Configured JWT middleware for token validation  
✅ **Swagger Integration**: Added JWT authentication support in Swagger UI  
✅ **Protected Endpoints**: Secured all API controllers with [Authorize] attribute  
✅ **User Registration**: Dynamic user registration with role assignment  
✅ **Password Security**: Implemented password hashing using ASP.NET Core Identity  
✅ **Claims-based Authentication**: Added user claims in JWT tokens  
✅ **Error Handling**: Proper 401/403 responses for authentication failures

### Authorization Features
- **Role-Based Access Control**: Three distinct roles with different permission levels
- **Policy-Based Authorization**: Custom policies for fine-grained access control
- **Endpoint Protection**: Each endpoint secured with appropriate role requirements
- **JWT Claims**: User roles embedded in JWT tokens for stateless authorization

### Available Roles

| Role    | Description                           | Permissions                                    |
|---------|---------------------------------------|------------------------------------------------|
| **Admin** | System Administrator                | Full access to all operations                 |
| **Staff** | Hostel Staff Member                 | Read access to students and rooms             |
| **User**  | Default Role                        | Limited access (can be customized)            |

### Authorization Policies

#### Built-in Policies
- **AdminOnly**: Requires "Admin" role - Used for critical operations like deletions
- **Admin,Staff**: Allows both Admin and Staff roles - Used for read operations

#### Custom Policy Configuration
```csharp
// Program.cs - Authorization Policy Setup
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});
```

### JWT Features
- **Registration Endpoint**: `/api/Auth/register` - Create new user accounts with roles
- **Login Endpoint**: `/api/Auth/login` - Authenticate and receive JWT token
- **Secure Headers**: All protected endpoints require `Authorization: Bearer <token>`
- **Token Expiry**: 1-hour token lifetime
- **Swagger Auth**: Click "Authorize" button in Swagger to test with JWT tokens

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
- **Authentication**: JWT Bearer Token Authentication
- **Security**: Microsoft.AspNetCore.Authentication.JwtBearer
- **Dependency Injection**: Built-in DI Container
- **Documentation**: Swagger/OpenAPI 3.0 with JWT support

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
│   │   ├── 📄 AuthController.cs           # JWT authentication endpoints
│   │   ├── 📄 StudentController.cs        # Student API endpoints (secured)
│   │   ├── 📄 StaffController.cs          # Staff API endpoints (secured)
│   │   └── 📄 RoomController.cs           # Room API endpoints (secured)
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
│   │   ├── 📄 AuthRequest.cs              # Login request model
│   │   ├── 📄 AuthResponse.cs             # JWT token response model
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
🔐 **JWT Authentication**: Secure token-based authentication system
- **Bearer Token**: All API endpoints (except auth) require valid JWT token
- **Token Expiration**: 1 hour validity with refresh capability
- **Swagger Integration**: Built-in authentication UI for testing
- **Demo Credentials**: Hardcoded users for testing (replace with database validation)

### Authentication Headers
All endpoints (except `/api/Auth/login`) require JWT authentication:
```
Authorization: Bearer <your-jwt-token>
```

### Common Response Codes
- `200 OK` - Successful GET request
- `201 Created` - Successful POST request
- `204 No Content` - Successful PUT/DELETE request
- `400 Bad Request` - Validation errors (ValidationException)
- `401 Unauthorized` - Missing or invalid JWT token
- `403 Forbidden` - Valid token but insufficient permissions
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

### 🔐 Authentication Endpoints

| Method | Endpoint              | Description                    | Auth Required |
| ------ | --------------------- | ------------------------------ | ------------- |
| POST   | `/api/Auth/login`     | Login and get JWT token        | ❌ No         |
| POST   | `/api/Auth/refresh`   | Refresh existing JWT token     | ✅ Yes        |
| POST   | `/api/Auth/validate`  | Validate current JWT token     | ✅ Yes        |

--- 

### 🏠 Room Endpoints

| Method | Endpoint         | Description                    | Auth Required |
| ------ | ---------------- | ------------------------------ | ------------- |
| GET    | `/api/Room`      | Get all rooms                  | ✅ Yes        |
| GET    | `/api/Room/{id}` | Get a specific room by ID      | ✅ Yes        |
| POST   | `/api/Room`      | Create a new room              | ✅ Yes        |
| PUT    | `/api/Room/{id}` | Update an existing room        | ✅ Yes        |
| DELETE | `/api/Room/{id}` | Delete a room (if unallocated) | ✅ Yes        |

---

### 👨‍🏫 Staff Endpoints

| Method | Endpoint          | Description                | Auth Required |
| ------ | ----------------- | -------------------------- | ------------- |
| GET    | `/api/Staff`      | Get all staff              | ✅ Yes        |
| GET    | `/api/Staff/{id}` | Get a specific staff by ID | ✅ Yes        |
| POST   | `/api/Staff`      | Create a new staff         | ✅ Yes        |
| PUT    | `/api/Staff/{id}` | Update an existing staff   | ✅ Yes        |
| DELETE | `/api/Staff/{id}` | Delete a staff member      | ✅ Yes        |

---

### 👨‍🎓 Student Endpoints

| Method | Endpoint            | Description                                        | Auth Required |
| ------ | ------------------- | -------------------------------------------------- | ------------- |
| GET    | `/api/Student`      | Get all students                                   | ✅ Yes        |
| GET    | `/api/Student/{id}` | Get a specific student by ID                       | ✅ Yes        |
| POST   | `/api/Student`      | Create a new student (auto allocates room & staff) | ✅ Yes        |
| PUT    | `/api/Student/{id}` | Update an existing student                         | ✅ Yes        |
| DELETE | `/api/Student/{id}` | Delete a student                                   | ✅ Yes        |
---
## 🔐 Authentication Examples

---

### ✅ `POST /api/Auth/login`

**📥 Request**

```json
{
  "userName": "admin",
  "password": "password"
}
```

**📤 Response (Success)**

```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expiration": "2024-08-20T10:30:00Z"
}
```

**📤 Response (Invalid Credentials)**

```json
{
  "message": "Invalid username or password"
}
```

**📤 Response (Validation Error)**

```json
"Username and password are required"
```

---

### ✅ `POST /api/Auth/register`

**📥 Request**

```json
{
  "username": "admin",
  "password": "Admin123!",
  "role": "Admin"
}
```

**📤 Response (Success)**

```json
{
  "message": "User registered successfully",
  "role": "Admin"
}
```

**📤 Response (User Exists)**

```json
"Username already exists."
```

**📤 Response (Validation Error)**

```json
"Username and password are required."
```

---

## 🔐 Role-Based Access Control Examples

**📤 Response (Unauthorized - Wrong Role)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 403,
  "message": "Forbidden: Insufficient permissions",
  "details": null
}
```

**📤 Response (Missing Token)**

```json
{
  "correlationId": "abc123-def456",
  "statusCode": 401,
  "message": "Unauthorized: Missing or invalid token",
  "details": null
}
```

---

### 🔐 User Registration & Testing

#### Creating Test Users
Use the `/api/Auth/register` endpoint to create users with different roles:

**Admin User Registration:**
```json
{
  "username": "admin",
  "password": "Admin123!",
  "role": "Admin"
}
```

**Staff User Registration:**
```json
{
  "username": "staff",
  "password": "Staff123!",
  "role": "Staff"
}
```

**Regular User Registration:**
```json
{
  "username": "user",
  "password": "User123!",
  "role": "User"
}
```

> **⚠️ Important**: Users are stored in memory for development. Implement database persistence for production!

> **📄 Detailed Documentation**: See [ROLES_AND_POLICIES.md](ROLES_AND_POLICIES.md) for comprehensive role-based access control information.

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
    "DefaultConnection": "Server=localhost;TrustServerCertificate=True;Database=HostelDay20;User Id=sa;Password=YourPassword;"
  },
  "JWT": {
    "Key": "MyVeryStrongJWTSecretKey1234567890!",
    "Issuer": "HostelTrackerAPI",
    "Audience": "HostelTrackerUsers"
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
// API Program.cs - JWT Authentication
var jwtConfig = builder.Configuration.GetSection("JWT");
var key = jwtConfig["Key"] ?? throw new InvalidOperationException("JWT Key is missing");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["Issuer"],
        ValidAudience = jwtConfig["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ClockSkew = TimeSpan.Zero
    };
});

// Database and Services
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Student>, StudentRepository>();
builder.Services.AddScoped<IRepository<Staff>, StaffRepository>();
builder.Services.AddScoped<IRepository<Room>, RoomRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IRoomService, RoomService>();

// Swagger with JWT Support
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Middleware Pipeline
app.UseAuthentication();
app.UseAuthorization();

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
- **Authenticate First**: Use `/api/Auth/login` with demo credentials
- **Set Bearer Token**: Click "Authorize" button and enter: `Bearer <your-token>`
- Create staff member and room first
- Create student (auto-assigned to staff and room)
- Verify assignments in GET responses
- **Token Expiry**: Refresh token using `/api/Auth/refresh` when needed

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
✅ JWT authentication and token generation  
✅ Protected endpoint access with valid tokens  
✅ Unauthorized access prevention (401/403 responses)  
✅ Token refresh and validation functionality  
✅ Successful student creation with auto-assignment  
✅ Capacity limit enforcement  
✅ Error handling for invalid inputs  
✅ CRUD operations for all entities  
✅ Relationship integrity maintenance  
✅ Web interface functionality  
✅ API-MVC integration  
✅ Swagger JWT authentication UI  

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
# 🔐 Hostel Management System - Roles & Policies Documentation

## 📊 Role-Based Access Control Summary

### Access Control Matrix

| Controller | Endpoint | Method | Admin | Staff | User | Policy Used |
|------------|----------|--------|-------|-------|------|-------------|
| **Auth** | `/register` | POST | ✅ | ✅ | ✅ | Public |
| **Auth** | `/login` | POST | ✅ | ✅ | ✅ | Public |
| **Student** | `/` | GET | ✅ | ✅ | ❌ | Role: Admin,Staff |
| **Student** | `/{id}` | GET | ✅ | ✅ | ❌ | Role: Admin,Staff |
| **Student** | `/` | POST | ✅ | ❌ | ❌ | Role: Admin |
| **Student** | `/{id}` | PUT | ✅ | ❌ | ❌ | Role: Admin |
| **Student** | `/{id}` | DELETE | ✅ | ❌ | ❌ | Policy: AdminOnly |
| **Staff** | `/` | GET | ✅ | ❌ | ❌ | Role: Admin |
| **Staff** | `/{id}` | GET | ✅ | ❌ | ❌ | Role: Admin |
| **Staff** | `/` | POST | ✅ | ❌ | ❌ | Role: Admin |
| **Staff** | `/{id}` | PUT | ✅ | ❌ | ❌ | Role: Admin |
| **Staff** | `/{id}` | DELETE | ✅ | ❌ | ❌ | Policy: AdminOnly |
| **Room** | `/` | GET | ✅ | ✅ | ❌ | Role: Admin,Staff |
| **Room** | `/{id}` | GET | ✅ | ✅ | ❌ | Role: Admin,Staff |
| **Room** | `/` | POST | ✅ | ❌ | ❌ | Role: Admin |
| **Room** | `/{id}` | PUT | ✅ | ❌ | ❌ | Role: Admin |
| **Room** | `/{id}` | DELETE | ✅ | ❌ | ❌ | Policy: AdminOnly |

## 🎭 Available Roles

### 🔴 Admin Role
- **Full System Access**: Complete CRUD operations on all entities
- **User Management**: Can manage staff and student records
- **Resource Management**: Can create, update, and delete rooms
- **Critical Operations**: Only role that can perform DELETE operations
- **Data Access**: Can view all students, staff, and rooms

### 🟡 Staff Role
- **Read Access**: Can view student and room information
- **Limited Scope**: Cannot modify any data
- **Monitoring**: Can check room occupancy and student assignments
- **No Management**: Cannot create, update, or delete any records

### 🟢 User Role
- **Minimal Access**: Currently no specific endpoints assigned
- **Authentication**: Can register and login
- **Extensible**: Role can be extended for future features

## 🛡️ Authorization Policies

### Built-in Policies
- **AdminOnly**: Requires "Admin" role - Used for critical operations like deletions
- **Admin,Staff**: Allows both Admin and Staff roles - Used for read operations

### Custom Policy Configuration
```csharp
// Program.cs - Authorization Policy Setup
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});
```

## 🔧 Security Implementation Details

### Authorization Attributes Used
```csharp
[Authorize] // Requires valid JWT token
[Authorize(Roles = "Admin")] // Admin role only
[Authorize(Roles = "Admin,Staff")] // Admin OR Staff roles
[Authorize(Policy = "AdminOnly")] // Custom policy for Admin
```

### JWT Token Claims
```csharp
var claims = new[]
{
    new Claim(ClaimTypes.Name, user.Username),
    new Claim(ClaimTypes.NameIdentifier, user.Username),
    new Claim(ClaimTypes.Role, user.Role ?? "User"),
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
};
```

## 📋 Detailed Endpoint Permissions

### 🔐 Authentication Endpoints
| Method | Endpoint | Roles Allowed | Description |
|--------|----------|---------------|-------------|
| POST | `/api/Auth/register` | Public | Register new user with role |
| POST | `/api/Auth/login` | Public | Login and get JWT token |

### 👨🎓 Student Endpoints
| Method | Endpoint | Roles Allowed | Policy | Description |
|--------|----------|---------------|--------|-------------|
| GET | `/api/Student` | Admin, Staff | Role-based | Get all students |
| GET | `/api/Student/{id}` | Admin, Staff | Role-based | Get specific student |
| POST | `/api/Student` | Admin | Role-based | Create new student |
| PUT | `/api/Student/{id}` | Admin | Role-based | Update student |
| DELETE | `/api/Student/{id}` | Admin | AdminOnly | Delete student |

### 👨🏫 Staff Endpoints
| Method | Endpoint | Roles Allowed | Policy | Description |
|--------|----------|---------------|--------|-------------|
| GET | `/api/Staff` | Admin | Role-based | Get all staff |
| GET | `/api/Staff/{id}` | Admin | Role-based | Get specific staff |
| POST | `/api/Staff` | Admin | Role-based | Create new staff |
| PUT | `/api/Staff/{id}` | Admin | Role-based | Update staff |
| DELETE | `/api/Staff/{id}` | Admin | AdminOnly | Delete staff |

### 🏠 Room Endpoints
| Method | Endpoint | Roles Allowed | Policy | Description |
|--------|----------|---------------|--------|-------------|
| GET | `/api/Room` | Admin, Staff | Role-based | Get all rooms |
| GET | `/api/Room/{id}` | Admin, Staff | Role-based | Get specific room |
| POST | `/api/Room` | Admin | Role-based | Create new room |
| PUT | `/api/Room/{id}` | Admin | Role-based | Update room |
| DELETE | `/api/Room/{id}` | Admin | AdminOnly | Delete room |

## 🧪 Testing Role-Based Access

### Creating Test Users
Use the `/api/Auth/register` endpoint to create users with different roles:

**Admin User:**
```json
{
  "username": "admin",
  "password": "Admin123!",
  "role": "Admin"
}
```

**Staff User:**
```json
{
  "username": "staff",
  "password": "Staff123!",
  "role": "Staff"
}
```

**Regular User:**
```json
{
  "username": "user",
  "password": "User123!",
  "role": "User"
}
```

### Testing Access Control
1. Register users with different roles
2. Login to get JWT tokens for each user
3. Test endpoints with different user tokens
4. Verify proper 403 Forbidden responses for unauthorized access

## 🚨 Common Authorization Responses

### Successful Access (200/201/204)
```json
{
  "data": "endpoint response"
}
```

### Unauthorized - Missing Token (401)
```json
{
  "correlationId": "abc123-def456",
  "statusCode": 401,
  "message": "Unauthorized: Missing or invalid token",
  "details": null
}
```

### Forbidden - Wrong Role (403)
```json
{
  "correlationId": "abc123-def456",
  "statusCode": 403,
  "message": "Forbidden: Insufficient permissions",
  "details": null
}
```
=

#### Authentication Issues
- **Missing Token**: Ensure JWT token is included in Authorization header
- **Expired Token**: Use `/api/Auth/refresh` to get new token
- **Invalid Credentials**: Verify username/password with demo credentials
- **Token Format**: Use `Bearer <token>` format in Authorization header

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

## 📸 Application Screenshots

### Swagger API Documentation
![Swagger UI Overview](https://github.com/hariram7405/Dotnet-Training/blob/main/Day24and25/Hostel_Management/Solution1/Assests/Screenshot_26-8-2025_155419_localhost.jpeg)
*Complete Swagger UI interface showing all available endpoints with JWT authentication*

### API Filtering Functionality
![Swagger API Filtering](https://github.com/hariram7405/Dotnet-Training/blob/main/Day24and25/Hostel_Management/Solution1/Assests/Screenshot_26-8-2025_155419_localhost.jpeg)
*Demonstration of endpoint filtering and grouping in Swagger UI*

### Sample API Response
![API Response Example](https://github.com/hariram7405/Dotnet-Training/blob/main/Day24and25/Hostel_Management/Solution1/Assests/Screenshot_26-8-2025_16343_localhost.jpeg)
*Sample JSON response from the API endpoints*



## 👨‍💻 Author
**Hari Ram L**  




---
