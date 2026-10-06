# Design patterns in RideKeeper

Patterns are introduced where they solve a real problem. This table is updated with each feature.

| Pattern | Where | Why |
|---|---|---|
| Dependency Injection | `DependencyInjection.cs` in each layer | Composition root wires layers; no layer creates its own dependencies. |
| Adapter (port and adapter) | `IDatabaseProbe` → `SqlServerDatabaseProbe` | Application depends on an interface; Infrastructure adapts EF Core to it. |
| Result | `Domain/Common/Result.cs` | Expected failures are values, not exceptions. |
| Null-object/clock abstraction | `TimeProvider` | Deterministic time in tests. |

## Planned

| Pattern | Planned use |
|---|---|
| Repository + Unit of Work + Specification | Persistence (Step 3) |
| Strategy | Due-status rules per interval type (km, months, whichever first) |
| Factory | Maintenance templates per bike type |
| Builder | Test data (e.g. `BikeBuilder`) |
| Decorator | Caching and logging around services |
| Observer / domain events | Reacting to odometer or service changes |
| Options | Typed configuration |
| Chain of responsibility | Validation pipeline |
