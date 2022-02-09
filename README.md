# Mass Intentions Management Tool - Frontend
> It's my university project for Software Architecture subject. This tool is intended to help people connected with Catholic Church in organising the data of masses.

## Main features:
- role / permissions system
- account registration and management
- editing, deleting and adding masses and their categories, users and their roles
- other typical CRUD operations

## Tech stack:
#### Frontend
- Vue 2
- Vue CLI
- Vue Router
- Axios
#### Backend
- .NET Core 6
- ASP.NET
- Entity Framework Core
- SQL Server
- Automapper
- NLog
- Swagger
- FluentValidation

## Project setup

#### Requirements
- SQL Server
- IIS Server or anything that will handle ASP.NET backend
- Node.js 14

#### In order to run it
1. Create a revelant SQL Server database
2. Clone this repo and run `dotnet build`
3. Run the backend `dotnet run`
4. Go [HERE](https://github.com/BordowyRydwan/mass-intentions-frontend) in order to get Vue frontend files
5. Run the frontend
