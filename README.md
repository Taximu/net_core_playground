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
