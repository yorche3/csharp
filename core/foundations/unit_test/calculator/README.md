# Calculator — C\#

Implementación de la especificación [03_Unit_Test_Calculator](https://yorche3.github.io/programming_languages/core/foundations/03_Unit_Test_Calculator/) en **C# (.NET 10)**, usando **xUnit** como framework de pruebas unitarias.

---

## 📂 Archivos y estructura / Files & Structure

### Raíz del proyecto / Project root

| Archivo | Propósito |
|---------|-----------|
| [`calculator.slnx`](calculator.slnx) | Archivo de solución .NET — referencia los proyectos `src/` y `tests/`. |

### Código fuente / Source (`src/`)

| Archivo | Propósito |
|---------|-----------|
| [`src/Class1.cs`](src/Class1.cs) | Clase `Calculator.Class1` — implementa las 5 operaciones aritméticas. |
| [`src/Calculator.csproj`](src/Calculator.csproj) | Proyecto de biblioteca de clases — target `net10.0`. |

### Pruebas / Tests (`tests/`)

| Archivo | Propósito |
|---------|-----------|
| `tests/UnitTest1.cs` | Pruebas unitarias — 5 tests con atributos `[Fact]` de xUnit. |
| `tests/Calculator.Tests.csproj` | Proyecto de tests — referencia `src/Calculator.csproj` y paquetes NuGet (xUnit, coverlet). |

**Estructura de directorios esperada:**

```text
calculator/
├── calculator.slnx              # Solución .NET
├── src/
│   ├── Class1.cs                # Clase con 5 operaciones aritméticas
│   └── Calculator.csproj        # Proyecto de biblioteca
├── tests/
│   ├── UnitTest1.cs             # Tests unitarios (5 tests)
│   └── Calculator.Tests.csproj  # Proyecto de tests
├── .gitignore                   # Ignora bin/, obj/
└── README.md                    # Este archivo
```

---

## 🛠️ Enfoque y construcción / Approach & Build

**ES:** Este proyecto usa **xUnit**, el framework de pruebas unitarias moderno para .NET:

1. Los métodos de prueba se marcan con el atributo `[Fact]`.
2. Las aserciones usan `Assert.Equal(expected, actual)`.
3. El descubrimiento de tests es automático: `dotnet test` encuentra todos los `[Fact]`.
4. Se usa una solución `.slnx` para agrupar los proyectos de biblioteca y tests.

**EN:** This project uses **xUnit**, the modern unit testing framework for .NET:

1. Test methods are marked with the `[Fact]` attribute.
2. Assertions use `Assert.Equal(expected, actual)`.
3. Test discovery is automatic: `dotnet test` finds all `[Fact]` methods.
4. A `.slnx` solution groups the library and test projects.

### Estructura de la solución / Solution structure

```text
calculator.slnx
├── src/Calculator.csproj         # Biblioteca de clases
└── tests/Calculator.Tests.csproj # Proyecto de tests (referencia a src/)
```

---

## 📄 Archivos de configuración clave / Key Configuration Files

### `src/Class1.cs` — Módulo principal

**ES:** Contiene la clase `Class1` con las 5 operaciones aritméticas. Usa **expression-bodied members** (`=>`) para métodos simples.

**EN:** Contains the `Class1` class with the 5 arithmetic operations. Uses **expression-bodied members** (`=>`) for simple methods.

```csharp
namespace Calculator;

public class Class1
{
    public int Addition(int a, int b) => a + b;
    public int Subtraction(int a, int b) => a - b;

    public int Multiplication(int a, int b)
    {
        int result = 0;
        for (int i = 0; i < b; i++)
        {
            result = Addition(result, a);
        }
        return result;
    }

    public int Division(int a, int b)
    {
        int quotient = 0;
        while (a >= b)
        {
            a = Subtraction(a, b);
            quotient = Addition(quotient, 1);
        }
        return quotient;
    }

    public int Modulus(int a, int b)
    {
        int quotient = Division(a, b);
        return Subtraction(a, Multiplication(quotient, b));
    }
}
```

| Elemento | Propósito |
|----------|-----------|
| `namespace Calculator;` | Declaración de namespace (file-scoped, C# 10+) |
| `public int Add(int a, int b) => a + b;` | Expression-bodied method |
| `for (int i = 0; i < b; i++)` | Suma repetitiva para multiplicación |
| `while (a >= b)` | Resta repetitiva para división |

### `tests/UnitTest1.cs` — Pruebas unitarias (xUnit)

**ES:** Cada método `[Fact]` prueba una operación. Usa `Assert.Equal` para verificar resultados.

**EN:** Each `[Fact]` method tests one operation. Uses `Assert.Equal` to verify results.

```csharp
using Xunit;
using Calculator;

namespace Calculator.Tests;

public class UnitTest1
{
    Class1 calculator = new Class1();

    [Fact]
    public void TestAddition()
    {
        Assert.Equal(5, calculator.Addition(2, 3));
    }

    [Fact]
    public void TestMultiplication()
    {
        Assert.Equal(12, calculator.Multiplication(3, 4));
    }

    [Fact]
    public void TestDivision()
    {
        Assert.Equal(3, calculator.Division(10, 3));
    }

    [Fact]
    public void TestModulus()
    {
        Assert.Equal(1, calculator.Modulus(10, 3));
    }
}
```

### `tests/Calculator.Tests.csproj`

**ES:** Proyecto de tests que referencia la biblioteca `src/Calculator.csproj` y agrega paquetes NuGet:

| Paquete | Versión | Propósito |
|---------|---------|-----------|
| `xunit` | 2.9.3 | Framework de pruebas |
| `xunit.runner.visualstudio` | 3.1.4 | Integración con VS / Rider |
| `Microsoft.NET.Test.Sdk` | 17.14.1 | SDK de pruebas de .NET |
| `coverlet.collector` | 6.0.4 | Cobertura de código |

**EN:** Test project that references the `src/Calculator.csproj` library and adds NuGet packages:

| Package | Version | Purpose |
|---------|---------|---------|
| `xunit` | 2.9.3 | Test framework |
| `xunit.runner.visualstudio` | 3.1.4 | VS / Rider integration |
| `Microsoft.NET.Test.Sdk` | 17.14.1 | .NET test SDK |
| `coverlet.collector` | 6.0.4 | Code coverage |

---

## 🚀 Compilación y ejecución / Build & Run

### Requisito: Tener el .NET SDK instalado

```bash
dotnet --version   # Debería mostrar: 10.0.x
```

### Ejecutar pruebas unitarias

```bash
# Desde la raíz del proyecto (usa la solución)
dotnet test calculator.slnx

# O directamente desde el proyecto de tests
dotnet test tests/Calculator.Tests.csproj
```

**Salida esperada / Expected output:**

```text
Restored .../calculator.slnx
Restored .../src/Calculator.csproj (0.1s)
Restored .../tests/Calculator.Tests.csproj (0.1s)
  Calculator succeeded (0.3s) → obj/Debug/net10.0/Calculator.dll
  Calculator.Tests succeeded (0.5s) → tests/obj/Debug/net10.0/Calculator.Tests.dll
[xUnit] Running 5 test(s) from Calculator.Tests
[xUnit]   TestAddition     ✓ (0.1s)
[xUnit]   TestSubtraction  ✓ (0.1s)
[xUnit]   TestMultiplication ✓ (0.1s)
[xUnit]   TestDivision     ✓ (0.1s)
[xUnit]   TestModulus      ✓ (0.1s)
  Calculator.Tests test succeeded (1.2s)

Test summary: 5 passed, 0 failed — 100% coverage
```

> **ES:** Todas las pruebas deben pasar (5 passed, 0 failed) con código de salida 0.
> **EN:** All tests must pass (5 passed, 0 failed) with exit code 0.

---

## 🧠 Algoritmos / operaciones (según el módulo)

| Función | Implementación | Cumple |
|---------|---------------|--------|
| `Addition(a, b)` | `a + b` (suma directa) | ✅ |
| `Subtraction(a, b)` | `a - b` (resta directa) | ✅ |
| `Multiplication(a, b)` | Suma repetitiva de `a`, `b` veces con `for` | ✅ No usa `*` |
| `Division(a, b)` | Resta repetitiva con `while` | ✅ No usa `/` |
| `Modulus(a, b)` | `a - Multiplication(Division(a, b), b)` | ✅ No usa `%` |

---

## 📝 Notas de implementación / Implementation Notes

- **ES:** xUnit descubre automáticamente los tests marcados con `[Fact]`. No es necesario registrarlos manualmente en una suite ni crear un punto de entrada.
- **EN:** xUnit automatically discovers tests marked with `[Fact]`. No manual registration in a suite or entry point is needed.
- **ES:** Las funciones `multiplication` y `division` están implementadas con sumas/restas repetitivas para cumplir la especificación educativa (no usar operadores `*` ni `/` directos).
- **EN:** The `multiplication` and `division` functions are implemented with repeated addition/subtraction to comply with the educational specification (no direct `*` or `/` operators).
- **ES:** Los directorios `bin/` y `obj/` son generados por el compilador y no deben versionarse. Ver [`.gitignore`](.gitignore).
- **EN:** The `bin/` and `obj/` directories are compiler-generated and should not be versioned. See [`.gitignore`](.gitignore).

---

### 🌐 Otras implementaciones / Other implementations

Este proyecto también está implementado en otros lenguajes. Explora el [repositorio principal](https://github.com/yorche3/programming_languages) para ver todas las versiones.

---

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
