# Student Administration System
[![Build Status](https://dev.azure.com/Nielspilgaard/StudentAdministrationSystem/_apis/build/status/NillerMedDild.StudentAdministrationSystem?branchName=master)](https://dev.azure.com/Nielspilgaard/StudentAdministrationSystem/_build/latest?definitionId=2&branchName=master)

Student Administration System is an example project consisting of an ASP.NET Core WebApi, .NET Core backend for testing, and MySQL/Entity Framework database. It will eventually have multiple web frontends, made with React, MVC and Vue.

It's purpose is to act as a learning tool for myself, and a showcase of my development capabilities.

## Setup
- Fork, clone or download the solution.
- Run the `init-dev-env.ps1` script, found in the root directory.
- Open the solution with Visual Studio.
- Run the solution with the `docker-compose.sh` script, or run it through Visual Studio. Note, if you want to switch launch method, use the `docker-clear-containers.sh` script first, to remove old containers.

The local Swagger URL is `https://localhost:44304/swagger/index.html`, Visual Studio automatically launches it when the solution is run with Docker Compose.

### Program Dependencies
- Docker
- Visual Studio

### Containers
Student Administration System is currently divided into three docker containers, linked with Docker Compose.

#### Database
Contains the database of the system.\
*Uses MySQL 5.7*

#### WebApi
Handles the API that faciliates the communication between the frontend and the backend.\
*Uses ASP.NET Core 2.1*

#### Test
Handles unit testing of the backend
*Uses XUNIT 2.4.1*

#### Package Dependencies
- Microsoft.AspNetCore.All v2.2.4
- Microsoft.AspNetCore.App v2.2.4
- Microsoft.AspNetCore.Razor.Design v2.2.0
- Microsoft.EntityFrameworkCore.InMemory v2.2.4
- Microsoft.NETCore.App v2.2.4
- Microsoft.VisualStudio.Azure.Containers.Tools.Targets v1.5.4
- Pomelo.EntityFrameworkCore.MySql v2.2.0
- Swashbuckle.AspNetCore v4.0.1
- xunit v2.4.1
- xunit.runner.visualstudio v2.4.1


