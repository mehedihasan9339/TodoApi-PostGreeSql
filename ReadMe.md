# TodoApi

This is a simple To-Do List API built with ASP.NET Core and PostgreSQL using Entity Framework Core.

## Table of Contents

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Database Migration](#database-migration)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)
- [Contributing](#contributing)
- [License](#license)

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

## Installation

1. **Create a new ASP.NET Core project:**

    ```sh
    dotnet new webapi -n TodoApi
    cd TodoApi
    ```

2. **Install the necessary NuGet packages:**

    ```sh
    dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
    dotnet add package Microsoft.EntityFrameworkCore.Design
    ```

## Configuration

1. **Set up your data model:**

    Create a `Models` folder and add the `TodoItem` class:

    ```csharp
    // Models/TodoItem.cs
    namespace TodoApi.Models
    {
        public class TodoItem
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public bool IsComplete { get; set; }
        }
    }
    ```

2. **Create the database context:**

    Create a `Data` folder and add the `TodoContext` class:

    ```csharp
    // Data/TodoContext.cs
    using Microsoft.EntityFrameworkCore;
    using TodoApi.Models;

    namespace TodoApi.Data
    {
        public class TodoContext : DbContext
        {
            public TodoContext(DbContextOptions<TodoContext> options)
                : base(options)
            {
            }

            public DbSet<TodoItem> TodoItems { get; set; }
        }
    }
    ```

3. **Update the PostgreSQL connection string in `appsettings.json`:**

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=todo;Username=yourusername;Password=yourpassword"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

4. **Update `Startup.cs` to configure the database context:**

    ```csharp
    // Startup.cs
    using Microsoft.EntityFrameworkCore;
    using TodoApi.Data;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<TodoContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
    ```

## Database Migration

1. **Install the EF Core tools if you haven't already:**

    ```sh
    dotnet tool install --global dotnet-ef
    ```

2. **Create the initial migration:**

    ```sh
    dotnet ef migrations add InitialCreate
    ```

3. **Update the database:**

    ```sh
    dotnet ef database update
    ```

## Running the Application

1. **Run the application:**

    ```sh
    dotnet run
    ```

2. The API will be accessible at `https://localhost:5001/api/todo` (or `http://localhost:5000/api/todo`).

## API Endpoints

- **Get all to-do items:**

    ```sh
    GET /api/todo
    ```

- **Get a specific to-do item:**

    ```sh
    GET /api/todo/{id}
    ```

- **Create a new to-do item:**

    ```sh
    POST /api/todo
    ```

    Request body:
    ```json
    {
      "name": "Sample Task",
      "isComplete": false
    }
    ```

- **Update an existing to-do item:**

    ```sh
    PUT /api/todo/{id}
    ```

    Request body:
    ```json
    {
      "id": 1,
      "name": "Updated Task",
      "isComplete": true
    }
    ```

- **Delete a to-do item:**

    ```sh
    DELETE /api/todo/{id}
    ```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
