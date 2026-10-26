# ExpenseTracker.API 💰

A RESTful Web API built with ASP.NET Core 8 for managing personal expenses and categories.

This project demonstrates backend development using C#, Entity Framework Core, SQL Server, and a layered architecture.

## 🛠 Technologies

- C# / .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- LINQ
- Swagger / OpenAPI
- xUnit
- Moq

## 🚀 Features

- Create, read, update, and delete expenses
- Manage expense categories
- Filter expenses by category and date range
- Calculate total expenses
- Generate expense statistics using LINQ
- Validate input data
- Handle errors using custom exceptions and middleware
- Unit testing with xUnit and Moq

## 🏗 Architecture

The application follows a layered architecture:

Controller → Service → Repository → Database

**Controllers:** Handle HTTP requests and responses.

**Services:** Implement business logic and validation.

**Repositories:** Handle database operations using Entity Framework Core.

**DTOs:** Transfer data between application layers.

**Middleware:** Provides centralized exception handling.

## 🧪 Unit Tests

The project includes unit tests covering:

- Invalid date ranges
- Retrieving expenses within a valid period
- Handling empty expense lists
- Preventing expense creation when a category does not exist

## ⚙️ Getting Started

1. Clone the repository.
2. Open `ExpenseTracker.API.sln` in Visual Studio.
3. Configure the SQL Server connection string in `appsettings.json`.
4. Apply Entity Framework Core migrations.
5. Run the API project.
6. Open Swagger UI to explore and test the endpoints.

## 📌 Project Purpose

This project was developed to strengthen practical skills in C#, ASP.NET Core, REST API development, Entity Framework Core, LINQ, dependency injection, and unit testing.
