 # 🏦 BankPro - Bank Management System

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)

A comprehensive **Bank Management System** built with **.NET 8 Web API** using **Clean Architecture** principles. This system provides complete banking operations including customer management, account handling, and secure money transfers with in-memory data storage.

---

## 📋 Table of Contents

- [🎯 Project Overview](#-project-overview)
- [🏗️ Architecture](#️-architecture)
- [🚀 Features](#-features)
- [🛠️ Technology Stack](#️-technology-stack)
- [📁 Project Structure](#-project-structure)
- [⚡ Quick Start](#-quick-start)
- [🌐 API Endpoints](#-api-endpoints)
- [📸 API Screenshots](#-api-screenshots)
- [🧪 Testing](#-testing)
- [🤝 Contributing](#-contributing)

---

## 🎯 Project Overview

**BankPro** is a modern banking system designed to demonstrate enterprise-level software development practices. Built as part of a .NET Core assessment, it showcases:

- **Clean Architecture** implementation
- **Generic Repository Pattern** with in-memory storage
- **Service Layer** with comprehensive business logic
- **RESTful API** design with proper HTTP status codes
- **Unit Testing** with xUnit and Moq
- **AutoMapper** for object-to-object mapping
- **Dependency Injection** throughout the application



## 🏗️ Architecture

The project follows **Clean Architecture** principles with clear separation of concerns:

```
┌─────────────────────────────────────────┐
│              Presentation               │
│         (BankManagement.API)            │
│    Controllers, Program.cs, DI Config  │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│             Application                 │
│       (BankManagement.Application)      │
│     Services, AutoMapper, Business      │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│            Infrastructure               │
│     (BankManagement.Infrastructure)     │
│    Repositories, Data Access Layer     │
└─────────────────┬───────────────────────┘
                  │
┌─────────────────▼───────────────────────┐
│               Domain                    │
│         (BankManagement.Core)           │
│   Entities, DTOs, Interfaces, Rules    │
└─────────────────────────────────────────┘
```

---

## 🚀 Features

### ✨ Core Banking Features
- 👥 **Customer Management** - Create, read, update, delete customers
- 💳 **Account Management** - Multiple account types with balance tracking
- 💸 **Money Transfers** - Secure transfers between accounts with validation
- 📊 **Transaction History** - Complete audit trail with pagination
- 🔍 **Account Lookup** - Search by account number or customer ID

### 🛡️ Security & Validation
- ✅ **Business Rule Validation** - Insufficient funds, account status checks
- 🚫 **Input Validation** - Comprehensive request validation
- 🔒 **Exception Handling** - Proper error responses with meaningful messages
- 📝 **Audit Trail** - Complete transaction logging

### 🏗️ Technical Features
- 🎯 **Clean Architecture** - Separation of concerns
- 🔄 **Generic Repository Pattern** - Reusable data access layer
- 🗺️ **AutoMapper Integration** - Automatic DTO mapping
- 💉 **Dependency Injection** - Loose coupling and testability
- ⚡ **Async/Await** - Non-blocking operations
- 🧪 **Unit Testing** - Comprehensive test coverage

---

## 🛠️ Technology Stack

### Core Technologies
- **.NET 8.0** - Latest .NET framework
- **ASP.NET Core Web API** - RESTful API framework
- **C# 12** - Modern C# features

### Libraries & Packages
| Package | Version | Purpose |
|---------|---------|---------|
| **AutoMapper** | 12.0.1 | Object-to-object mapping |
| **AutoMapper.Extensions.Microsoft.DependencyInjection** | 12.0.1 | DI integration |
| **Swashbuckle.AspNetCore** | 6.6.2 | Swagger/OpenAPI documentation |
| **xUnit** | 2.6.1 | Unit testing framework |
| **Moq** | 4.20.69 | Mocking framework |
| **Microsoft.NET.Test.Sdk** | 17.8.0 | Test SDK |

### Development Tools
- **Visual Studio 2022** / **VS Code**
- **Postman** - API testing
- **Swagger UI** - Interactive API documentation
- **Git** - Version control

---

## 📁 Project Structure

```
BankManagement/
├── 📄 BankManagement.sln                    # Solution file
├── 📄 README.md                             # This file
├── 📄 BuggyCodeFix.cs                       # Bug fix documentation
├── 📄 COMPLETE_PROJECT_DOCUMENTATION.md     # Detailed documentation
│
├── 📂 BankManagement.Core/                  # 🎯 DOMAIN LAYER
│   ├── 📂 Entities/                         # Domain entities
│   │   ├── Customer.cs                      # Customer entity
│   │   ├── Account.cs                       # Account entity
│   │   └── Transaction.cs                   # Transaction entity
│   ├── 📂 DTOs/                            # Data Transfer Objects
│   │   ├── CustomerRequestDTO.cs            # Customer input DTO
│   │   ├── CustomerResponseDTO.cs           # Customer output DTO
│   │   ├── AccountRequestDTO.cs             # Account input DTO
│   │   ├── AccountResponseDTO.cs            # Account output DTO
│   │   ├── TransactionRequestDTO.cs         # Transaction input DTO
│   │   └── TransactionResponseDTO.cs        # Transaction output DTO
│   └── 📂 Interfaces/                       # Contracts & abstractions
│       ├── IRepository.cs                   # Generic repository interface
│       ├── ICustomerRepository.cs           # Customer repository contract
│       ├── IAccountRepository.cs            # Account repository contract
│       ├── ITransactionRepository.cs        # Transaction repository contract
│       ├── ICustomerService.cs              # Customer service contract
│       ├── IAccountService.cs               # Account service contract
│       └── ITransactionService.cs           # Transaction service contract
│
├── 📂 BankManagement.Application/           # 🧠 APPLICATION LAYER
│   ├── 📂 Services/                         # Business logic services
│   │   ├── CustomerService.cs               # Customer business operations
│   │   ├── AccountService.cs                # Account business operations
│   │   └── TransactionService.cs            # Transaction business operations
│   └── 📂 Mapping/                          # Object mapping configuration
│       └── MappingProfile.cs                # AutoMapper profile
│
├── 📂 BankManagement.Infrastructure/        # 🏗️ INFRASTRUCTURE LAYER
│   └── 📂 Repositories/                     # Data access implementations
│       ├── CustomerRepository.cs            # Customer data operations
│       ├── AccountRepository.cs             # Account data operations
│       └── TransactionRepository.cs         # Transaction data operations
│
├── 📂 BankManagement.API/                   # 🌐 PRESENTATION LAYER
│   ├── 📂 Controllers/                      # API endpoints
│   │   ├── CustomerController.cs            # Customer API endpoints
│   │   ├── AccountController.cs             # Account API endpoints
│   │   └── TransactionController.cs         # Transaction API endpoints
│   ├── Program.cs                           # Application startup & DI
│   ├── appsettings.json                     # Application settings
│   └── BankManagement.API.http              # HTTP test requests
│
└── 📂 BankManagement.Tests/                 # 🧪 TEST LAYER
    └── 📂 Services/                         # Service unit tests
        └── TransactionServiceTests.cs       # Transaction service tests
```

---

## ⚡ Quick Start

### Prerequisites
- **.NET 8.0 SDK** or later
- **Visual Studio 2022** / **VS Code**
- **Postman** (optional, for API testing)

### 🚀 Installation & Setup

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd BankManagement
   ```

2. **Restore NuGet Packages**
   ```bash
   dotnet restore
   ```

3. **Build the Solution**
   ```bash
   dotnet build
   ```

4. **Run Unit Tests**
   ```bash
   dotnet test
   ```

5. **Start the API**
   ```bash
   dotnet run --project BankManagement.API
   ```

6. **Access Swagger UI**
   ```
   https://localhost:7xxx/swagger
   ```

### 🎯 Verification Steps

✅ **API is running**: Navigate to `https://localhost:7xxx/swagger`  
✅ **Tests pass**: Run `dotnet test` - should show 3 passing tests  
✅ **Endpoints work**: Try GET `/api/customer` - should return empty array `[]`

---

## 🌐 API Endpoints

### 👥 Customer Management

| Method | Endpoint | Description | Status Codes |
|--------|----------|-------------|--------------|
| `GET` | `/api/customer` | Get all customers | 200 |
| `GET` | `/api/customer/{id}` | Get customer by ID | 200, 404 |
| `POST` | `/api/customer` | Create new customer | 201, 400 |
| `PUT` | `/api/customer/{id}` | Update customer | 200, 404 |
| `DELETE` | `/api/customer/{id}` | Delete customer | 204, 404 |

### 💳 Account Management

| Method | Endpoint | Description | Status Codes |
|--------|----------|-------------|--------------|
| `GET` | `/api/account` | Get all accounts | 200 |
| `GET` | `/api/account/{id}` | Get account by ID | 200, 404 |
| `GET` | `/api/account/customer/{id}` | Get accounts by customer | 200 |
| `POST` | `/api/account` | Create new account | 201, 400 |
| `PUT` | `/api/account/{id}` | Update account | 200, 404 |
| `DELETE` | `/api/account/{id}` | Close account | 204, 404 |

### 💸 Transaction Management

| Method | Endpoint | Description | Status Codes |
|--------|----------|-------------|--------------|
| `POST` | `/api/transaction/transfer` | Transfer money | 200, 400 |
| `GET` | `/api/transaction/history/{id}` | Get transaction history | 200 |
| `GET` | `/api/transaction/{id}` | Get transaction by ID | 200, 404 |
| `GET` | `/api/transaction` | Get all transactions | 200 |

---


## 📊 API Sample Outputs

### 🏠 Swagger UI Overview

**Sample Swagger UI Interface:**
```
BankPro API v1.0
Swagger UI

Schemas:
- CustomerRequestDTO
- CustomerResponseDTO  
- AccountRequestDTO
- AccountResponseDTO
- TransactionRequestDTO
- TransactionResponseDTO

Controllers:
▼ Customer
  GET /api/customer
  POST /api/customer
  GET /api/customer/{id}
  PUT /api/customer/{id}
  DELETE /api/customer/{id}

▼ Account  
  GET /api/account
  POST /api/account
  GET /api/account/{id}
  PUT /api/account/{id}
  DELETE /api/account/{id}
  GET /api/account/customer/{customerId}

▼ Transaction
  GET /api/transaction
  POST /api/transaction/transfer
  GET /api/transaction/{id}
  GET /api/transaction/history/{accountId}
```

---

### 👥 Customer Operations

#### ➕ Create Customer
**Request:**
```json
POST /api/customer
Content-Type: application/json

{
  "name": "John Doe",
  "email": "john.doe@email.com",
  "phone": "+1234567890"
}
```

**Sample Response (201 Created):**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "John Doe",
  "email": "john.doe@email.com",
  "phone": "+1234567890",
  "createdAt": "2024-08-18T10:30:00.000Z"
}
```
**Screenshot**

![Customer POST](https://github.com/user-attachments/assets/b5499fc2-9afa-4799-8ce1-c78e29e81a49)

---

#### 📋 Get All Customers
**Request:**
```
GET /api/customer
```

**Sample Response (200 OK):**
```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "John Doe",
    "email": "john.doe@email.com",
    "phone": "+1234567890",
    "createdAt": "2024-08-18T10:30:00.000Z"
  },
  {
    "id": "7fb92c81-8429-4873-a4fd-3d874e77bbc7",
    "name": "Jane Smith",
    "email": "jane.smith@email.com",
    "phone": "+0987654321",
    "createdAt": "2024-08-18T10:35:00.000Z"
  }
]
```
**Screenshot**
![CUSTOMER GET ALL](https://github.com/user-attachments/assets/c9de32fb-288b-498b-92bb-e6397deb1be6)

---

#### 🔍 Get Customer by ID
**Request:**
```
GET /api/customer/3fa85f64-5717-4562-b3fc-2c963f66afa6
```

**Sample Response (200 OK):**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "John Doe",
  "email": "john.doe@email.com",
  "phone": "+1234567890",
  "createdAt": "2024-08-18T10:30:00.000Z"
}
```
**Screenshot**
![CUSTOMER GET BY ID](https://github.com/user-attachments/assets/b16c7ad2-1c24-442e-8515-ab6de29eaf7f)


#### ✏️ Update Customer

**Request:**

```
PUT /api/customer/3fa85f64-5717-4562-b3fc-2c963f66afa6
```

**Request Body:**

```json
{
  "name": "John Updated Doe",
  "email": "john.updated@email.com",
  "phone": "+1234567899"
}
```

**Sample Response (200 OK):**

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "name": "John Updated Doe",
  "email": "john.updated@email.com",
  "phone": "+1234567899",
  "createdAt": "2024-08-18T10:30:00.000Z"
}
```

**Screenshot**
![CUSTOMER PUT](https://github.com/user-attachments/assets/b4ec8f76-d2a0-492f-a689-6d55a60eabd7)



---

#### 🗑️ Delete Customer

**Request:**

```
DELETE /api/customer/3fa85f64-5717-4562-b3fc-2c963f66afa6
```

**Sample Response (204 No Content):**

```
(No response body)
```

**Screenshot**

![Customer Delete](https://github.com/user-attachments/assets/2c7e2444-1ceb-45d6-a01a-0d78095fca22)


---

### 💳 Account Operations

#### ➕ Create Account

**Request:**

```json
POST /api/account
Content-Type: application/json

{
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "initialBalance": 1000.00,
  "accountType": "Savings"
}
```

**Sample Response (201 Created):**

```json
{
  "id": "9bc42c45-6789-4def-8901-234567890abc",
  "accountNumber": "ACC638123456789",
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "balance": 1000.00,
  "accountType": "Savings",
  "createdAt": "2024-08-18T10:40:00.000Z",
  "isActive": true
}
```

**Screenshot**
![ACCOUNT POST](https://github.com/user-attachments/assets/44d19c93-d1b9-4ff1-8e37-a46f49da79d1)


---

#### 📋 Get Accounts by Customer

**Request:**

```
GET /api/account/customer/3fa85f64-5717-4562-b3fc-2c963f66afa6
```

**Sample Response (200 OK):**

```json
[
  {
    "id": "9bc42c45-6789-4def-8901-234567890abc",
    "accountNumber": "ACC638123456789",
    "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "balance": 1000.00,
    "accountType": "Savings",
    "createdAt": "2024-08-18T10:40:00.000Z",
    "isActive": true
  },
  {
    "id": "def56789-0123-4567-8901-23456789abcd",
    "accountNumber": "ACC638987654321",
    "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "balance": 500.00,
    "accountType": "Checking",
    "createdAt": "2024-08-18T10:45:00.000Z",
    "isActive": true
  }
]
```
**Screenshot**
![ACCOUNT GET BY CUSTOMER ID](https://github.com/user-attachments/assets/6d450dde-4362-4bc5-b8cf-6bb33d8f12b2)

---

#### ✏️ Update Account

**Request:**

```
PUT /api/account/9bc42c45-6789-4def-8901-234567890abc
Content-Type: application/json

{
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "initialBalance": 1200.00,
  "accountType": "Checking"
}
```

**Sample Response (200 OK):**

```json
{
  "id": "9bc42c45-6789-4def-8901-234567890abc",
  "accountNumber": "ACC638123456789",
  "customerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "balance": 1200.00,
  "accountType": "Checking",
  "createdAt": "2024-08-18T10:40:00.000Z",
  "isActive": true
}
```

**Screenshot**
![Account PUT](https://github.com/user-attachments/assets/7ac8996d-c70f-4650-b3ae-2fd5c5563d47)

---

#### ❌ Delete Account

**Request:**

```
DELETE /api/account/9bc42c45-6789-4def-8901-234567890abc
```

**Sample Response:**

```
204 No Content
```

**Screenshot**
![ACCOUNT DELETE](https://github.com/user-attachments/assets/363cd0a1-6692-40cc-99e2-3ba77c4203e2)

---



### 💸 Transaction Operations

#### 💰 Transfer Money
**Request:**
```json
POST /api/transaction/transfer
Content-Type: application/json

{
  "fromAccountNumber": "ACC638123456789",
  "toAccountNumber": "ACC638987654321",
  "amount": 250.00,
  "description": "Payment for services"
}
```
**Sample Response (200 OK):**
```json
{
  "id": "abc12345-def6-7890-1234-56789abcdef0",
  "fromAccountId": "9bc42c45-6789-4def-8901-234567890abc",
  "toAccountId": "def56789-0123-4567-8901-23456789abcd",
  "amount": 250.00,
  "transactionType": "Transfer",
  "transactionDate": "2024-08-18T10:50:00.000Z",
  "description": "Payment for services",
  "status": "Completed"
}
```
**Screenshot**
![TRANSACTION POST](https://github.com/user-attachments/assets/5401d744-57d5-4ae3-8493-1462200ac017)


---

#### 📊 Get Transaction History
**Request:**
```
GET /api/transaction/history/9bc42c45-6789-4def-8901-234567890abc?page=1&pageSize=10
```

**Sample Response (200 OK):**
```json
[
  {
    "id": "abc12345-def6-7890-1234-56789abcdef0",
    "fromAccountId": "9bc42c45-6789-4def-8901-234567890abc",
    "toAccountId": "def56789-0123-4567-8901-23456789abcd",
    "amount": 250.00,
    "transactionType": "Transfer",
    "transactionDate": "2024-08-18T10:50:00.000Z",
    "description": "Payment for services",
    "status": "Completed"
  },
  {
    "id": "fed09876-5432-1098-7654-321098765432",
    "fromAccountId": "def56789-0123-4567-8901-23456789abcd",
    "toAccountId": "9bc42c45-6789-4def-8901-234567890abc",
    "amount": 100.00,
    "transactionType": "Transfer",
    "transactionDate": "2024-08-18T09:30:00.000Z",
    "description": "Refund",
    "status": "Completed"
  }
]
```
**Screenshot**

![Transaction Transaction History By AccountId](https://github.com/user-attachments/assets/9beabf40-3f46-41d6-8fea-d8caebe3509c)


---

#### 📋 Get All Transactions

**Request:**

```
GET /api/transaction
```

**Sample Response (200 OK):**

```json
[
  {
    "id": "abc12345-def6-7890-1234-56789abcdef0",
    "fromAccountId": "9bc42c45-6789-4def-8901-234567890abc",
    "toAccountId": "def56789-0123-4567-8901-23456789abcd",
    "amount": 250.00,
    "transactionType": "Transfer",
    "transactionDate": "2024-08-18T10:50:00.000Z",
    "description": "Payment for services",
    "status": "Completed"
  },
  {
    "id": "fed09876-5432-1098-7654-321098765432",
    "fromAccountId": "def56789-0123-4567-8901-23456789abcd",
    "toAccountId": "9bc42c45-6789-4def-8901-234567890abc",
    "amount": 100.00,
    "transactionType": "Refund",
    "transactionDate": "2024-08-17T09:30:00.000Z",
    "description": "Refund",
    "status": "Completed"
  },
  {
    "id": "bca98765-4321-0987-6543-210987654321",
    "fromAccountId": "12345678-abcd-efgh-ijkl-9876543210mn",
    "toAccountId": "87654321-nmlk-jihg-fedc-1234567890op",
    "amount": 500.00,
    "transactionType": "Transfer",
    "transactionDate": "2024-08-16T14:15:00.000Z",
    "description": "Invoice payment",
    "status": "Completed"
  },
  {
    "id": "cde23456-7890-1234-5678-901234567890",
    "fromAccountId": "23456789-bcde-fghi-jklm-0987654321no",
    "toAccountId": "98765432-ponm-lkji-hgfe-2109876543qp",
    "amount": 75.00,
    "transactionType": "Transfer",
    "transactionDate": "2024-08-15T12:00:00.000Z",
    "description": "Gift",
    "status": "Completed"
  },
  {
    "id": "def34567-8901-2345-6789-012345678901",
    "fromAccountId": "34567890-cdef-ghij-klmn-1098765432op",
    "toAccountId": "87654321-qrst-uvwx-yzab-3456789012cd",
    "amount": 200.00,
    "transactionType": "Transfer",
    "transactionDate": "2024-08-14T08:45:00.000Z",
    "description": "Loan repayment",
    "status": "Completed"
  }
]
```

**Screenshot**
![TRANSACTION GETALL](https://github.com/user-attachments/assets/5581d113-6b28-44b8-a63d-228f5f2fbdd5)


---

#### 🔍 Get Transaction by ID

**Request:**

```
GET /api/transaction/abc12345-def6-7890-1234-56789abcdef0
```

**Sample Response (200 OK):**

```json
{
  "id": "abc12345-def6-7890-1234-56789abcdef0",
  "fromAccountId": "9bc42c45-6789-4def-8901-234567890abc",
  "toAccountId": "def56789-0123-4567-8901-23456789abcd",
  "amount": 250.00,
  "transactionType": "Transfer",
  "transactionDate": "2024-08-18T10:50:00.000Z",
  "description": "Payment for services",
  "status": "Completed"
}
```

---

**Request:**

```
GET /api/transaction/fed09876-5432-1098-7654-321098765432
```

**Sample Response (200 OK):**

```json
{
  "id": "fed09876-5432-1098-7654-321098765432",
  "fromAccountId": "def56789-0123-4567-8901-23456789abcd",
  "toAccountId": "9bc42c45-6789-4def-8901-234567890abc",
  "amount": 100.00,
  "transactionType": "Refund",
  "transactionDate": "2024-08-17T09:30:00.000Z",
  "description": "Refund",
  "status": "Completed"
}
```

---

**Request:**

```
GET /api/transaction/bca98765-4321-0987-6543-210987654321
```

**Sample Response (200 OK):**

```json
{
  "id": "bca98765-4321-0987-6543-210987654321",
  "fromAccountId": "12345678-abcd-efgh-ijkl-9876543210mn",
  "toAccountId": "87654321-nmlk-jihg-fedc-1234567890op",
  "amount": 500.00,
  "transactionType": "Transfer",
  "transactionDate": "2024-08-16T14:15:00.000Z",
  "description": "Invoice payment",
  "status": "Completed"
}
```
**Screenshot**
![Transaction GetById](https://github.com/user-attachments/assets/f4d42100-ba6b-47f9-9071-3d90583ae03e)

---



### ❌ Error Handling Examples

#### 🚫 Insufficient Funds Error
**Request:**
```json
POST /api/transaction/transfer
Content-Type: application/json

{
  "fromAccountNumber": "ACC638123456789",
  "toAccountNumber": "ACC638987654321",
  "amount": 5000.00,
  "description": "Large transfer"
}
```

**Sample Error Response (400 Bad Request):**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "Bad Request",
  "status": 400,
  "detail": "Insufficient funds",
  "traceId": "00-abc123def456789-012345678901234-00"
}
```

---

#### 🔍 Account Not Found Error
**Request:**
```
GET /api/account/invalid-account-id-12345
```

**Sample Error Response (404 Not Found):**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
  "title": "Not Found",
  "status": 404,
  "detail": "Account not found",
  "traceId": "00-def456abc789012-345678901234567-00"
}
```

---

#### 🚫 Validation Error
**Request:**
```json
POST /api/customer
Content-Type: application/json

{
  "name": "",
  "email": "invalid-email",
  "phone": ""
}
```

**Sample Error Response (400 Bad Request):**
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Name": ["The Name field is required."],
    "Email": ["The Email field is not a valid e-mail address."],
    "Phone": ["The Phone field is required."]
  },
  "traceId": "00-789012345abc678-901234567890123-00"
}
```

---

## 🧪 Testing

### Unit Test Results

> **📷 Screenshot Placeholder**: Terminal showing unit test execution results

<img width="1134" height="326" alt="Test" src="https://github.com/user-attachments/assets/ba5448b7-01ea-4c38-a1d6-15ba928407ab" />


**Expected Test Output:**
```
Test Run Successful.
Total tests: 3
     Passed: 3
 Total time: 4.7736 Seconds

✅ TransferMoney_ValidTransfer_ShouldSucceed
✅ TransferMoney_InsufficientFunds_ShouldThrowException  
✅ GetTransactionHistory_ValidAccountId_ShouldReturnTransactions
```

### 🧪 Running Tests

```bash
# Run all tests
dotnet test

# Run with detailed output
dotnet test --verbosity normal

# Run specific test class
dotnet test --filter "TransactionServiceTests"

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```


## 🤝 Contributing

### Development Workflow

1. **Fork** the repository
2. **Create** feature branch (`git checkout -b feature/amazing-feature`)
3. **Commit** changes (`git commit -m 'Add amazing feature'`)
4. **Push** to branch (`git push origin feature/amazing-feature`)
5. **Open** Pull Request

### Code Standards

- Follow **Microsoft C# Coding Conventions**
- Use **PascalCase** for public members, **camelCase** for private
- Add **XML documentation** for public APIs
- Maintain **minimum 80% test coverage**
- Follow **Clean Architecture** principles

### Pull Request Requirements

- [ ] All tests pass
- [ ] Code coverage maintained
- [ ] Documentation updated
- [ ] No breaking changes
- [ ] Performance impact assessed

---

### 🛠️ Troubleshooting

**Common Issues:**

1. **Port Already in Use**
   ```bash
   # Kill process using port
   netstat -ano | findstr :7xxx
   taskkill /PID <process-id> /F
   ```

2. **Package Restore Issues**
   ```bash
   # Clear NuGet cache
   dotnet nuget locals all --clear
   dotnet restore
   ```

3. **Build Errors**
   ```bash
   # Clean and rebuild
   dotnet clean
   dotnet build
   ```


---

<div align="center">

### 🌟 Author

Hari Ram L

[⬆ Back to Top](#-bankpro---bank-management-system)

</div>
