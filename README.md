# TodoApi

A RESTful Todo List backend built with **ASP.NET Core 8**, **MongoDB**, and **Docker**, following **Layered Architecture** principles.

---

## 🏗️ Architecture

```
TodoApi/
├── TodoApi.API/            # Presentation Layer  — Controllers, Middleware, Program.cs
├── TodoApi.Application/    # Application Layer   — Services, DTOs, Validators
├── TodoApi.Domain/         # Domain Layer        — Entities, Interfaces, Exceptions
└── TodoApi.Infrastructure/ # Infrastructure Layer — MongoDB, Repositories, UnitOfWork
```

### Dependency Flow

```
API  →  Application  →  Domain
 ↓                        ↑
Infrastructure  ──────────┘
```

| Layer              | Responsibilities                                 | Dependencies                 |
| ------------------ | ------------------------------------------------ | ---------------------------- |
| **Domain**         | Entities, Exceptions, Repository Interfaces      | None                         |
| **Application**    | Services, DTOs, Validators, Service Interfaces   | Domain                       |
| **Infrastructure** | MongoDB implementation, Repositories, UnitOfWork | Domain                       |
| **API**            | Controllers, Middleware, DI registration         | Application + Infrastructure |

---

## ✨ Features

- ✅ **Layered Architecture** — Clean separation of concerns
- ✅ **Exception Middleware** — All exceptions handled centrally with unified response format
- ✅ **Dependency Injection** — All services managed via DI with proper lifetimes
- ✅ **MongoDB Transactions** — Multi-collection operations wrapped in transactions
- ✅ **Fluent Validation** — All request data validated with FluentValidation
- ✅ **XML Documentation** — All interfaces and controllers documented with XML comments
- ✅ **Swagger UI** — Interactive API documentation with XML comment integration
- ✅ **Docker** — MongoDB hosted in Docker with persistent volume

---

## 🛠️ Tech Stack

| Technology                  | Version | Purpose            |
| --------------------------- | ------- | ------------------ |
| ASP.NET Core                | 8.0     | Web API framework  |
| MongoDB.Driver              | Latest  | MongoDB client     |
| FluentValidation.AspNetCore | Latest  | Request validation |
| Swashbuckle.AspNetCore      | Latest  | Swagger / OpenAPI  |
| Docker                      | Latest  | MongoDB container  |

---

## 📁 Project Structure

```
TodoApi/
├── TodoApi.sln
├── docker-compose.yml
│
├── TodoApi.Domain/
│   ├── Entities/
│   │   ├── BaseEntity.cs
│   │   ├── TodoItem.cs
│   │   └── TodoTag.cs
│   ├── Exceptions/
│   │   └── AppException.cs
│   └── Interfaces/
│       ├── IBaseRepository.cs
│       ├── ITodoRepository.cs
│       ├── ITagRepository.cs
│       └── IUnitOfWork.cs
│
├── TodoApi.Application/
│   ├── DTOs/
│   │   ├── CreateTodoDto.cs
│   │   ├── UpdateTodoDto.cs
│   │   └── TodoResponseDto.cs
│   ├── Validators/
│   │   ├── CreateTodoValidator.cs
│   │   └── UpdateTodoValidator.cs
│   ├── Interfaces/
│   │   └── ITodoService.cs
│   ├── Services/
│   │   └── TodoService.cs
│   └── Extensions/
│       └── ApplicationServiceExtensions.cs
│
├── TodoApi.Infrastructure/
│   ├── Settings/
│   │   └── MongoDbSettings.cs
│   ├── Persistence/
│   │   ├── MongoDbContext.cs
│   │   └── UnitOfWork.cs
│   ├── Repositories/
│   │   ├── BaseRepository.cs
│   │   ├── TodoRepository.cs
│   │   └── TagRepository.cs
│   └── Extensions/
│       └── InfrastructureServiceExtensions.cs
│
└── TodoApi.API/
    ├── Controllers/
    │   └── TodoController.cs
    ├── Middleware/
    │   └── ExceptionMiddleware.cs
    ├── Responses/
    │   ├── ApiResponse.cs
    │   └── ApiErrorResponse.cs
    ├── appsettings.json
    └── Program.cs
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### 1. Clone the repository

```bash
git clone <your-repo-url>
cd TodoApi
```

### 2. Start MongoDB with Docker

```bash
docker-compose up -d
```

MongoDB will be available at `mongodb://localhost:27017`

### 3. Run the API

```bash
cd TodoApi.API
dotnet run
```

### 4. Open Swagger UI

Navigate to: [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## 📡 API Endpoints

| Method   | Endpoint          | Description            |
| -------- | ----------------- | ---------------------- |
| `GET`    | `/api/todos`      | Get all todo items     |
| `GET`    | `/api/todos/{id}` | Get a single todo item |
| `POST`   | `/api/todos`      | Create a new todo item |
| `PUT`    | `/api/todos/{id}` | Update a todo item     |
| `DELETE` | `/api/todos/{id}` | Delete a todo item     |

---

## 📦 Unified Response Format

### Success Response

```json
{
  "success": true,
  "data": { ... }
}
```

### Error Response

```json
{
  "success": false,
  "statusCode": 400,
  "message": "Validation failed",
  "errors": ["Title is required", "Title must not exceed 100 characters"]
}
```

---

## 🔄 DI Service Lifetimes

| Service          | Lifetime  | Reason                            |
| ---------------- | --------- | --------------------------------- |
| `MongoClient`    | Singleton | Shared across entire app          |
| `MongoDbContext` | Singleton | Wraps MongoClient                 |
| `TodoRepository` | Scoped    | Per HTTP request                  |
| `TagRepository`  | Scoped    | Per HTTP request                  |
| `UnitOfWork`     | Scoped    | Per HTTP request (shares session) |
| `TodoService`    | Scoped    | Per HTTP request                  |

---

## 🐳 Docker

### docker-compose.yml

```yaml
services:
  mongodb:
    image: mongo:7.0
    container_name: todo_mongodb
    ports:
      - "27017:27017"
    environment:
      MONGO_INITDB_ROOT_USERNAME: root
      MONGO_INITDB_ROOT_PASSWORD: password
      MONGO_INITDB_DATABASE: TodoDb
    volumes:
      - mongo_data:/data/db

volumes:
  mongo_data:
```

---

## 📋 Task Progress

### Phase 1 — 环境准备

- [x] 安装 .NET 8 SDK
- [x] 安装 Docker Desktop
- [x] 安装开发工具

### Phase 2 — 项目初始化

- [x] 创建 Solution
- [x] 创建 TodoApi.Domain
- [x] 创建 TodoApi.Application
- [x] 创建 TodoApi.Infrastructure
- [x] 创建 TodoApi.API
- [x] 设定项目引用关系
- [x] 安装 NuGet 套件
- [x] 建立目录结构

### Phase 3 — Docker 设置

- [ ] 写 docker-compose.yml
- [ ] 设定 MongoDB 环境变量
- [ ] 启动并验证 MongoDB container

### Phase 4 — Domain 层

- [ ] 建立 BaseEntity
- [ ] 建立 TodoItem model
- [ ] 建立 TodoTag model
- [ ] 建立 AppException
- [ ] 建立 IBaseRepository
- [ ] 建立 ITodoRepository
- [ ] 建立 ITagRepository
- [ ] 建立 IUnitOfWork

### Phase 5 — Infrastructure 层

- [ ] 建立 MongoDbSettings
- [ ] 建立 MongoDbContext
- [ ] 实作 BaseRepository
- [ ] 实作 TodoRepository
- [ ] 实作 TagRepository
- [ ] 实作 UnitOfWork
- [ ] 建立 InfrastructureServiceExtensions

### Phase 6 — Application 层

- [ ] 建立 TodoResponseDto
- [ ] 建立 CreateTodoDto + Validator
- [ ] 建立 UpdateTodoDto + Validator
- [ ] 建立 ITodoService
- [ ] 实作 TodoService
- [ ] 建立 ApplicationServiceExtensions

### Phase 7 — API 层

- [ ] 建立 ApiResponse
- [ ] 建立 ApiErrorResponse
- [ ] 建立 ExceptionMiddleware
- [ ] 建立 TodoController
- [ ] 配置 Program.cs

### Phase 8 — 测试验证

- [ ] 验证 Swagger UI
- [ ] 测试所有 CRUD endpoint
- [ ] 测试 FluentValidation
- [ ] 测试 Exception Middleware
- [ ] 测试 Transaction 回滚

### Phase 9 — Docker 化（进阶）

- [ ] 写 Dockerfile
- [ ] 更新 docker-compose.yml
- [ ] 测试容器化环境
