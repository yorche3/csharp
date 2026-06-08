# Numbers — C\#

Implementación de la especificación [04_Numbers](https://yorche3.github.io/programming_languages/core/foundations/04_Numbers/) en **C# (.NET 10)**, usando **xUnit** como framework de pruebas unitarias.

Tres enfoques de implementación para los mismos 5 algoritmos: **recursivo directo**, **recursivo con acumulador** e **iterativo**.

## 📂 Archivos y estructura / Files & Structure

### Raíz del proyecto / Project root

| Archivo | Propósito |
|---------|-----------|
| [`numbers.slnx`](numbers.slnx) | Archivo de solución .NET — referencia los proyectos `src/` y `test/`. |
| [`.gitignore`](.gitignore) | Ignora `bin/`, `obj/`, `.vs/`, etc. |

### Código fuente / Source (`src/`)

| Archivo | Propósito |
|---------|-----------|
| [`src/Numbers/Numbers.cs`](src/Numbers/Numbers.cs) | Clase `NumbersImpl` — 15 funciones (3 enfoques × 5 algoritmos) + 4 helpers `private static`. |
| [`src/Numbers/Numbers.csproj`](src/Numbers/Numbers.csproj) | Proyecto de biblioteca de clases — target `net10.0`. |

### Pruebas / Tests (`test/`)

| Archivo | Propósito |
|---------|-----------|
| `test/NumbersRecursiveTests.cs` | 5 tests para el enfoque recursivo directo |
| `test/NumbersIterativeTests.cs` | 5 tests para el enfoque iterativo |
| `test/Numbers.Test.csproj` | Proyecto de tests — referencia `src/Numbers/Numbers.csproj` + paquetes NuGet (xUnit). |

**Estructura de directorios esperada:**

```text
numbers/
├── numbers.slnx                      # Solución .NET
├── src/
│   └── Numbers/
│       ├── Numbers.cs                # Clase con 15 funciones + 4 helpers private
│       └── Numbers.csproj            # Proyecto de biblioteca
├── test/
│   ├── NumbersRecursiveTests.cs      # Tests recursivos (5)
│   ├── NumbersIterativeTests.cs      # Tests iterativos (5)
│   └── Numbers.Test.csproj           # Proyecto de tests
├── .gitignore                        # Ignora bin/, obj/
└── README.md                         # Este archivo
```

**Nota sobre la estructura / Note about the structure:**

> **ES:** La estructura de este proyecto difiere de la especificada en la [documentación general](https://yorche3.github.io/programming_languages/core/foundations/04_Numbers/). Los motivos:
>
> | Especificación | Este proyecto | Motivo |
> |----------------|---------------|--------|
> | `unit_test/numbers/` | `numbers/` (raíz directa) | Al crearse con `dotnet new`, el proyecto `numbers` se generó al mismo nivel que `unit_test/`, no dentro de él |
> | `src/numbers.cs` | `src/Numbers/Numbers.cs` | `dotnet new classlib -n Numbers -o src/Numbers` anida el archivo dentro de subcarpeta |
> | Clase `Numbers` | Clase `NumbersImpl` | Para evitar conflicto con el namespace `Numbers` |
>
> **EN:** The structure of this project differs from the one specified in the [general documentation](https://yorche3.github.io/programming_languages/core/foundations/04_Numbers/). Reasons:
>
> | Specification | This project | Reason |
> |---------------|--------------|--------|
> | `unit_test/numbers/` | `numbers/` (direct root) | When created with `dotnet new`, the `numbers` project was generated at the same level as `unit_test/`, not inside it |
> | `src/numbers.cs` | `src/Numbers/Numbers.cs` | `dotnet new classlib -n Numbers -o src/Numbers` nests the file inside a subfolder |
> | Class `Numbers` | Class `NumbersImpl` | To avoid conflict with the `Numbers` namespace |

---

## 🛠️ Enfoque y construcción / Approach & Build

**ES:** Sigue el mismo patrón que [`calculator`](../unit_test/calculator/): una solución `.slnx` que agrupa un proyecto de biblioteca (`src/`) y uno de tests (`test/`) con xUnit.

Las 15 funciones se organizan en 3 grupos por enfoque:

| Enfoque | Prefijo | Ejemplo | ¿Tiene tests directos? |
|---------|---------|---------|:----------------------:|
| Recursivo directo | `...Rec` | `FibonacciRec(n)` | ✅ Sí |
| Recursivo con acumulador | `...Acc` | `FibonacciAcc(n)` | ❌ No (implícito) |
| Iterativo | `...Iter` | `FibonacciIter(n)` | ✅ Sí |

**EN:** Follows the same pattern as [`calculator`](../unit_test/calculator/): a `.slnx` solution grouping a library project (`src/`) and a test project (`test/`) with xUnit.

The 15 functions are organized into 3 groups by approach:

| Approach | Prefix | Example | Direct tests? |
|----------|--------|---------|:-------------:|
| Direct recursion | `...Rec` | `FibonacciRec(n)` | ✅ Yes |
| Accumulator recursion | `...Acc` | `FibonacciAcc(n)` | ❌ No (implicit) |
| Iterative | `...Iter` | `FibonacciIter(n)` | ✅ Yes |

---

## 📄 Archivos de configuración clave / Key Configuration Files

### `src/Numbers/Numbers.cs` — Implementación

**ES:** Cada algoritmo tiene 3 implementaciones. Los helpers son `private static` (encapsulados dentro de la clase). Por ejemplo, `fibonacci`:

**EN:** Each algorithm has 3 implementations. Helpers are `private static` (encapsulated within the class). For example, `fibonacci`:

```csharp
// Enfoque recursivo directo / Direct recursion
public static int FibonacciRec(int n)
{
    if (n <= 1) return n;
    else return FibonacciRec(n - 1) + FibonacciRec(n - 2);
}

// Helper interno con acumulador (private, no visible externamente)
// Internal accumulator helper (private, not externally visible)
private static int FibonacciHelp(int n, int a, int b)
{
    if (n <= 0) return a;
    else return FibonacciHelp(n - 1, b, a + b);
}

// Enfoque con acumulador / Accumulator recursion
public static int FibonacciAcc(int n)
{
    return FibonacciHelp(n, 0, 1);
}

// Enfoque iterativo / Iterative
public static int FibonacciIter(int n)
{
    int acc1 = 0;
    int acc2 = 1;
    for (int i = 0; i < n; i++)
    {
        int temp = acc1;
        acc1 = acc2;
        acc2 = temp + acc2;
    }
    return acc1;
}
```

> **ES:** Notar que `FibonacciRec(35)` hace ~18 millones de llamadas recursivas, mientras que `FibonacciAcc(35)` solo hace 35. Aunque C# no tenga TCO, la reducción del número de llamadas es dramática.
>
> **EN:** Note that `FibonacciRec(35)` makes ~18 million recursive calls, while `FibonacciAcc(35)` only makes 35. Even though C# doesn't have TCO, the reduction in the number of calls is dramatic.

### `test/NumbersRecursiveTests.cs` — Pruebas recursivas

**ES:** Cada método `[Fact]` contiene aserciones con `Assert.Equal`.

**EN:** Each `[Fact]` method contains assertions with `Assert.Equal`.

```csharp
using Numbers;

namespace Numbers.Test;

public class NumbersRecursiveTests
{
    [Fact]
    public void TestFibonacciRec()
    {
        Assert.Equal(0, NumbersImpl.FibonacciRec(0));
        Assert.Equal(1, NumbersImpl.FibonacciRec(1));
        Assert.Equal(8, NumbersImpl.FibonacciRec(6));
    }
}
```

### `test/NumbersIterativeTests.cs` — Pruebas iterativas

**ES:** Misma estructura que las recursivas, pero probando los métodos `Iter`.

**EN:** Same structure as the recursive ones, but testing the `Iter` methods.

```csharp
[Fact]
public void TestFibonacciIter()
{
    Assert.Equal(0, NumbersImpl.FibonacciIter(0));
    Assert.Equal(1, NumbersImpl.FibonacciIter(1));
    Assert.Equal(8, NumbersImpl.FibonacciIter(6));
}
```

---

## 🚀 Compilación y ejecución / Build & Run

### Requisito: Tener el .NET SDK instalado

```bash
dotnet --version   # Debería mostrar: 10.0.x
```

### Ejecutar pruebas unitarias

```bash
# Desde la raíz del proyecto (usa la solución)
dotnet test numbers.slnx

# O directamente desde el proyecto de tests
dotnet test test/Numbers.Test.csproj
```

**Salida esperada / Expected output:**

```text
  Numbers succeeded (0.3s) → src/Numbers/obj/Debug/net10.0/Numbers.dll
  Numbers.Test succeeded (0.5s) → test/obj/Debug/net10.0/Numbers.Test.dll
[xUnit] Running 10 test(s) from Numbers.Test
[xUnit]   TestSumOfFirstNRec         ✓
[xUnit]   TestFactorialRec           ✓
[xUnit]   TestFibonacciRec           ✓
[xUnit]   TestGreatestCommonDivisorRec ✓
[xUnit]   TestLeastCommonMultipleRec ✓
[xUnit]   TestSumOfFirstNIter        ✓
[xUnit]   TestFactorialIter          ✓
[xUnit]   TestFibonacciIter          ✓
[xUnit]   TestGreatestCommonDivisorIter ✓
[xUnit]   TestLeastCommonMultipleIter ✓
  Numbers.Test test succeeded (1.2s)

Test summary: 10 passed, 0 failed
```

> **ES:** 10 tests en total (5 recursivos + 5 iterativos). Los acumuladores se prueban implícitamente al ser invocados desde los métodos `Acc`.
> **EN:** 10 tests total (5 recursive + 5 iterative). Accumulators are implicitly tested as they are called by the `Acc` methods.

---

---

## 🧠 Algoritmos / operaciones (según el módulo)

### 3 enfoques × 5 algoritmos = 15 funciones / 10 tests

| Algoritmo | Casos de prueba | `Rec` | `Acc` | `Iter` |
|-----------|----------------|:-----:|:-----:|:------:|
| `SumOfFirstN` | `(0) = 0`, `(3) = 6` | ✅ | ✅¹ | ✅ |
| `Factorial` | `(0) = 1`, `(4) = 24` | ✅ | ✅¹ | ✅ |
| `Fibonacci` | `(0) = 0`, `(1) = 1`, `(6) = 8` | ✅ | ✅¹ | ✅ |
| `LargestCommonDivisor` | `(12, 8) = 4`, `(7, 5) = 1` | ✅ | ✅¹ | ✅ |
| `LeastCommonMultiple` | `(4, 6) = 12`, `(6, 8) = 24` | ✅ | ✅¹ | ✅ |

> ¹ Los acumuladores se prueban implícitamente al ejecutar `Acc(n)`, que internamente llama al helper `private`. No tienen tests directos porque son detalles de implementación y C# no garantiza TCO.
> ¹ Accumulators are implicitly tested when `Acc(n)` runs, which internally calls the `private` helper. They have no direct tests because they are implementation details and C# doesn't guarantee TCO.

---

### 🌐 Otras implementaciones / Other implementations

Este proyecto también está implementado en otros lenguajes. Explora el [repositorio principal](https://github.com/yorche3/programming_languages) para ver todas las versiones.

---

## 📝 Notas de implementación / Implementation Notes

### 🔁 Sobre recursión con acumulador y Tail Call Optimization (TCO) / On recursion with accumulator and Tail Call Optimization (TCO)

**ES:**

Tail recursion ocurre cuando la llamada recursiva es la última acción que ejecuta una función/método; después de la llamada no hay más instrucciones, la función devuelve el resultado de la llamada recursiva. La recursión con acumulador consigue esto pasando el estado previo como parámetro a cada llamada, sin dejar trabajo pendiente en la pila.

**C# no garantiza TCO.** El compilador JIT de RyuJIT (x64) puede aplicar TCO en algunos escenarios con optimizaciones habilitadas, pero no es confiable ni está especificado en el lenguaje. Por lo tanto, los métodos con acumulador (`Acc`) se conservan únicamente con fines educativos: sirven como puente conceptual entre la recursión directa (más cercana a la definición matemática) y la versión iterativa (más eficiente).

Sin embargo, en el caso de `fibonacci`, el enfoque con acumulador reduce el número de llamadas recursivas de **O(2ⁿ)** a **O(n)**, demostrando una mejora algorítmica significativa incluso sin TCO.

**EN:**

Tail recursion occurs when the recursive call is the last action that runs a function/method; after the call there are no more instructions, the function returns the result of the recursive call. Recursion with accumulator achieves this by passing the previous state as a parameter to each call, without leaving any pending work on the stack.

**C# does not guarantee TCO.** The RyuJIT (x64) JIT compiler may apply TCO in some scenarios with optimizations enabled, but it is not reliable nor specified in the language. Therefore, accumulator methods (`Acc`) are preserved only for educational purposes: they serve as a conceptual bridge between the direct recursive (closer to mathematical definition) and the iterative version (more efficient).

However, in the case of `fibonacci`, the accumulator approach reduces the number of recursive calls from **O(2ⁿ)** to **O(n)**, demonstrating a significant algorithmic improvement even without TCO.

---

- **ES:** Los helpers son `private static` — encapsulados dentro de la clase, no visibles externamente. Es el equivalente C# de las funciones `static` en C.
- **EN:** Helpers are `private static` — encapsulated within the class, not externally visible. This is the C# equivalent of `static` functions in C.
- **ES:** En `fibonacci`, el acumulador reduce las llamadas de O(2ⁿ) a O(n). Aun sin TCO, evita el desbordamiento de pila para valores grandes que la versión recursiva directa no puede manejar.
- **EN:** In `fibonacci`, the accumulator reduces calls from O(2ⁿ) to O(n). Even without TCO, it avoids stack overflow for large values that the direct recursive version cannot handle.
- **ES:** Los directorios `bin/` y `obj/` son generados por el compilador y no deben versionarse. Ver [`.gitignore`](.gitignore).
- **EN:** The `bin/` and `obj/` directories are compiler-generated and should not be versioned. See [`.gitignore`](.gitignore).

---

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
