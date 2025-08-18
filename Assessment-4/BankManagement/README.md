# 🏦 BankPro - Bank Management System

[![.NET](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)
[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://github.com)
[![Coverage](https://img.shields.io/badge/coverage-85%25-yellow.svg)](https://github.com)

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

## 📸 API Screenshots

### 🏠 Swagger UI Overview

> **📷 Screenshot Placeholder**: Swagger UI main page showing all available endpoints

*[Add screenshot of Swagger UI homepage here]*

---

### 👥 Customer Operations

#### ➕ Create Customer
**Request:**
```json
POST /api/customer
{
  "name": "John Doe",
  "email": "john.doe@email.com",
  "phone": "+1234567890"
}
```

> **📷 Screenshot Placeholder**: Swagger UI showing Create Customer request and response

*[Add screenshot of Create Customer API call here]*

**Expected Response:**
```json
{
  "id": "guid-here",
  "name": "John Doe",
  "email": "john.doe@email.com",
  "phone": "+1234567890",
  "createdAt": "2024-01-01T10:00:00Z"
}
```

---

#### 📋 Get All Customers
**Request:**
```
GET /api/customer
```

> **📷 Screenshot Placeholder**: Swagger UI showing Get All Customers response

*[Add screenshot of Get All Customers API call here]*

**Expected Response:**
```json
[
  {
    "id": "customer-guid-1",
    "name": "John Doe",
    "email": "john.doe@email.com",
    "phone": "+1234567890",
    "createdAt": "2024-01-01T10:00:00Z"
  },
  {
    "id": "customer-guid-2",
    "name": "Jane Smith",
    "email": "jane.smith@email.com",
    "phone": "+0987654321",
    "createdAt": "2024-01-01T11:00:00Z"
  }
]
```

---

### 💳 Account Operations

#### ➕ Create Account
**Request:**
```json
POST /api/account
{
  "customerId": "customer-guid-here",
  "initialBalance": 1000.00,
  "accountType": "Savings"
}
```

> **📷 Screenshot Placeholder**: Swagger UI showing Create Account request and response

*[Add screenshot of Create Account API call here]*

**Expected Response:**
```json
{
  "id": "account-guid-here",
  "accountNumber": "ACC638123456789",
  "customerId": "customer-guid-here",
  "balance": 1000.00,
  "accountType": "Savings",
  "createdAt": "2024-01-01T10:00:00Z",
  "isActive": true
}
```

---

#### 📋 Get Accounts by Customer
**Request:**
```
GET /api/account/customer/{customerId}
```

> **📷 Screenshot Placeholder**: Swagger UI showing Get Accounts by Customer response

*[Add screenshot of Get Accounts by Customer API call here]*

**Expected Response:**
```json
[
  {
    "id": "account-guid-1",
    "accountNumber": "ACC638123456789",
    "customerId": "customer-guid-here",
    "balance": 1000.00,
    "accountType": "Savings",
    "createdAt": "2024-01-01T10:00:00Z",
    "isActive": true
  },
  {
    "id": "account-guid-2",
    "accountNumber": "ACC638987654321",
    "customerId": "customer-guid-here",
    "balance": 500.00,
    "accountType": "Checking",
    "createdAt": "2024-01-01T11:00:00Z",
    "isActive": true
  }
]
```

---

### 💸 Transaction Operations

#### 💰 Transfer Money
**Request:**
```json
POST /api/transaction/transfer
{
  "fromAccountNumber": "ACC638123456789",
  "toAccountNumber": "ACC638987654321",
  "amount": 250.00,
  "description": "Payment for services"
}
```

> **📷 Screenshot Placeholder**: Swagger UI showing Transfer Money request and response

*[Add screenshot of Transfer Money API call here]*

**Expected Response:**
```json
{
  "id": "transaction-guid-here",
  "fromAccountId": "sender-account-id",
  "toAccountId": "receiver-account-id",
  "amount": 250.00,
  "transactionType": "Transfer",
  "transactionDate": "2024-01-01T10:00:00Z",
  "description": "Payment for services",
  "status": "Completed"
}
```

---

#### 📊 Get Transaction History
**Request:**
```
GET /api/transaction/history/{accountId}?page=1&pageSize=10
```

> **📷 Screenshot Placeholder**: Swagger UI showing Transaction History response

*[Add screenshot of Transaction History API call here]*

**Expected Response:**
```json
[
  {
    "id": "transaction-guid-1",
    "fromAccountId": "account-id",
    "toAccountId": "other-account-id",
    "amount": 250.00,
    "transactionType": "Transfer",
    "transactionDate": "2024-01-01T10:00:00Z",
    "description": "Payment for services",
    "status": "Completed"
  },
  {
    "id": "transaction-guid-2",
    "fromAccountId": "other-account-id",
    "toAccountId": "account-id",
    "amount": 100.00,
    "transactionType": "Transfer",
    "transactionDate": "2024-01-01T09:00:00Z",
    "description": "Refund",
    "status": "Completed"
  }
]
```

---

### ❌ Error Handling Examples

#### 🚫 Insufficient Funds Error
**Request:**
```json
POST /api/transaction/transfer
{
  "fromAccountNumber": "ACC638123456789",
  "toAccountNumber": "ACC638987654321",
  "amount": 5000.00,
  "description": "Large transfer"
}
```

> **📷 Screenshot Placeholder**: Swagger UI showing Insufficient Funds error response

*[Add screenshot of Insufficient Funds error here]*

**Expected Error Response:**
```json
{
  "error": "Insufficient funds",
  "statusCode": 400
}
```

---

#### 🔍 Account Not Found Error
**Request:**
```
GET /api/account/invalid-account-id
```

> **📷 Screenshot Placeholder**: Swagger UI showing Account Not Found error response

*[Add screenshot of Account Not Found error here]*

**Expected Error Response:**
```json
{
  "error": "Account not found",
  "statusCode": 404
}
```

---

## 🧪 Testing

### Unit Test Results

> **📷 Screenshot Placeholder**: Terminal showing unit test execution results

*[Add screenshot of `dotnet test` command output here]*

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