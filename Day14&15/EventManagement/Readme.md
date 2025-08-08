
# 🎉 Event Management System


A modular, layered ASP.NET Core Web API for managing technical events, users, and registrations. Built following **Clean Architecture** principles with a focus on simplicity, scalability, and maintainability.


## 📚 Introduction

The **Event Management System** is a backend web API designed to:

- 🎫 List and manage events
- 👥 List users
- 🔗 Link users to events through registrations

> Perfect for learning clean architecture in ASP.NET Core, or as a foundation for a real-world event system.

---

## 🚀 Features

- ✅ List technical events
- ✅ Get user details
- ✅ Register users for events
- ✅ View event participants
- ✅ In-memory repository (lightweight)
- ✅ Auto-generated Swagger documentation


---

## 🏗️ Architecture


The Event Management System follows **Onion Architecture**, focusing on dependency inversion and separation of concerns.

```text
Infrastructure (Data access, Repositories)
          ↑
Application (Business logic, Services)
          ↑
Domain (Entities, Interfaces, Core Models)
          ↑
Presentation (API Controllers, UI)

```


---
### Architectural Layers

### 1. Presentation Layer (`EventManagementAPI`)

* **Purpose:** Handle HTTP requests and responses.
* **Components:** API Controllers such as `EventController`, `UserController`, and `RegistrationController`.
* **Responsibilities:**

  * Expose RESTful API endpoints.
  * Basic input validation.
  * Return DTOs to clients.
  * Delegate business logic to the Application layer.

### 2. Application Layer (`EventManagement.Application`)

* **Purpose:** Contains business logic and orchestrates application workflows.
* **Components:** Services like `EventService`, `UserService`, and `RegistrationService`.
* **Responsibilities:**

  * Implement business rules.
  * Coordinate between Core entities and Infrastructure repositories.
  * Map domain entities to DTOs and vice versa.

### 3. Core Layer (`EventManagement.Core`)

* **Purpose:** Define the fundamental domain models and contracts.
* **Components:**

  * **Entities:** `Event`, `User`, `Registration`.
  * **DTOs:** Data Transfer Objects for API communication.
  * **Interfaces:** Service and repository abstractions (`IEventService`, `IRepository`, etc.).
* **Responsibilities:**

  * Maintain domain logic.
  * Provide abstractions for other layers.

### 4. Infrastructure Layer (`EventManagement.Infrastructure`)

* **Purpose:** Data access and external service implementations.
* **Components:** Repository classes like `EventRepository`, `UserRepository`, `RegistrationRepository`.
* **Responsibilities:**

  * Data persistence (currently in-memory, extendable to databases).
  * Abstract data source details from upper layers.

---

### Summary Table

| Layer          | Responsibility                  | Examples                           |
| -------------- | ------------------------------- | ---------------------------------- |
| Presentation   | API endpoints and HTTP handling | Controllers (`EventController.cs`) |
| Application    | Business logic and workflows    | Services (`EventService.cs`)       |
| Core           | Domain models and interfaces    | Entities, DTOs, Interfaces         |
| Infrastructure | Data access and persistence     | Repositories                       |

> Each layer has a single responsibility and communicates with others through well-defined abstractions, ensuring loose coupling and high cohesion.




---


## 🗂️ Folder Structure (Best Practices)
```
EventManagement/
├── EventManagement.Application/
│   └── Services/
│       ├── EventService.cs
│       ├── RegistrationService.cs
│       └── UserService.cs

├── EventManagement.Core/
│   ├── DTOs/
│   │   ├── EventResponseDto.cs
│   │   ├── RegistrationResponseDto.cs
│   │   └── UserResponseDto.cs
│   ├── Entities/
│   │   ├── Event.cs
│   │   ├── Registration.cs
│   │   └── User.cs
│   └── Interfaces/
│       ├── IEventService.cs
│       ├── IRegistrationService.cs
│       ├── IRepository.cs
│       └── IUserService.cs

├── EventManagement.Infrastructure/
│   └── Repositories/
│       ├── EventRepository.cs
│       ├── RegistrationRepository.cs
│       └── UserRepository.cs

├── EventManagementAPI/
│   ├── Controllers/
│   │   ├── EventController.cs
│   │   ├── RegistrationController.cs
│   │   └── UserController.cs
│   └── Program.cs
```

---

## 🛠️ Technologies Used

| 🔧 Technology         | ⚙️ Purpose                |
| --------------------- | ------------------------- |
| ASP.NET Core Web API  | Backend framework         |
| C#                    | Main programming language |
| LINQ                  | In-memory querying        |
| Swagger (Swashbuckle) | API Documentation         |
| DTOs                  | Clean API response models |
| Dependency Injection  | Layered decoupling        |

---
## 🛠️ Steps to Create Solution


# 1️⃣ Create root folder and navigate
```
mkdir EventManagement
cd EventManagement
```
# 2️⃣ Create the solution file
```
dotnet new sln -n EventManagement

```
# 3️⃣ Create class library projects
```
dotnet new classlib -n EventManagement.Core
dotnet new classlib -n EventManagement.Application
dotnet new classlib -n EventManagement.Infrastructure
```
# 4️⃣ Create the Web API project
```
dotnet new webapi -n EventManagementAPI
```

# 5️⃣ Add project references
```
dotnet add EventManagement.Application/EventManagement.Application.csproj reference EventManagement.Core/EventManagement.Core.csproj
dotnet add EventManagement.Infrastructure/EventManagement.Infrastructure.csproj reference EventManagement.Core/EventManagement.Core.csproj
dotnet add EventManagementAPI/EventManagementAPI.csproj reference EventManagement.Application/EventManagement.Application.csproj
dotnet add EventManagementAPI/EventManagementAPI.csproj reference EventManagement.Infrastructure/EventManagement.Infrastructure.csproj
```
# 6️⃣ Add all projects to the solution
```
dotnet sln EventManagement.sln add EventManagement.Core/EventManagement.Core.csproj
dotnet sln EventManagement.sln add EventManagement.Application/EventManagement.Application.csproj
dotnet sln EventManagement.sln add EventManagement.Infrastructure/EventManagement.Infrastructure.csproj
dotnet sln EventManagement.sln add EventManagementAPI/EventManagementAPI.csproj
```

# 6️⃣ Add all projects to the solution
```
dotnet sln EventManagement.sln add EventManagement.Core/EventManagement.Core.csproj
dotnet sln EventManagement.sln add EventManagement.Application/EventManagement.Application.csproj
dotnet sln EventManagement.sln add EventManagement.Infrastructure/EventManagement.Infrastructure.csproj
dotnet sln EventManagement.sln add EventManagementAPI/EventManagementAPI.csproj
```

## 🚦 Getting Started

### 📦 Prerequisites

* [.NET 6 SDK or newer](https://dotnet.microsoft.com/download)
* Visual Studio / VS Code

### ▶️ Run the App

```bash
git clone https://github.com/your-username/EventManagement.git
cd EventManagement
dotnet run --project EventManagementAPI
```

### 🌐 View Swagger

Go to:

```
https://localhost:<port>/swagger
```


---

## 🌐 API Endpoints

### 📅 Events

| Method | Endpoint           | Description     |
| ------ | ------------------ | --------------- |
| GET    | `/api/events`      | Get all events  |
| GET    | `/api/events/{id}` | Get event by ID |

### 👥 Users

| Method | Endpoint          | Description    |
| ------ | ----------------- | -------------- |
| GET    | `/api/users`      | Get all users  |
| GET    | `/api/users/{id}` | Get user by ID |

### 🔗 Registrations

| Method | Endpoint                             | Description                   |
| ------ | ------------------------------------ | ----------------------------- |
| GET    | `/api/registrations/event/{eventId}` | Get users registered to event |

---

## 🧩 Data Models

### 🎫 Event

```csharp
public class Event {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public string Location { get; set; }
}
```

### 👤 User

```csharp
public class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}
```

### 📝 Registration

```csharp
public class Registration {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public DateTime RegistrationDate { get; set; }
}
```

---

## 📦 Sample Data

| Event                           | Date       | Location  |
| ------------------------------- | ---------- | --------- |
| ASP.NET Core Workshop           | 2025-08-30 | Chennai   |
| Cloud DevOps Bootcamp           | 2025-09-05 | Bangalore |
| Blazor WebAssembly Crash Course | 2025-09-10 | Hyderabad |

| Users     | Email                                                 |
| --------- | ----------------------------------------------------- |
| Haripriya | [haripriya@example.com](mailto:haripriya@example.com) |
| Ram       | [ram@example.com](mailto:ram@example.com)             |
| Shiva     | [shiva@example.com](mailto:shiva@example.com)         |
| Kavi      | [kavi@example.com](mailto:kavi@example.com)           |

---


## OUTPUT



## 🔹 **1. Events**

### ✅ GET `/api/Events`

**📥 Request**
No parameters

**📤 Response: `200 OK`**

```json
[
  {
    "id": 1,
    "title": "ASP.NET Core Workshop",
    "description": "Backend development with .NET",
    "date": "2025-08-30T10:00:00",
    "location": "Chennai"
  },
  {
    "id": 2,
    "title": "Cloud DevOps Bootcamp",
    "description": "CI/CD and DevOps on Azure",
    "date": "2025-09-05T14:00:00",
    "location": "Bangalore"
  },
  {
    "id": 3,
    "title": "Blazor WebAssembly Crash Course",
    "description": "Full-stack C# with Blazor",
    "date": "2025-09-10T09:00:00",
    "location": "Hyderabad"
  }
]
```

---

### ✅ GET `/api/Events/{id}` (Example: `1`)

**📥 Request**

```http
GET /api/Events/1
```

**📤 Response: `200 OK`**

```json
{
  "id": 1,
  "title": "ASP.NET Core Workshop",
  "description": "Backend development with .NET",
  "date": "2025-08-30T10:00:00",
  "location": "Chennai"
}
```

---

## 🔹 **2. Users**

### ✅ GET `/api/Users`

**📥 Request**
No parameters

**📤 Response: `200 OK`**

```json
[
  {
    "id": 1,
    "name": "Haripriya",
    "email": "haripriya@example.com"
  },
  {
    "id": 2,
    "name": "Ram",
    "email": "ram@example.com"
  },
  {
    "id": 3,
    "name": "Shiva",
    "email": "shiva@example.com"
  },
  {
    "id": 4,
    "name": "Kavi",
    "email": "kavi@example.com"
  }
]
```

---

### ✅ GET `/api/Users/{id}` (Example: `1`)

**📥 Request**

```http
GET /api/Users/1
```

**📤 Response: `200 OK`**

```json
{
  "id": 1,
  "name": "Haripriya",
  "email": "haripriya@example.com"
}
```

---

## 🔹 **3. Registrations**

### ✅ GET `/api/Registrations/event/{eventId}` (Example: `2`)

**📥 Request**

```http
GET /api/Registrations/event/2
```

**📤 Response: `200 OK`**

```json
[
  {
    "id": 3,
    "userId": 3,
    "eventId": 2,
    "registrationDate": "2025-08-08T18:23:51.0892989+05:30",
    "userName": "Shiva",
    "eventTitle": "Cloud DevOps Bootcamp"
  },
  {
    "id": 5,
    "userId": 1,
    "eventId": 2,
    "registrationDate": "2025-08-08T18:23:51.0893009+05:30",
    "userName": "Haripriya",
    "eventTitle": "Cloud DevOps Bootcamp"
  }
]
```

---
Author: Hari Ram  L


---
## Screenshots
![Screenshot_8-8-2025_193937_localhost](https://github.com/user-attachments/assets/516c7dd3-a6be-4868-b028-a66850f0761b)



## 📈 Future Improvements

* [ ] Add POST / PUT / DELETE endpoints
* [ ] EF Core with real database (SQL Server)
* [ ] JWT Authentication
* [ ] Role-based access
* [ ] Pagination & Filtering
* [ ] CI/CD with GitHub Actions
* [ ] Unit tests with xUnit

---

## 🤝 Contributing

![Contribute](https://img.shields.io/badge/PRs-welcome-brightgreen.svg)

1. Fork this repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes
4. Push and open a PR

Please follow the project's existing coding standards.

---

## 📄 License

Licensed under the [MIT License](LICENSE).
Feel free to use, modify, and distribute.

---



 Created with ❤️ by **Hari Ram L**


