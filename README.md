# ERP.Microservices

## Project Overview

This project is an ERP (Enterprise Resource Planning) system developed using **.NET 10**, **ASP.NET Core Web API**, **Clean Architecture**, **Dapper**, **SQL Server**, and **Stored Procedures** following a **Microservices Architecture**.

Each module is developed independently using Repository Pattern, Dependency Injection, and Service Layer to keep the application loosely coupled and maintainable.

---

# Technology Stack

* .NET 10
* ASP.NET Core Web API
* C#
* SQL Server
* Dapper
* Stored Procedures
* Clean Architecture
* Repository Pattern
* Dependency Injection
* Swagger (OpenAPI)
* Git & GitHub

---

# Project Architecture

```
ERP.Microservices

│
├── LeadService
├── EnquiryService
├── CollegeLeadService
│
└── Shared Components
```

Each microservice follows Clean Architecture.

```
API
│
Application
│
Domain
│
Infrastructure
```

---

# Clean Architecture Structure

```
API
│
├── Controllers

Application
│
├── DTOs
├── Interfaces
└── Services

Domain
│
├── Entities
└── Interfaces

Infrastructure
│
├── Data
└── Repositories
```

---

# Modules Developed

## Lead Module

Implemented complete CRUD operations.

Features

* Get All Leads
* Get Lead By Id
* Create Lead
* Update Lead
* Soft Delete Lead
* Restore Lead

---

## College Lead Module

Implemented complete CRUD operations.

Features

* Get All College Leads
* Get College Lead By Id
* Create College Lead
* Update College Lead
* Soft Delete
* Restore

---

## Lead Source Module

Implemented complete CRUD operations.

Features

* Get All Lead Sources
* Get By Id
* Insert
* Update
* Delete
* Restore

---

## Enquiry Follow Up Module

Implemented complete CRUD operations.

Features

* Get All Follow Ups
* Get By Id
* Create Follow Up
* Update Follow Up
* Soft Delete
* Restore

---

## Enquiry For Module

Implemented complete CRUD operations.

Features

* Get All Enquiry Types
* Get By Id
* Create
* Update
* Soft Delete
* Restore

---

# Database

SQL Server database is used.

Tables created

* tblleads
* tblcollege_leads
* tbllead_sources
* tblenquiry_for
* tblenquiry_followups
* tblenquiries
* tblbranches
* tbltraining_topics
* tblpromotional_messages

---

# CRUD Operations

Every module supports

* GET All
* GET By Id
* POST
* PUT
* DELETE (Soft Delete)
* RESTORE

---

# Soft Delete

Instead of permanently deleting records, the project uses Soft Delete.

```
DeletedAt = GETDATE()
```

Restore API

```
DeletedAt = NULL
RestoredAt = GETDATE()
```

---

# Stored Procedures

All database operations are performed using Stored Procedures.

Operations included

* Insert
* Update
* Delete
* Restore
* Get All
* Get By Id

---

# Dapper

Dapper is used as the Micro ORM for executing Stored Procedures.

Configuration

```csharp
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
```

This automatically maps SQL columns such as

```
lead_id
```

to

```
LeadId
```

---

# API Testing

All APIs are tested using Swagger.

Implemented HTTP Methods

* GET
* POST
* PUT
* DELETE

---

# Design Patterns Used

* Clean Architecture
* Repository Pattern
* Dependency Injection
* Service Layer Pattern
* Microservices Architecture

---

# Learning Outcomes

During this project, I learned:

* Building REST APIs using ASP.NET Core
* Designing Microservices
* Clean Architecture implementation
* Repository Pattern
* Dependency Injection
* Dapper Integration
* SQL Stored Procedures
* Soft Delete Implementation
* Swagger API Testing
* Git & GitHub Version Control

---

# Future Improvements

* JWT Authentication
* Role Based Authorization
* Logging
* Validation
* Docker
* API Gateway
* RabbitMQ
* Redis Caching
* Unit Testing
* CI/CD Pipeline

---

# Author

**Minakshi Gaike**

.NET Full Stack Developer


