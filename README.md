## BigLittleBuy


BigLittleBuy, a cloud ready e-commerce platform. The ultimate aim of this project is to small support businesses reaching a local (or global) community for their products and services.

Ultimately this software should be able to host a single store, or any number of stores, given the right underlying cloud infrastructure.

This repository contains the API, Domain / data layer and related unit tests. The UI will be served from a different repository.

This project is licensed under GPLv3, please see the included LICENSE.MD file for the full details.

### Tech Stack

The tech stack is comprised of

  1. A dotnet core (C#) API layer, including EF Core for code-first database design
  2. PostgreSQL for the database
  3. Redis for in-memory caching
  4. xUnit for the unit testing framework
  5. React as the front-end UI framework

We're starting small, but dreaming big :-) 


### Getting Started With Development - Local Machine

  1. Make sure you have PostgreSQL installed (at least version 10.x) and create an empty database called "BigLittleBuy"
  2. Make sure that you have dotnet core SDK 3.1.x installed
  3. Install entity framework core if you have not done so already using `dotnet tool install --global dotnet-ef`
  4. On a command prompt (Powershell, Git bash or even cmd) create an environment variable to contain your db connection string. On windows this should be something like: 
   `set BLBConnectionString=Username=postgres;Password=postgrespassword;Host=localhost;Port=5432;Database=BigLittleBuy;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;`
  5. From the BLB.Domain.Net directory run the database migrations: `dotnet ef database update --startup-project ..\BLB.Api.Net\BLB.Api.Net.csproj`
  6. MORE TO COME...
  

### Getting Started - Docker
