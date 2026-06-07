# 🚀 Foundations — C\#

Implementaciones de la [Fase 0 — Fundamentos](https://yorche3.github.io/programming_languages/ROADMAP/#fase-0--fundamentos--foundations--completada) en **C# (.NET 10)**: `helloworld`, `hellouser`, `unit_test/calculator` y `numbers`.

---

## 📖 Módulos / Modules

| Módulo | Especificación | Enfoque | Tests | Estado |
|--------|---------------|---------|:-----:|:------:|
| [`helloworld/`](helloworld/) | [01_Hello_World](https://yorche3.github.io/programming_languages/core/foundations/01_Hello_World/) | `dotnet run` (top-level statements) | — | ✅ |
| [`hellouser/`](hellouser/) | [02_Hello_User](https://yorche3.github.io/programming_languages/core/foundations/02_Hello_User/) | `dotnet run` (clase `Program` + `Main`) | — | ✅ |
| [`unit_test/calculator/`](unit_test/calculator/) | [03_Unit_Test_Calculator](https://yorche3.github.io/programming_languages/core/foundations/03_Unit_Test_Calculator/) | `dotnet test` + **xUnit** (solución `.slnx`) | 5 | ✅ |
| [`numbers/`](numbers/) | [04_Numbers](https://yorche3.github.io/programming_languages/core/foundations/04_Numbers/) | `dotnet test` + **xUnit** (solución `.slnx`) | 10 | ✅ |

---

## 📁 Estructura / Structure

```text
foundations/
├── helloworld/                   # 01_Hello_World
│   ├── Program.cs                # Top-level statements
│   ├── helloworld.csproj         # Proyecto .NET
│   └── README.md
│
├── hellouser/                    # 02_Hello_User
│   ├── Program.cs                # Clase Program + Main explícito
│   ├── hellouser.csproj          # Proyecto .NET
│   └── README.md
│
├── unit_test/
│   └── calculator/               # 03_Unit_Test_Calculator
│       ├── calculator.slnx       # Solución .NET
│       ├── src/
│       │   ├── Class1.cs         # 5 operaciones aritméticas
│       │   └── Calculator.csproj
│       ├── tests/
│       │   ├── UnitTest1.cs      # 5 tests con xUnit
│       │   └── Calculator.Tests.csproj
│       └── README.md
│
└── numbers/                      # 04_Numbers
    ├── numbers.slnx              # Solución .NET
    ├── src/
    │   └── Numbers/
    │       ├── Numbers.cs        # 15 funciones (3 enfoques × 5 algoritmos)
    │       └── Numbers.csproj
    ├── test/
    │   ├── NumbersRecursiveTests.cs   # 5 tests recursivos
    │   ├── NumbersIterativeTests.cs   # 5 tests iterativos
    │   └── Numbers.Test.csproj
    └── README.md
```

---

## 🛠️ Patrón común / Common Pattern

| Característica | Descripción |
|---------------|-------------|
| **SDK** | .NET 10.0 (`net10.0`) con `dotnet` CLI |
| **Proyectos simples** | `dotnet run` para `helloworld` y `hellouser` (sin solución) |
| **Proyectos con tests** | Solución `.slnx` con proyectos `src/` (biblioteca) y `tests/` o `test/` (xUnit) |
| **Framework de tests** | [xUnit](https://xunit.net/) v2.9.3 con `[Fact]` y `Assert.Equal` |
| **Detección de tests** | Automática — `dotnet test` descubre todos los `[Fact]` |
| **Paquetes NuGet** | `xunit`, `xunit.runner.visualstudio`, `Microsoft.NET.Test.Sdk`, `coverlet.collector` |
| **Top-level statements** | `helloworld` usa C# 9+ top-level statements (sin `Main` explícito) |
| **Estructura clásica** | `hellouser` usa `namespace`, `class Program`, `static void Main` |
| **Inmutabilidad** | Parámetros inmutables por defecto en C# (no se pueden reasignar) |

---

## 🚀 Compilación rápida / Quick Build

```bash
# Hello, World!
cd helloworld && dotnet run

# Hello, User!
cd hellouser && dotnet run

# Calculator Tests
cd unit_test/calculator && dotnet test calculator.slnx

# Numbers Tests
cd numbers && dotnet test numbers.slnx
```

---

### 🌐 Otras implementaciones / Other implementations

Este proyecto también está implementado en otros lenguajes. Explora el [repositorio principal](https://github.com/yorche3/programming_languages) para ver todas las versiones.

---

## ▶️ Siguiente / Next

👉 Después de fundamentos, continúa con [Fase 1 — Algoritmos Puros](https://yorche3.github.io/programming_languages/ROADMAP/#fase-1--algoritmos-puros--algorithms-pure-).  
👉 After foundations, continue with [Phase 1 — Algorithms Pure](https://yorche3.github.io/programming_languages/ROADMAP/#fase-1--algoritmos-puros--algorithms-pure-).

---

*[← Volver a C#](../../README.md)*

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
