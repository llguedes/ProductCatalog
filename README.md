# Product Catalog API

A clean and lightweight **.NET 8 Web API** designed to demonstrate knowledge of Clean Architecture, Entity Framework Core, Dapper, Dependency Injection, RESTful design, and Swagger/OpenAPI documentation. This project is intentionally simple and ideal for interviews, technical assessments, or as a base for larger applications.

The solution follows a three-layer architecture:

```
ProductCatalog/
 ├── ProductCatalog.Domain/          → Entities + Repository Interfaces
 ├── ProductCatalog.Infrastructure/  → EF Core + Dapper Implementations
 └── ProductCatalog.Api/             → Web API (Controllers + DI + DbContext)
```

### Domain Layer
Contains the core business logic, including the `Product` entity and the repository interfaces `IProductRepository` and `IProductAnalyticsRepository`.

### Infrastructure Layer
Handles data persistence using EF Core and SQLite for CRUD operations, along with Dapper for high-performance SQL queries. This layer contains the `AppDbContext`, `ProductRepository`, and `ProductAnalyticsRepository`.

### API Layer
Exposes the REST endpoints, configures dependency injection, runs the database initialization, and serves the Swagger UI for API documentation.

## Getting Started

To restore dependencies:
```bash
dotnet restore
```

To build:
```bash
dotnet build
```

To run:
```bash
dotnet run --project ProductCatalog.Api/ProductCatalog.Api.csproj
```

After starting the API, open Swagger UI at:
```
http://localhost:5124/swagger
```

## Endpoints

### Products (EF Core)
- `GET /api/products`
- `GET /api/products/{id}`
- `POST /api/products`
- `PUT /api/products/{id}`
- `DELETE /api/products/{id}`

### Analytics (Dapper)
- `GET /api/products/analytics/summary`

Example response:
```json
{
  "totalProducts": 12,
  "totalStock": 240,
  "averagePrice": 199.99
}
```

## Technologies Used

- .NET 8 Web API  
- Entity Framework Core  
- SQLite  
- Dapper  
- Swagger / Swashbuckle.AspNetCore  
- Clean Architecture principles  
