# 🚀 Algorithms Pure — C\#

Implementaciones de la [Fase 1 — Algoritmos Puros](https://yorche3.github.io/programming_languages/ROADMAP/#fase-1--algoritmos-puros--algorithms-pure-) en **C# (.NET 10)**: ordenamientos elementales, estructuras de datos propias, ordenamientos óptimos y distribuidos, y búsqueda.

Los módulos de esta fase usan **indicadores de fallo compatibles con el lenguaje** (`null` para tipos anulables, valor retornado) en lugar de excepciones.

---

## 📖 Módulos / Modules

| Módulo | Especificación | Enfoque | Tests | Estado |
|--------|---------------|---------|:-----:|:------:|
| [`naive_sort/`](naive_sort/) | [05_Naive_Sort](https://yorche3.github.io/programming_languages/core/algorithms/05_Naive_Sort/) | `dotnet test` + **xUnit** (solución `.slnx`) | 3 | ✅ |

---

## 📁 Estructura / Structure

```text
algorithms/
└── naive_sort/                       # 05_Naive_Sort
    ├── NaiveSort.slnx                # Solución .NET
    ├── src/
    │   └── NaiveSort/
    │       ├── NaiveSortImpl.cs      # selection_sort, bubble_sort, insertion_sort
    │       └── NaiveSort.csproj
    ├── test/
    │   └── NaiveSort.Tests/
    │       ├── NaiveSortTests.cs     # 3 tests (uno por algoritmo)
    │       └── NaiveSort.Tests.csproj
    ├── .gitignore
    └── README.md
```

---

## 🛠️ Patrón común / Common Pattern

| Característica | Descripción |
|---------------|-------------|
| **SDK** | .NET 10.0 (`net10.0`) con `dotnet` CLI |
| **Proyectos con tests** | Solución `.slnx` con proyectos `src/` (biblioteca) y `test/` (xUnit) |
| **Framework de tests** | [xUnit](https://xunit.net/) v2.9.3 con `[Fact]` y `Assert` |
| **Detección de tests** | Automática — `dotnet test` descubre todos los `[Fact]` |
| **Paquetes NuGet** | `xunit`, `xunit.runner.visualstudio`, `Microsoft.NET.Test.Sdk`, `coverlet.collector` |
| **Nulabilidad** | `<Nullable>enable</Nullable>`; el indicador de fallo se declara como `int[]?` |
| **Sin excepciones** | Las entradas inválidas retornan el indicador de fallo, no lanzan |

---

## 🚀 Compilación rápida / Quick Build

```bash
# Naive Sort Tests
cd naive_sort && dotnet test NaiveSort.slnx
```

---

### 🌐 Otras implementaciones / Other implementations

Este proyecto también está implementado en otros lenguajes. Explora el [repositorio principal](https://github.com/yorche3/programming_languages) para ver todas las versiones.

---

## ▶️ Siguiente / Next

👉 Continúa con los módulos pendientes de esta fase en el [Roadmap](https://yorche3.github.io/programming_languages/ROADMAP/).  
👉 Continue with the pending modules of this phase in the [Roadmap](https://yorche3.github.io/programming_languages/ROADMAP/).

---

*[← Volver a Core](../README.md)*

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
