# Student Administration System
Student Administration System is an example project consisting of an ASP.NET Core frontend, .NET Core backend, and MySQL/Entity Framework database. 
It's purpose is to act as a learning tool for myself, and a showcase of my development capabilities.

##Docker
The server software uses docker as the platform to be deployed and maintaned on.

###Containers
Student Administration System is divided into three docker containers, linked with Docker Compose.

####Database
Contains the database of the system.\
**MySQL 5.7**

####WebApi
Handles the API that faciliates the communication between the frontend and the backend.\
**.NET Core 2.1**

####Dependencies
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