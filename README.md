# AirlineBookingSystem — Microservice Architecture

## ✅ Technologies & Architecture

* **.NET**: .NET 8 + ASP.NET Core Web API
* **Database Access**: Dapper (SQL Server), MongoDB.Driver + LINQ
* **Messaging**: RabbitMQ + MassTransit
* **Architecture Style**: Microservices, Domain-Driven Design (DDD), SOLID principles, Clean Code / Clean Architecture

---

## 🛠️ Setup & Configuration

### Connection Strings

Add your connection strings to `appsettings.json` or environment variables:

```jsonc
{
  "ConnectionStrings": {
    "SqlServer": "Server=YOUR_SQL_SERVER;Database=YourDbName;User Id=USERNAME;Password=PASSWORD;",
    "MongoDb": "mongodb://USERNAME:PASSWORD@HOST:PORT/YourMongoDbName"
  },
  "RabbitMq": {
    "Host": "rabbitmq://localhost",
    "Username": "guest",
    "Password": "guest"
  }
}
```

### Using Dapper (SQL Server)

```csharp
using (var connection = new SqlConnection(configuration.GetConnectionString("SqlServer")))
{
    // Example: Query with Dapper
    var users = connection.Query<User>("SELECT * FROM Users");
}
```

### Using MongoDB

```csharp
var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
var database = client.GetDatabase("YourMongoDbName");
var collection = database.GetCollection<User>("Users");

// Example: LINQ query
var activeUsers = collection.AsQueryable().Where(u => u.IsActive).ToList();
```

### RabbitMQ + MassTransit

```csharp
builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri(configuration["RabbitMq:Host"]), h =>
        {
            h.Username(configuration["RabbitMq:Username"]);
            h.Password(configuration["RabbitMq:Password"]);
        });

        // Configure consumers, producers, endpoints
    });
});
```

---

## 🧩 Project Structure & Best Practices

* **Domain Layer**: Entities, Value Objects, Domain Services
* **Application Layer**: Use Cases, Services, Business Logic
* **Infrastructure Layer**: Data Access (Dapper / MongoDB), Messaging (MassTransit / RabbitMQ)
* **API Layer**: Controllers, Endpoints

**Key Principles:**

* DDD: Keep domain logic independent of infrastructure
* SOLID: Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion
* Clean Code: Readable, maintainable, testable

---

## 🚀 Running the Microservices

1. Start SQL Server, MongoDB, and RabbitMQ (local or remote).
2. Configure connection strings in `appsettings.json`.
3. Start each microservice:

   * SQL Server services: Use Dapper for queries/commands
   * MongoDB services: Use MongoDB.Driver with LINQ
   * Messaging: MassTransit handles async communication via RabbitMQ
4. Services communicate asynchronously; data access handled in the infrastructure layer.

---

## 📄 Sample `appsettings.json`

```json
{
  "ConnectionStrings": {
    "SqlServer": "Server=localhost;Database=AirlineBookingDb;User Id=sa;Password=YourStrong!Passw0rd;",
    "MongoDb": "mongodb://user:password@localhost:27017/AirlineBookingMongoDb"
  },
  "RabbitMq": {
    "Host": "rabbitmq://localhost",
    "Username": "guest",
    "Password": "guest"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```
Made with ArManDS with love.
---

## 📚 References

* [MassTransit Documentation](https://masstransit-project.com/)
* [Dapper Documentation](https://dapper-tutorial.net/)
* [MongoDB.Driver for C#](https://mongodb.github.io/mongo-csharp-driver/)
* [Clean Architecture & DDD Principles](https://jeffreypalermo.com/blog/the-clean-architecture/)

---

This README is ready for your **AirlineBookingSystem microservice project** and covers setup, architecture, and all key libraries/technologies.
