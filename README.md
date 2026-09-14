# C#

Proyectos en **C# (.NET 10)**, compilados y ejecutados con la CLI de `dotnet`, y con **xUnit** como framework de pruebas unitarias para los proyectos que las requieren.

---

## 📦 Requisitos / Requirements

| Herramienta | Instalación |
|-------------|-------------|
| [.NET SDK 10.0+](https://dotnet.microsoft.com/download) | `sudo apt install dotnet-sdk-10.0` (Linux) / `winget install Microsoft.DotNet.SDK.10` (Windows) |

```bash
# Verificar instalación
dotnet --version
```

---

## 🏗️ Tipos de proyecto / Project Types

### 1. Programa simple (`dotnet run`)

**ES:** Un único proyecto `.csproj` sin dependencias externas, ejecutado directamente con `dotnet run`. Ideal para `helloworld` y `hellouser`.

**EN:** A single `.csproj` project with no external dependencies, run directly with `dotnet run`. Ideal for `helloworld` and `hellouser`.

```bash
dotnet run
```

### 2. Proyecto con pruebas unitarias (solución `.slnx` + xUnit)

**ES:** Para proyectos que requieren pruebas unitarias, se usa una solución `.slnx` que agrupa un proyecto de biblioteca (`src/`) y un proyecto de tests (`tests/` o `test/`) con **xUnit**. `dotnet test` descubre automáticamente los métodos marcados con `[Fact]`.

**EN:** For projects that require unit tests, a `.slnx` solution groups a library project (`src/`) and a test project (`tests/` or `test/`) using **xUnit**. `dotnet test` automatically discovers methods marked with `[Fact]`.

```bash
dotnet test <solución>.slnx
```

---

## 📂 Módulos / Modules

| Módulo | Descripción |
|--------|-------------|
| [`core/foundations/`](core/foundations/) | **Fase 0 — Fundamentos**: `helloworld`, `hellouser`, `unit_test/calculator`, `numbers` |

---

### ▶️ Comenzar / Getting Started

```bash
# Hello, World!
cd core/foundations/helloworld
dotnet run

# Hello, User!
cd core/foundations/hellouser
dotnet run

# Calculator Tests
cd core/foundations/unit_test/calculator
dotnet test calculator.slnx

# Numbers Tests
cd core/foundations/numbers
dotnet test numbers.slnx
```

---

## 🌐 Otras implementaciones / Other implementations

Este proyecto también está implementado en otros lenguajes. Explora el [repositorio principal](https://github.com/yorche3/programming_languages) para ver todas las versiones.

---

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
