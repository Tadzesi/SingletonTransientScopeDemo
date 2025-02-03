# Singleton, Transient, and Scoped Service Demo

This project demonstrates the differences between **Singleton**, **Transient**, and **Scoped** services in an ASP.NET Core Web API. It shows how different service lifetimes behave when injected into controllers.

## 📌 Features

- Uses **Singleton**, **Transient**, and **Scoped** service lifetimes.
- Provides an API endpoint to observe how these lifetimes impact object creation.
- Implements **Swagger/OpenAPI** for API documentation.
- Uses dependency injection in ASP.NET Core.

## 📁 Project Structure

```
tadzesi-singletontransientscopedemo/
├── Controllers/
│   └── ServicesController.cs   # API Controller to test services
├── Interfaces/
│   └── IBaseService.cs         # Base interface for all services
├── Services/
│   ├── ScopedService.cs        # Scoped service implementation
│   ├── SingletonService.cs     # Singleton service implementation
│   ├── TransientService.cs     # Transient service implementation
│   ├── ServiceType.cs          # Enum for service types
├── appsettings.json            # Application settings
├── Program.cs                  # Application entry point
├── SingletonTransientScopeDemo.csproj  # Project file
└── SingletonTransientScopeDemo.sln     # Solution file
```

## 🚀 Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or another IDE supporting .NET)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-repo-url.git
   cd tadzesi-singletontransientscopedemo
   ```

2. Restore dependencies:
   ```sh
   dotnet restore
   ```

3. Run the application:
   ```sh
   dotnet run
   ```

4. Use `SingletonTransientScopeDemo.http` file to call the controller.

## 🛠 Service Lifetimes Explanation

| Service Type  | Lifetime Behavior |
|--------------|------------------|
| **Singleton**  | A single instance is created and shared across all requests. |
| **Scoped**    | A new instance is created for each request. |
| **Transient** | A new instance is created every time it's requested. |

## 📡 API Usage

### Endpoint: `GET /services`
Returns JSON showing the `Id` and `ServiceType` for each service instance.

Example response:
```json
{
  "singleton1": {
    "id": "3c3a346a-c516-40c6-a1c8-c56177f9a4b4",
    "type": "Singleton",
    "explanation": "Singleton services truly remain singleton"
  },
  "singleton2": {
    "id": "3c3a346a-c516-40c6-a1c8-c56177f9a4b4",
    "type": "Singleton",
    "explanation": "Singleton services truly remain singleton"
  },
  "scoped1": {
    "id": "4b55d90b-22cb-4119-869c-97d7263a96c3",
    "type": "Scoped",
    "explanation": "Scoped services are scoped to the HTTP request"
  },
  "scoped2": {
    "id": "4b55d90b-22cb-4119-869c-97d7263a96c3",
    "type": "Scoped",
    "explanation": "Scoped services are scoped to the HTTP request"
  },
  "transient1": {
    "id": "12c960c6-002e-4aac-a682-6942454e57f8",
    "type": "Transient",
    "explanation": "Transient services are new instances every time"
  },
  "transient2": {
    "id": "40ed11bd-856f-4cc4-9d4e-6f9a8ba18a11",
    "type": "Transient",
    "explanation": "Transient services are new instances every time"
  }
}
```

## 🏗 How It Works

- The services are registered in `Program.cs`:
  ```csharp
  builder.Services.AddKeyedSingleton<IService, SingletonService>(ServiceType.Singleton);
  builder.Services.AddKeyedScoped<IService, ScopedService>(ServiceType.Scoped);
  builder.Services.AddKeyedTransient<IService, TransientService>(ServiceType.Transient);
  ```
- The `ServicesController` injects each service twice to compare their behavior.
- The API returns a JSON response showing whether instances are reused or newly created.

## 📝 License

This project is open-source and available under the MIT License.

---
🚀 **Happy Coding!**

