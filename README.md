# NET Core Playground 🧪

A sandbox for exploring modern .NET (.NET Core) development patterns: layered, message-based architecture with built‑in security best practices.

---

## 🏗️ Architecture Overview

This project demonstrates a clean, layered architecture using:

1. **Domain Layer** – domain models, business rules, value objects.
2. **Application Layer** – orchestrates use cases; handles commands & queries.
3. **Infrastructure Layer** – external concerns: persistence, messaging, security, logging.
4. **API Layer** – .NET Core Web API exposing endpoints for operations.

The system embraces a **message-based design**—workflows are composed of commands, events, and handlers—promoting decoupling, scalability, and testability.

Security best practices included:
- Authentication via ASP.NET Core Identity or JWT
- Role-based and policy-based authorization
- Secure handling of sensitive data (e.g. using options, protected storage)
- Logging and error handling via middleware

---

## 🚀 Getting Started

### Prerequisites
- [.NET SDK 7.0+](https://dotnet.microsoft.com/download)
- Optional: Docker (for containerized infrastructure)

### Clone and Build
```bash
git clone https://github.com/Taximu/net_core_playground.git
cd net_core_playground
dotnet build
```

### Run API Server
```bash
cd src/Api
dotnet run
```
➡️ The API will be hosted at `https://localhost:5001` by default.

---

## 🔧 Key Components

```
src/
├── Api/              → ASP.NET Core API project  
├── Application/      → Use-cases, command/query handlers  
├── Domain/           → Entities, value objects, domain logic  
└── Infrastructure/   → Implementations for DB, messaging, security, etc.
```

- **MessageBus**: In-memory/event-driven bus for commands & events  
- **EF Core**: For data persistence (Sqlite/PostgreSQL support)  
- **JWT/Auth**: Authentication and role/permission-based access  
- **Middleware**: Global exception handling, logging, model validation

---

## 🧪 Sample Usage

1. Register a new user via `POST /api/auth/register`
2. Log in to receive a JWT: `POST /api/auth/login`
3. Include `Authorization: Bearer <token>` in protected API calls
4. Submit a command, e.g. `POST /api/command/do-something`
5. Observe domain-handled workflow, event publication, persistence

---

## 🧩 Extending the Project

- Add new **Commands** or **Events** in the Application layer
- Implement new **Event Handlers** for side effects
- Plug in alternative **MessageBus** implementations (e.g. RabbitMQ/Kafka adapters)
- Switch databases (e.g., from Sqlite to PostgreSQL) in Infrastructure
- Enhance **Security**:
  - Add custom policies, claims transformation
  - Integrate OAuth2 / external identity providers

---

## 📋 Running Tests

Extensive unit and integration tests for all layers:
```bash
cd tests
dotnet test
```

---

## 🤝 Contributing

1. Fork the repo
2. Create a branch: `feature/your-feature`
3. Commit your changes  
4. Push to GitHub & open a Pull Request  
5. Ensure all tests pass and new code is well documented

---

## 📄 License

**MIT License** — see [LICENSE](LICENSE) for full details.

---

## 📬 Questions?

Feel free to open an issue or pull request. Happy coding! 🚀
