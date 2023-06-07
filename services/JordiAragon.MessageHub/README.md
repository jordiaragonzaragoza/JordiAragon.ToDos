What is the MessageHub Project?
=====================
The MessageHub Project is a project written in .NET 7.

The goal of this project is create a microservice which responsibility is to send messages as abstract hub. This microservice is a part of ToDos project.

## How to use:
- You will need the latest Visual Studio 2022 and the latest .NET Core SDK.
- You will need also Docker Desktop running on your machine.
- To run the project just find and build the solution file JordiAragon.ToDos.sln and use docker-compose
- Also Create the database and schema with .NET Core CLI using update command like this:

```
dotnet ef database update -p /Users/jordiaragonzaragoza/GitHub/JordiAragon.TrainingSpace/Backend/Provisioned/JordiAragon.MessageHub/src/JordiAragon.MessageHub.Infrastructure.EntityFramework/JordiAragon.MessageHub.Infrastructure.EntityFramework.csproj -s /Users/jordiaragonzaragoza/GitHub/JordiAragon.TrainingSpace/Backend/Provisioned/JordiAragon.MessageHub/src/JordiAragon.MessageHub/JordiAragon.MessageHub.csproj --connection "Server=localhost;Database=JordiAragon.MessageHubDb;User Id=sa;Password=@someThingComplicated1234;Trusted_Connection=false;TrustServerCertificate=true;"
```

## Architecture:

- Full architecture with responsibility separation concerns, SOLID and Clean Code
- Clean Architecture (Onion Architecture with custom Shared Kernel)
- Vertical Slices by feature on each layer.
- Domain Driven Design
- Rich Domain Model with Aggregates and Strong Ids
- Domain/Application Events
- Domain/Application Events Notification
- Outbox Pattern
- CQRS with MediatR and FluentValidation
- Unit of Work
- Repository & Specification
- Domain UnitTests

## Technologies implemented:

- ASP.NET 7.0
 - ASP.NET Core WebApi with JWT Bearer Authentication
- Entity Framework Core 7.0
- MediatR
- AutoMapper
- Autofac
- MassTransit
- Ardalis Libraries
 - Ardalis.Result
 - Ardalis.Specification
 - Ardalis.SmartEnums
 - Ardalis.GuardClauses
- FluentValidator
- Serilog
- Quartz
- Swagger UI with JWT support
- CsvHelper
- Refit
- EasyCaching
- Google Maps API (Geocoding)
- StyleCop & SonarAnalyzer
- xUnit & FluentAssertions

## Features (Pending to complete)

**Feature**
- Detail.

## Resources and Inspiration

- <a href="https://github.com/ardalis/CleanArchitecture" target="_blank">Ardalis: Clean Architecture</a>
- <a href="https://www.youtube.com/watch?v=SUiWfhAhgQw" target="_blank">Jimmy Bogard: Vertical Slice Architecture</a>
- <a href="https://github.com/jasontaylordev/CleanArchitecture" target="_blank">Jason Taylor: Clean Architecture</a>
- <a href="https://github.com/dotnet-architecture/eShopOnContainers" target="_blank">Microsoft: eShopOnContainers</a>
- <a href="https://github.com/dotnet-architecture/eShopOnWeb" target="_blank">Microsoft: eShopOnWeb</a>
- <a href="https://github.com/kgrzybek/sample-dotnet-core-cqrs-api" target="_blank">Kamil Grzybek: Sample .NET Core REST API CQRS</a>
- <a href="https://github.com/kgrzybek/modular-monolith-with-ddd" target="_blank">Kamil Grzybek: Modular Monolith With DDD</a>

## About:

The MessageHub Project was developed by <a href="https://www.linkedin.com/in/jordiaragonzaragoza/" target="_blank">Jordi Aragón Zaragoza</a> 
