# SimpleBlogEngine, a simple, cross platform, system built on .NET Core

## Visual Studio 2017 and SQL Server

#### Prerequisites

- SQL Server
- [Visual Studio 2017 version 15.3 with .NET Core SDK 2.0](https://www.microsoft.com/net/core/)

#### Steps to run

- Update the connection string in appsettings.json.
- Build whole solution.
- Open Package Manager Console Window and type:
    + "cd .\SimpleBlogEngine". This action will detect the "dotnet ef" command and fix the issue "dotnet : No executable found matching command "dotnet-ef""
    + "dotnet ef migrations add SimpleBlogEngine" then press "Enter". This action will create database schema.
    + "dotnet ef database update" to create the database.
- In Visual Studio, press "Control + F5".

## Technologies and frameworks used:
- ASP.NET MVC Core 2.0.0 on .NET Core 2.0.0 
- Entity Framework Core 2.0.0
- ASP.NET Identity Core 2.0.0

## How to contribute

- Report bugs or suggest features by create new issues or add comments to issues
- Submit pull requests

## License

SimpleBlogEngine is licensed under the Apache 2.0 license.