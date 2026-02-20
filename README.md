# Presence Logging Service (Employee Time Tracking API)

RESTful Web API for managing employees, roles (positions), and tracking work shifts (check-in / check-out).

Built with **.NET 9**, **ASP.NET Core Web API**, **Entity Framework Core**, and **SQLite**.

---

## Overview

Presence Logging Service is a backend system for:

- Managing HR roles (positions)
- Managing employees
- Assigning roles to employees
- Tracking employee shifts (start / end)
- Retrieving employees by role

The project is API-only and fully documented with **Swagger (OpenAPI 3.0)**.

---

## Tech Stack

- **.NET 9**
- **ASP.NET Core Web API**
- **Entity Framework Core 9**
- **SQLite**
- **AutoMapper**
- **Swashbuckle (Swagger UI)**

### NuGet Packages

- AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.1)
- Microsoft.AspNetCore.OpenApi (9.0.4)
- Microsoft.EntityFrameworkCore (9.0.6)
- Microsoft.EntityFrameworkCore.Sqlite (9.0.6)
- Microsoft.EntityFrameworkCore.Tools (9.0.6)
- Swashbuckle.AspNetCore (9.0.1)

---

## API Endpoints

### HrDepartment – Roles

```
GET     /api/HrDepartment/role
POST    /api/HrDepartment/role
PUT     /api/HrDepartment/role
GET     /api/HrDepartment/role/{id}
DELETE  /api/HrDepartment/role/{id}
```


### HrDepartment – Employees

```
GET     /api/HrDepartment/employee
POST    /api/HrDepartment/employee
PUT     /api/HrDepartment/employee
GET     /api/HrDepartment/employee/{id}
DELETE  /api/HrDepartment/employee/{id}
GET     /api/HrDepartment/employee/get-employees-by-role/{roleId}
```


### SecurityCheckpoint – Shift Management

```

POST    /api/SecurityCheckpoint/start-shift/{employeeId}
POST    /api/SecurityCheckpoint/end-shift/{employeeId}

```


---

## Data Models

The API uses structured DTOs and entities:

- `Employee`
- `EmployeeCreateDto`
- `EmployeeReadDto`
- `EmployeeUpdateDto`
- `Role`
- `RoleCreateDto`
- `RoleReadDto`
- `RoleUpdateDto`
- `Shift`
- `StartShiftRequest`
- `EndShiftRequest`

---

## Swagger UI

The API includes full OpenAPI 3.0 documentation.

After running the project, access Swagger at:

```
[https://localhost:5120/swagger](https://localhost:5120/swagger)
````


### Swagger Screenshot

![Swagger UI](Screenshots/Swagger-UI.png)

The screenshot shows:

- Role management endpoints
- Employee management endpoints
- Shift start / end endpoints
- All request and response schemas

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/YOUR_USERNAME/YOUR_REPOSITORY.git
cd YOUR_REPOSITORY
````

### 2. Apply database migrations

```bash
dotnet ef database update
```

### 3. Run the API

```bash
dotnet run
```

Swagger will be available at:

```
https://localhost:5120/swagger
```

---

## Architecture

* Clean RESTful design
* DTO-based request/response models
* AutoMapper for mapping
* EF Core with SQLite provider
* Code-first approach
* Layered structure (Controllers / Models / DTOs / Data)

---

## License

MIT License

---

## Author

Sheroz Puladov
Email: [sherozpulatov3@gmail.com](mailto:sherozpulatov3@gmail.com)
GitHub: [https://github.com/YOUR_USERNAME](https://github.com/YOUR_USERNAME)
