# RideKeeper

Motorcycle ownership app: maintenance due-status, documents and expiry, fuel and costs, history timeline.

## Architecture

Clean Architecture; dependencies point inwards only (enforced by `tests/RideKeeper.ArchitectureTests`).

```
Api ──► Application ──► Domain
 └────► Infrastructure ──► Application
```

| Project | Responsibility |
|---|---|
| `RideKeeper.Domain` | Entities, value objects, domain rules. No dependencies. |
| `RideKeeper.Application` | Use cases (services), DTOs, ports (interfaces). |
| `RideKeeper.Infrastructure` | EF Core + SQL Server, adapters for external services. |
| `RideKeeper.Api` | Controllers, DI composition root, OpenAPI. |

Other folders: `apps/web`, `apps/mobile`, `packages/api-client` (later steps), `docs/`.

## Getting started

Requirements: .NET 10 SDK, Docker.

```bash
dotnet build
dotnet test                       # integration tests need Docker running
docker compose up -d sqlserver    # local dev database
dotnet run --project src/RideKeeper.Api   # API reference at http://localhost:5080/scalar/v1
```

On Apple Silicon, enable Rosetta for x86/amd64 emulation in Docker Desktop (SQL Server image is amd64).

## Branch workflow

- `develop` is the default branch; everything is tested here.
- `main` holds tested, tagged releases (merge commit from `develop`).
- `feature/<user-story-name>` and `bugfix/<bug-name>` branch from `develop` and are squash-merged via PR.
- Commits follow Conventional Commits. CI (build, unit, architecture and integration tests) must pass.

See [docs/patterns.md](docs/patterns.md) for the design patterns used and where.
