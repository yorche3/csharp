# Naive Sort — C\#

Implementación de la especificación [05_Naive_Sort](https://yorche3.github.io/programming_languages/core/algorithms/05_Naive_Sort/) en **C# (.NET 10)**, usando **xUnit** como framework de pruebas unitarias.

Los tres algoritmos elementales de ordenamiento ($O(n^2)$): **Selection Sort**, **Bubble Sort** e **Insertion Sort**, sobre arrays de enteros y con indicador de fallo compatible con el lenguaje.

---

## 📂 Archivos y estructura / Files & Structure

### Raíz del proyecto / Project root

| Archivo | Propósito |
|---------|-----------|
| [`NaiveSort.slnx`](NaiveSort.slnx) | Archivo de solución .NET — referencia los proyectos `src/` y `test/`. |
| [`.gitignore`](.gitignore) | Ignora `bin/`, `obj/`, `.vs/`, etc. |

### Código fuente / Source (`src/`)

| Archivo | Propósito |
|---------|-----------|
| [`src/NaiveSort/NaiveSortImpl.cs`](src/NaiveSort/NaiveSortImpl.cs) | Clase `NaiveSortImpl` — 3 funciones `public static`. |
| [`src/NaiveSort/NaiveSort.csproj`](src/NaiveSort/NaiveSort.csproj) | Proyecto de biblioteca de clases — target `net10.0`. |

### Pruebas / Tests (`test/`)

| Archivo | Propósito |
|---------|-----------|
| [`test/NaiveSort.Tests/NaiveSortTests.cs`](test/NaiveSort.Tests/NaiveSortTests.cs) | 3 tests (`[Fact]`) — uno por algoritmo; cada uno valida los 8 casos compartidos. |
| [`test/NaiveSort.Tests/NaiveSort.Tests.csproj`](test/NaiveSort.Tests/NaiveSort.Tests.csproj) | Proyecto de tests — referencia `src/NaiveSort/NaiveSort.csproj` + paquetes NuGet (xUnit). |

**Estructura de directorios esperada:**

```text
naive_sort/
├── NaiveSort.slnx                        # Solución .NET
├── src/
│   └── NaiveSort/
│       ├── NaiveSortImpl.cs              # Clase con las 3 funciones de ordenamiento
│       └── NaiveSort.csproj              # Proyecto de biblioteca
├── test/
│   └── NaiveSort.Tests/
│       ├── NaiveSortTests.cs             # Tests (3)
│       └── NaiveSort.Tests.csproj        # Proyecto de tests
├── .gitignore                            # Ignora bin/, obj/
└── README.md                             # Este archivo
```

**Nota sobre la estructura / Note about the structure:**

> **ES:** La estructura de este proyecto difiere de la especificada en la [documentación general](https://yorche3.github.io/programming_languages/core/algorithms/05_Naive_Sort/). Los motivos:
>
> | Especificación | Este proyecto | Motivo |
> |----------------|---------------|--------|
> | `src/naive_sort.ext` | `src/NaiveSort/NaiveSortImpl.cs` | `dotnet new classlib -n NaiveSort -o src/NaiveSort` anida el archivo dentro de subcarpeta |
> | `test/naive_sort_test.ext` | `test/NaiveSort.Tests/NaiveSortTests.cs` | `dotnet new xunit` genera un proyecto de tests con su propio `.csproj` |
> | `test/run_tests.ext` | `NaiveSort.slnx` + `dotnet test` | .NET no usa un runner manual: `dotnet test` descubre automáticamente los `[Fact]` de la solución |
> | Clase `naive_sort` | Clase `NaiveSortImpl` | Para evitar conflicto entre el namespace `NaiveSort` y el nombre de la clase |
>
> **EN:** The structure of this project differs from the one specified in the [general documentation](https://yorche3.github.io/programming_languages/core/algorithms/05_Naive_Sort/). Reasons:
>
> | Specification | This project | Reason |
> |---------------|--------------|--------|
> | `src/naive_sort.ext` | `src/NaiveSort/NaiveSortImpl.cs` | `dotnet new classlib -n NaiveSort -o src/NaiveSort` nests the file inside a subfolder |
> | `test/naive_sort_test.ext` | `test/NaiveSort.Tests/NaiveSortTests.cs` | `dotnet new xunit` generates a test project with its own `.csproj` |
> | `test/run_tests.ext` | `NaiveSort.slnx` + `dotnet test` | .NET has no manual runner: `dotnet test` automatically discovers the `[Fact]` methods of the solution |
> | Class `naive_sort` | Class `NaiveSortImpl` | To avoid conflict between the `NaiveSort` namespace and the class name |

---

## 🛠️ Enfoque y construcción / Approach & Build

**ES:** Sigue el mismo patrón que [`numbers`](../../foundations/numbers/): una solución `.slnx` que agrupa un proyecto de biblioteca (`src/`) y uno de tests (`test/`) con xUnit.

El proyecto se creó manualmente con las herramientas del SDK:

```bash
dotnet new sln -n NaiveSort
dotnet new classlib -n NaiveSort -o src/NaiveSort
dotnet new xunit -n NaiveSort.Tests -o test/NaiveSort.Tests
dotnet sln add src/NaiveSort/NaiveSort.csproj
dotnet sln add test/NaiveSort.Tests/NaiveSort.Tests.csproj
```

**EN:** Follows the same pattern as [`numbers`](../../foundations/numbers/): a `.slnx` solution grouping a library project (`src/`) and a test project (`test/`) with xUnit.

The project was created manually with the SDK tools (commands above).

---

## 📄 Configuración clave / Key Configuration

### `src/NaiveSort/NaiveSort.csproj`

**ES:** Biblioteca de clases sin dependencias externas.

**EN:** Class library with no external dependencies.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
</Project>
```

### `test/NaiveSort.Tests/NaiveSort.Tests.csproj`

**ES:** Proyecto de tests con xUnit. El `ProjectReference` lo enlaza con la biblioteca.

**EN:** xUnit test project. The `ProjectReference` links it to the library.

```xml
<ItemGroup>
  <PackageReference Include="coverlet.collector" Version="6.0.4" />
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.14.1" />
  <PackageReference Include="xunit" Version="2.9.3" />
  <PackageReference Include="xunit.runner.visualstudio" Version="3.1.4" />
</ItemGroup>

<ItemGroup>
  <ProjectReference Include="..\..\src\NaiveSort\NaiveSort.csproj" />
</ItemGroup>
```

> **ES:** `<Nullable>enable</Nullable>` activa los *nullable reference types*. Por eso las funciones declaran `int[]?` como parámetro y retorno: `null` es el indicador de fallo del lenguaje para una entrada inválida, y el compilador lo exige explícito para no emitir el warning `CS8603`.
> **EN:** `<Nullable>enable</Nullable>` enables nullable reference types. That is why the functions declare `int[]?` as parameter and return: `null` is the language's failure indicator for an invalid input, and the compiler requires it explicit to avoid the `CS8603` warning.

---

## 🚀 Compilación y ejecución / Build & Run

### Requisito: Tener el .NET SDK instalado

```bash
dotnet --version   # Debería mostrar: 10.0.x
```

### Compilar

```bash
dotnet build NaiveSort.slnx
```

### Ejecutar pruebas unitarias

```bash
# Desde la raíz del proyecto (usa la solución)
dotnet test NaiveSort.slnx

# O directamente desde el proyecto de tests
dotnet test test/NaiveSort.Tests/NaiveSort.Tests.csproj
```

**Salida real / Actual output:**

```text
Restore complete (0.7s)
  NaiveSort net10.0 succeeded (2.0s) → src/NaiveSort/bin/Debug/net10.0/NaiveSort.dll
  NaiveSort.Tests net10.0 succeeded (0.5s) → test/NaiveSort.Tests/bin/Debug/net10.0/NaiveSort.Tests.dll

Build succeeded in 3.4s
```

```text
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v3.1.4+50e68bbb8b (64-bit .NET 10.0.12)
[xUnit.net 00:00:00.05]   Discovering: NaiveSort.Tests
[xUnit.net 00:00:00.08]   Discovered:  NaiveSort.Tests
[xUnit.net 00:00:00.10]   Starting:    NaiveSort.Tests
[xUnit.net 00:00:00.13]   Finished:    NaiveSort.Tests
  NaiveSort.Tests test net10.0 succeeded (0.7s)

Test summary: total: 3, failed: 0, succeeded: 3, skipped: 0, duration: 0.7s
Build succeeded in 1.5s
```

> **ES:** El build no produce warnings ni errores.
> **EN:** The build produces no warnings or errors.

---

## 🧠 Algoritmos y operaciones / Algorithms & Operations

### 3 algoritmos / 3 tests × 8 casos = 24 aserciones

| Algoritmo | Estrategia | Complejidad temporal | In-place | Tests |
|-----------|------------|---------------------|:--------:|:-----:|
| `SelectionSort` | Encuentra el mínimo del resto no ordenado y lo ubica al inicio | $O(n^2)$ siempre | ✅ | 1 |
| `BubbleSort` | Compara e intercambia adyacentes; corta antes si no hubo swaps | $O(n^2)$ peor/promedio, $O(n)$ mejor | ✅ | 1 |
| `InsertionSort` | Inserta cada elemento en su posición dentro del prefijo ya ordenado | $O(n^2)$ peor/promedio, $O(n)$ mejor | ✅ | 1 |

### Casos cubiertos / Covered cases

Cada test ejecuta los mismos 8 casos a través de un helper compartido:

| # | Caso | Entrada | Salida esperada |
|---|------|---------|-----------------|
| 1 | Array estándar desordenado | `[5, 2, 9, 1, 5, 6]` | `[1, 2, 5, 5, 6, 9]` |
| 2 | Array ya ordenado | `[1, 2, 3, 4, 5]` | `[1, 2, 3, 4, 5]` |
| 3 | Array en orden inverso | `[5, 4, 3, 2, 1]` | `[1, 2, 3, 4, 5]` |
| 4 | Elementos idénticos | `[7, 7, 7, 7]` | `[7, 7, 7, 7]` |
| 5 | Con números negativos | `[3, -1, 4, -5, 0]` | `[-5, -1, 0, 3, 4]` |
| 6 | Un solo elemento | `[42]` | `[42]` |
| 7 | Array vacío | `[]` | `[]` |
| 8 | Entrada nula (indicador de fallo) | `null` | `null` |

---

## 📝 Notas de implementación / Implementation Notes

- **ES:** El parámetro y el retorno son `int[]?` porque `null` es el **indicador de fallo** del lenguaje para una entrada inválida, tal como exige la especificación. Ninguna función lanza excepciones.
- **EN:** Both parameter and return are `int[]?` because `null` is the language's **failure indicator** for an invalid input, as required by the specification. No function throws exceptions.
- **ES:** Los algoritmos ordenan **in-place**: mutan y devuelven el mismo array recibido. Los tests no comparten estado mutable entre casos porque cada caso declara sus propios arrays.
- **EN:** The algorithms sort **in-place**: they mutate and return the same array received. Tests do not share mutable state across cases because each case declares its own arrays.
- **ES:** `BubbleSort` incluye la optimización de salida temprana con la bandera `swapped`; `SelectionSort` evita el swap cuando `minIndex == i`.
- **EN:** `BubbleSort` includes the early-exit optimization with the `swapped` flag; `SelectionSort` skips the swap when `minIndex == i`.
- **ES:** `Nullable` está habilitado en ambos proyectos. Declarar `int[]` (no anulable) con una rama `arr == null` provoca `CS8603` ("possible null reference return"), y el desajuste con `Func<int[]?, int[]?>` en los tests provoca `CS8622`.
- **EN:** `Nullable` is enabled in both projects. Declaring `int[]` (non-nullable) with an `arr == null` branch triggers `CS8603` ("possible null reference return"), and the mismatch with `Func<int[]?, int[]?>` in the tests triggers `CS8622`.
- **ES:** No se usan bibliotecas nativas de ordenamiento (`Array.Sort`, LINQ `OrderBy`, etc.) en la implementación. En los tests, `SequenceEqual` solo se usa para comparar resultados, no para ordenar.
- **EN:** No native sorting libraries (`Array.Sort`, LINQ `OrderBy`, etc.) are used in the implementation. In the tests, `SequenceEqual` is only used to compare results, not to sort.
- **ES:** Los directorios `bin/` y `obj/` son generados por el compilador y no deben versionarse. Ver [`.gitignore`](.gitignore).
- **EN:** The `bin/` and `obj/` directories are compiler-generated and should not be versioned. See [`.gitignore`](.gitignore).

---

### 🌐 Otras implementaciones / Other implementations

Este proyecto también está implementado en otros lenguajes. Explora el [repositorio principal](https://github.com/yorche3/programming_languages) para ver todas las versiones.

---

*[← Volver a Algoritmos Puros](../README.md) | [↑ Volver a Core](../../README.md)*

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
