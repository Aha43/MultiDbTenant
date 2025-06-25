# Multi-Tenant Web API with Per-Tenant Databases and Clean Architecture

This sample demonstrates a **multi-tenant architecture** in .NET where:
- Each **tenant has its own dedicated database**
- A single HTTP API serves requests for all tenants
- **Non-HTTP workers**, such as Hangfire jobs, execute tenant-aware logic
- A clean separation exists between **business logic** and application layers

---

## 🏗️ Architecture Overview

This sample uses a **per-tenant database model**. Tenants are identified by ID, and each tenant's data is stored in a dedicated database with its own connection string.

### Key Features

- ✅ **Tenant resolution** via HTTP header (`X-Tenant-ID`)
- ✅ **Scoped tenant context** (`ITenantProvider`)
- ✅ **EF Core DbContext** instantiated with tenant-specific connection string
- ✅ **Clean architecture**: 
  - Business logic lives in services (application layer)
  - Infrastructure is swappable: used both in HTTP requests and background jobs
- ✅ **Hangfire integration** showing tenant-aware job execution

---

## 📂 Layers and Responsibilities

| Layer           | Description                                                                 |
|----------------|-----------------------------------------------------------------------------|
| `Controllers/`  | Web API controllers, resolve `IProductService`, no direct DB access        |
| `Services/`     | Business logic, tenant-agnostic, uses repository interfaces                |
| `Repositories/` | Infrastructure, uses EF Core with tenant-specific `DbContext`              |
| `Middleware/`   | HTTP context-based tenant resolution (`X-Tenant-ID`)                       |
| `Workers/`      | Hangfire job handlers with manually scoped service execution               |

---

## 🚦 How Tenant Context Works

1. **HTTP Requests**: A middleware reads the `X-Tenant-ID` header and sets it in the scoped `ITenantProvider`.
2. **DbContext Factory**: During request, the connection string is resolved for the tenant and used to instantiate a `TenantDbContext`.
3. **Background Jobs**: Manually create a DI scope, set the tenant ID, and resolve services just like in HTTP flow.

---

## 🧪 Example HTTP Request

```http
POST /api/products
X-Tenant-ID: tenant1
Content-Type: application/json

{ "name": "Example Product" }
