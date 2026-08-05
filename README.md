# ERP Microservices

## Project Overview

ERP Microservices is an Enterprise Resource Planning (ERP) system developed using ASP.NET Core 10 Web API, Clean Architecture, Dapper, and SQL Server. The project follows a microservices architecture where each business module is developed as an independent service.

## Technologies Used

- ASP.NET Core 10 Web API
- C#
- Clean Architecture
- Microservices
- Dapper
- SQL Server
- Stored Procedures
- Swagger (OpenAPI)
- Git & GitHub

## Project Structure

ERP.Microservices
│
├── EnquiryService.API
├── EnquiryService.Application
├── EnquiryService.Domain
└── EnquiryService.Infrastructure

## Features Completed

### Enquiry Microservice

- Clean Architecture implemented
- Dapper integration
- SQL Server connectivity
- Repository Pattern
- Dependency Injection
- DTO implementation
- CRUD operations using Stored Procedures
- Soft Delete
- Restore Deleted Record
- Swagger API Documentation

## API Endpoints

| HTTP Method | Endpoint | Description |
|-------------|----------|-------------|
| GET | /api/Enquiry | Get all enquiries |
| GET | /api/Enquiry/{id} | Get enquiry by ID |
| POST | /api/Enquiry | Create a new enquiry |
| PUT | /api/Enquiry | Update an existing enquiry |
| DELETE | /api/Enquiry/{id} | Soft delete an enquiry |
| PUT | /api/Enquiry/restore/{id} | Restore deleted enquiry |

## Database

- SQL Server
- Stored Procedures
- Dapper ORM
- Foreign Key Relationships
- Soft Delete using DeletedAt
- Restore using RestoredAt

## Project Status

✔ Enquiry Microservice Completed

### Remaining Modules

- Master Service
- Lead Service
- Promotional Message Service
- API Gateway
- Authentication & Authorization
- JWT Authentication
- Logging
- Exception Handling

## Author

**Minakshi Gaike**# ERP.Microservices
# ERP.Microservices
