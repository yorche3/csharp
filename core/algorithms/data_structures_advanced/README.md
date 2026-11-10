# Data Structures Advanced — C\#

Implementación de la especificación [07_Data_Structures_Advanced](https://yorche3.github.io/programming_languages/core/algorithms/07_Data_Structures_Advanced/) en **C# (.NET 10)**, usando **xUnit** como framework de pruebas unitarias.

Define una clase base `Node` que encapsula el valor, un nodo de árbol binario `TreeNode` y dos tipos de datos abstractos independientes: un árbol binario de búsqueda `BinaryTree` y un grafo dirigido `Graph` con registro enlazado canónico y adyacencia ordenada.

Implementation of the [07_Data_Structures_Advanced](https://yorche3.github.io/programming_languages/core/algorithms/07_Data_Structures_Advanced/) specification in **C# (.NET 10)**, using **xUnit** as the unit testing framework.

Defines a `Node` base class encapsulating the value, a `TreeNode` binary tree node, and two independent abstract data types: a `BinaryTree` binary search tree and a directed `Graph` with canonical linked vertex registry and sorted adjacency.

---

## 📂 Archivos y estructura / Files & Structure

| Archivo / Directory | Propósito / Purpose |
|---|---|
| [`DataStructuresAdvanced.slnx`](DataStructuresAdvanced.slnx) | Archivo de solución .NET — organiza proyectos `src/` y `test/` / .NET solution file — organizes `src/` and `test/` projects |
| [`src/DataStructuresAdvanced/Node.cs`](src/DataStructuresAdvanced/Node.cs) | Clase abstracta `Node` — base local portadora de `Value`, sin enlaces ni validaciones / Abstract class `Node` — local base carrying `Value`, no links or validations |
| [`src/DataStructuresAdvanced/TreeNode.cs`](src/DataStructuresAdvanced/TreeNode.cs) | Clase `TreeNode` — hereda de `Node`, incorpora enlaces `Left` y `Right` / `TreeNode` class — inherits from `Node`, incorporates `Left` and `Right` links |
| [`src/DataStructuresAdvanced/BinaryTree.cs`](src/DataStructuresAdvanced/BinaryTree.cs) | Clase `BinaryTree` — árbol binario de búsqueda sin capacidad máxima contractual / `BinaryTree` class — binary search tree without contractual capacity |
| [`src/DataStructuresAdvanced/GraphNode.cs`](src/DataStructuresAdvanced/GraphNode.cs) | Clase interna `GraphNode` — hereda de `Node`, lista de vecinos y puntero `NextVertex` / Internal `GraphNode` class — inherits from `Node`, neighbors list and `NextVertex` pointer |
| [`src/DataStructuresAdvanced/Graph.cs`](src/DataStructuresAdvanced/Graph.cs) | Clase `Graph` — grafo dirigido sobre registro enlazado manual de vértices / `Graph` class — directed graph over manual linked vertex registry |
| [`src/DataStructuresAdvanced/DataStructuresAdvanced.csproj`](src/DataStructuresAdvanced/DataStructuresAdvanced.csproj) | Proyecto de biblioteca de clases — target `net10.0` / Class library project — target `net10.0` |
| [`test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs) | Suite xUnit — pruebas para `TreeNode`, `BinaryTree` y `Graph` / xUnit suite — tests for `TreeNode`, `BinaryTree`, and `Graph` |
| [`test/DataStructuresAdvanced.Tests/DataStructuresAdvanced.Tests.csproj`](test/DataStructuresAdvanced.Tests/DataStructuresAdvanced.Tests.csproj) | Proyecto de pruebas xUnit — referencia la biblioteca de clases / xUnit test project — references class library |
| `.gitignore` | Exclusiones de Git para artefactos de compilación .NET / Git ignore rules for .NET build artifacts |

**Estructura de directorios / Directory structure:**

```text
data_structures_advanced/
├── DataStructuresAdvanced.slnx
├── src/
│   └── DataStructuresAdvanced/
│       ├── BinaryTree.cs
│       ├── DataStructuresAdvanced.csproj
│       ├── Graph.cs
│       ├── GraphNode.cs
│       ├── Node.cs
│       └── TreeNode.cs
├── test/
│   └── DataStructuresAdvanced.Tests/
│       ├── DataStructuresAdvanced.Tests.csproj
│       └── DataStructuresAdvancedTests.cs
├── .gitignore
└── README.md
```

> **Nota de desviación / Deviation note:**  
> **ES:** La especificación propone un único archivo `src/data_structures_advanced.ext` y `test/data_structures_advanced_test.ext` con `run_tests.ext`. En C# (.NET), la convención idiomática separa cada tipo en su propio archivo (`Node.cs`, `TreeNode.cs`, `BinaryTree.cs`, `GraphNode.cs`, `Graph.cs`) dentro de un proyecto de biblioteca `src/DataStructuresAdvanced/`, y las pruebas se ubican en un proyecto xUnit (`test/DataStructuresAdvanced.Tests/`). No se requiere un ejecutable `run_tests` manual porque `dotnet test` descubre y ejecuta automáticamente los métodos marcados con `[Fact]`.  
> **EN:** The specification suggests a single file `src/data_structures_advanced.ext` and `test/data_structures_advanced_test.ext` along with `run_tests.ext`. In C# (.NET), idiomatic convention separates each type into its own source file (`Node.cs`, `TreeNode.cs`, `BinaryTree.cs`, `GraphNode.cs`, `Graph.cs`) within a library project `src/DataStructuresAdvanced/`, and tests reside in an xUnit project (`test/DataStructuresAdvanced.Tests/`). A manual `run_tests` script is not needed because `dotnet test` automatically discovers and runs `[Fact]` methods.

---

## 🛠️ Enfoque y construcción / Approach & Build

**ES:** Proyecto estructurado mediante solución .NET (`.slnx`) que enlaza el proyecto de biblioteca de clases y el proyecto de pruebas unitarias xUnit. La base `Node` se modela mediante herencia de clases (`abstract class Node` con constructor protegido), de la cual derivan `TreeNode` y la clase interna `GraphNode`. El registro de vértices de `Graph` se construye manualmente mediante una lista enlazada canónica de nodos (`NextVertex`), y las aristas se gestionan con inserción manual ordenada. Se utilizan tipos de referencia anulables (`TreeNode?`, `GraphNode?`, `int[]?`) para modelar la ausencia y las señales de fallo sin excepciones.

**EN:** Project structured via a .NET solution (`.slnx`) linking the class library project and the xUnit test project. The `Node` base is modeled through class inheritance (`abstract class Node` with protected constructor), from which `TreeNode` and internal `GraphNode` derive. The `Graph` vertex registry is manually constructed using a canonical linked list of nodes (`NextVertex`), and edges are managed with manual sorted insertion. Nullable reference types (`TreeNode?`, `GraphNode?`, `int[]?`) represent absence and failure indicators without exceptions.

```bash
dotnet new sln -n DataStructuresAdvanced
dotnet new classlib -n DataStructuresAdvanced -o src/DataStructuresAdvanced
dotnet new xunit -n DataStructuresAdvanced.Tests -o test/DataStructuresAdvanced.Tests
dotnet sln add src/DataStructuresAdvanced/DataStructuresAdvanced.csproj
dotnet sln add test/DataStructuresAdvanced.Tests/DataStructuresAdvanced.Tests.csproj
```

---

## 📄 Configuración clave / Key Configuration

### `src/DataStructuresAdvanced/DataStructuresAdvanced.csproj`

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

### `test/DataStructuresAdvanced.Tests/DataStructuresAdvanced.Tests.csproj`

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="coverlet.collector" Version="6.0.4" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.14.1" />
    <PackageReference Include="xunit" Version="2.9.3" />
    <PackageReference Include="xunit.runner.visualstudio" Version="3.1.4" />
  </ItemGroup>

  <ItemGroup>
    <Using Include="Xunit" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\..\src\DataStructuresAdvanced\DataStructuresAdvanced.csproj" />
  </ItemGroup>

</Project>
```

---

## 🚀 Compilación y ejecución / Build & Run

```bash
dotnet --version
dotnet build DataStructuresAdvanced.slnx -warnaserror
dotnet test DataStructuresAdvanced.slnx
```

**Salida real / Actual output:**

```text
  Determining projects to restore...
  All projects are up-to-date for restore.
  DataStructuresAdvanced -> ~/programming_languages/csharp/core/algorithms/data_structures_advanced/src/DataStructuresAdvanced/bin/Debug/net10.0/DataStructuresAdvanced.dll
  DataStructuresAdvanced.Tests -> ~/programming_languages/csharp/core/algorithms/data_structures_advanced/test/DataStructuresAdvanced.Tests/bin/Debug/net10.0/DataStructuresAdvanced.Tests.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.51
```

```text
  Determining projects to restore...
  All projects are up-to-date for restore.
  DataStructuresAdvanced -> ~/programming_languages/csharp/core/algorithms/data_structures_advanced/src/DataStructuresAdvanced/bin/Debug/net10.0/DataStructuresAdvanced.dll
  DataStructuresAdvanced.Tests -> ~/programming_languages/csharp/core/algorithms/data_structures_advanced/test/DataStructuresAdvanced.Tests/bin/Debug/net10.0/DataStructuresAdvanced.Tests.dll
Test run for ~/programming_languages/csharp/core/algorithms/data_structures_advanced/test/DataStructuresAdvanced.Tests/bin/Debug/net10.0/DataStructuresAdvanced.Tests.dll (.NETCoreApp,Version=v10.0)
VSTest version 18.0.2 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     3, Skipped:     0, Total:     3, Duration: 30 ms - DataStructuresAdvanced.Tests.dll (net10.0)
```

---

## 🧠 Algoritmos y operaciones / Algorithms & Operations

| Operación / Operation | Entrada → salida / Input → output | Complejidad / Complexity | Notas / Notes |
|---|---|---|---|
| `Node(value)` | `int → Node` | $O(1)$ | Constructor protegido; inicializa `Value = value` sin enlaces ni validaciones / Protected constructor; sets `Value = value` without links or validations |
| `Node.Value` | `() → int` | $O(1)$ | Propiedad get portadora del valor / Getter property carrying the value |
| `TreeNode(value)` | `int → TreeNode` | $O(1)$ | Constructor público derivado; inicializa `Left = null`, `Right = null` / Public derived constructor; initializes `Left = null`, `Right = null` |
| `TreeNode.Left` | `() → TreeNode?` | $O(1)$ | Propiedad get/set; enlace al hijo izquierdo o `null` / Getter/setter property; link to left child or `null` |
| `TreeNode.Right` | `() → TreeNode?` | $O(1)$ | Propiedad get/set; enlace al hijo derecho o `null` / Getter/setter property; link to right child or `null` |
| `BinaryTree()` | `() → BinaryTree` | $O(1)$ | Constructor; inicializa `_root = null`, `_count = 0` / Constructor; initializes `_root = null`, `_count = 0` |
| `BinaryTree.Insert(value)` | `int → bool` | $O(h)$ | Inserta según invariante de ABB; duplicado es idempotente y devuelve `true` sin alterar `_count` / Inserts via BST invariant; duplicate is idempotent and returns `true` without changing `_count` |
| `BinaryTree.Contains(value)` | `int → bool` | $O(h)$ | Búsqueda binaria por ramas según invariante de ABB / Binary search down branches following BST invariant |
| `BinaryTree.IsEmpty` | `() → bool` | $O(1)$ | Propiedad get; indica si `_count == 0` / Getter property; indicates whether `_count == 0` |
| `BinaryTree.Size` | `() → int` | $O(1)$ | Propiedad get; devuelve el número de nodos almacenados / Getter property; returns stored node count |
| `GraphNode(label)` | `int → GraphNode` | $O(1)$ | Constructor interno derivado; inicializa vecinos vacíos y `NextVertex = null` / Internal derived constructor; initializes empty neighbors and `NextVertex = null` |
| `Graph()` | `() → Graph` | $O(1)$ | Constructor; inicializa `_vertices = null`, contadores en 0 / Constructor; initializes `_vertices = null`, counters at 0 |
| `Graph.AddVertex(label)` | `int → bool` | $O(V)$ | Inserta vértice en cabeza del registro enlazado si no existe; duplicado es idempotente y conserva adyacencia / Prepends vertex to linked registry if absent; duplicate is idempotent and preserves adjacency |
| `Graph.AddEdge(u, v)` | `(int, int) → bool` | $O(V + d(u))$ | Verifica extremos en registro enlazado; inserta `v` ordenado manualmente en vecinos de `u`; duplicado y bucles idempotentes / Checks endpoints in linked registry; inserts `v` sorted manually into `u` neighbors; duplicate and self-loops idempotent |
| `Graph.HasEdge(u, v)` | `(int, int) → bool` | $O(V + d(u))$ | Busca vértice `u` en registro y verifica presencia de `v` en su lista / Finds vertex `u` in registry and checks presence of `v` in its list |
| `Graph.GetNeighbors(u)` | `int → int[]?` | $O(V + d(u))$ | Devuelve copia independiente ordenada como array `int[]` o `null` si `u` no existe / Returns independent sorted copy as `int[]` array or `null` if `u` is missing |
| `Graph.IsEmpty` | `() → bool` | $O(1)$ | Propiedad get; indica si `_vertexTotal == 0` / Getter property; indicates whether `_vertexTotal == 0` |
| `Graph.VertexCount` | `() → int` | $O(1)$ | Propiedad get; devuelve `_vertexTotal` / Getter property; returns `_vertexTotal` |
| `Graph.EdgeCount` | `() → int` | $O(1)$ | Propiedad get; devuelve `_edges` / Getter property; returns `_edges` |

---

## 🧩 Decisiones de diseño / Design decisions

| Decisión / Decision | Alternativa considerada / Alternative | Razón / Reason |
|---|---|---|
| Herencia real mediante `abstract class Node` | Valor embebido / composición de campo en cada nodo derivado | C# soporta herencia de clases de forma nativa e idiomática; evita duplicación del campo `Value` respetando que `Node` no puede instanciarse directamente / C# natively and idiomatically supports class inheritance; avoids duplicating `Value` field while preventing direct instantiation of `Node` |
| `GraphNode` con visibilidad `internal` y `sealed` | `public class GraphNode` | `GraphNode` es un detalle de implementación interno del ADT `Graph`; la especificación declara que su inicialización es interna a la estructura / `GraphNode` is an internal implementation detail of the `Graph` ADT; the specification declares its initialization is internal to the structure |
| Propiedades C# (`Left`, `Right`, `IsEmpty`, etc.) en lugar de métodos | Métodos getter/setter explícitos (`GetLeft()`, `SetLeft(node)`) | Las propiedades automáticas son el mecanismo idiomático en C# para exponer estado con acceso encapsulado / Auto-properties are the idiomatic mechanism in C# to expose state with encapsulated access |
| Retorno de array `int[]?` en `GetNeighbors(u)` | `IReadOnlyList<int>?` o `IEnumerable<int>?` | `int[]` garantiza una copia desacoplada e independiente del grafo que no muta la estructura interna si el llamador la modifica / `int[]` guarantees a decoupled, independent snapshot that does not mutate internal structure if modified by caller |
| Registro enlazado manual de vértices mediante puntero `NextVertex` | Diccionario `Dictionary<int, GraphNode>` o lista estándar | La especificación prohíbe explícitamente el uso de tablas hash, mapas o índices por etiqueta para el registro de vértices; el recorrido lineal `O(V)` preserva el propósito formativo del módulo / The specification explicitly prohibits hash tables, maps, or label indexes for vertex registry; linear `O(V)` traversal preserves educational purpose |

---

## 🔀 Adaptaciones idiomáticas / Idiomatic adaptations

| Especificación / Specification | Adaptación / Adaptation | Justificación / Justification |
|---|---|---|
| Inicialización explícita `init` (`TreeNode.init(value)`, `BinaryTree.init()`, `Graph.init()`) | Constructores nativos `new TreeNode(value)`, `new BinaryTree()`, `new Graph()` | En C#, los constructores son la forma idiomática y segura de garantizar instancias inicializadas válidamente sin constructores de fábrica artificiales / In C#, constructors are the idiomatic and safe way to ensure validly initialized instances without artificial factory constructors |
| `TreeNode.get_left()`, `get_right()`, `set_left(node)`, `set_right(node)` | Propiedades mutables `Left` y `Right` con getter y setter | Propiedades auto-implementadas encapsulan getters y setters de forma idiomática en C# / Auto-properties encapsulate getters and setters idiomatically in C# |
| `TreeNode.left`/`right` ausente | Referencia nula (`null`) con tipo anulable `TreeNode?` | `null` es la representación nativa de ausencia de referencias en .NET; `<Nullable>enable</Nullable>` garantiza seguridad estática en compilación / `null` is the native reference absence representation in .NET; `<Nullable>enable</Nullable>` guarantees compile-time static safety |
| `Graph.get_neighbors(u)` fallo al no existir `u` | Retorno de referencia nula `int[]?` (`null`) | Permite diferenciar nítidamente entre un vértice inexistente (`null`) y un vértice aislado existente con secuencia de vecinos vacía (`[]`) / Allows cleanly distinguishing between a missing vertex (`null`) and an existing isolated vertex with empty neighbors (`[]`) |
| Estructura inmutable de `TreeNode` para `set_left`/`set_right` | Estructura mutable por referencia (`Left = node`) | C# es un lenguaje imperativo orientado a objetos donde los nodos enlazados son tipos por referencia mutables; la especificación marca la adaptación inmutable como condicional («si aplica») / C# is an imperative OOP language where linked nodes are mutable reference types; specification marks immutable adaptation as conditional ("if applicable") |

---

## 🚨 Indicadores de fallo / Failure indicators

| Operación / Operation | Situación de fallo / Failure situation | Indicador / Indicator | Ejemplo / Example |
|---|---|---|---|
| `TreeNode.Left` / `Right` | Ausencia de nodo hijo / Absence of child node | `null` (ausencia nativa) | `node.Left` tras `new TreeNode(10)` → `null` |
| `BinaryTree.Contains(value)` | Valor ausente en el árbol / Value absent from tree | `false` | `tree.Contains(99)` en árbol con `[50]` → `false` |
| `Graph.AddEdge(u, v)` | Vértice origen `u` o destino `v` inexistente / Missing source `u` or target `v` | `false` | `graph.AddEdge(10, 99)` → `false` (no muta contadores ni adyacencias) |
| `Graph.HasEdge(u, v)` | Arista no existe o extremos inexistentes / Edge absent or endpoints missing | `false` | `graph.HasEdge(10, 30)` sin arista → `false` |
| `Graph.GetNeighbors(u)` | Vértice `u` inexistente en el grafo / Vertex `u` missing in graph | `null` | `graph.GetNeighbors(99)` en grafo con `{10}` → `null` (distinto de `[]`) |

---

## ✅ Cobertura de pruebas / Test coverage

| Caso de la especificación / Specification case | Cubierto / Covered | Prueba / Test | Notas / Notes |
|---|---|:--:|---|
| `TreeNode` — Crear un nodo de árbol | Sí | [`TestTreeNodeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L25-L30) | Valida `node.Value == 10` |
| `TreeNode` — Enlaces iniciales ausentes | Sí | [`TestTreeNodeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L31-L37) | Valida `node.Left == null` y `node.Right == null` |
| `TreeNode` — Enlazar dos hijos | Sí | [`TestTreeNodeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L38-L46) | Valida `parent.Left.Value == 20` y `parent.Right.Value == 30` |
| `TreeNode` — Recorrer cada enlace | Sí | [`TestTreeNodeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L47-L59) | Valida navegación hacia hijos y que enlaces terminales son `null` |
| `TreeNode` — Desenlazar hijos | Sí | [`TestTreeNodeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L60-L75) | Valida desenlace secuencial (`Left = null`, luego `Right = null`) preservando valor |
| `TreeNode` — Adaptación inmutable | Omitido | — | No aplica: C# implementa nodos de árbol mutables por referencia como convención idiomática / Not applicable: C# implements mutable-by-reference tree nodes as idiomatic convention |
| `BinaryTree` — Crear vacío | Sí | [`TestBinaryTreeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L84-L91) | Valida `IsEmpty == true`, `Size == 0`, `Contains(50) == false` |
| `BinaryTree` — Insertar la raíz | Sí | [`TestBinaryTreeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L92-L99) | Valida inserción de raíz, `Size == 1`, `IsEmpty == false`, `Contains(50) == true` |
| `BinaryTree` — Insertar menor y mayor | Sí | [`TestBinaryTreeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L100-L109) | Inserta `50, 30, 70`, valida tamaño 3 y pertenencia de los tres |
| `BinaryTree` — Ramas de varios niveles | Sí | [`TestBinaryTreeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L110-L118) | Inserta `50, 30, 70, 20, 40`, valida `Size == 5` y pertenencia completa |
| `BinaryTree` — Valor ausente en árbol no vacío | Sí | [`TestBinaryTreeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L119-L126) | Valida `Contains(99) == false`, `Size == 1`, `Contains(50) == true` |
| `BinaryTree` — Duplicado idempotente | Sí | [`TestBinaryTreeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L127-L135) | Inserta `50, 30, 70, 30`, valida cuatro retornos `true`, `Size == 3` y conservación de claves |
| `BinaryTree` — Inserciones ordenadas | Sí | [`TestBinaryTreeOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L136-L145) | Inserta `20, 30, 40, 50, 70`, valida `Size == 5`, pertenencia y fallo en `Contains(99)` |
| `Graph` — Crear vacío | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L154-L163) | Valida `IsEmpty == true`, `VertexCount == 0`, `EdgeCount == 0`, arista `false`, vecinos `null` |
| `Graph` — Vértice aislado | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L164-L172) | Registra vértice 10; valida 1 vértice, 0 aristas y vecinos vacíos `[]` |
| `Graph` — Etiquetas no consecutivas y arista dirigida | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L173-L184) | Registra 10 y 70, añade `(10,70)`; valida `HasEdge(10,70) == true`, `HasEdge(70,10) == false`, 2 vértices, 1 arista |
| `Graph` — Vértice duplicado conserva adyacencia | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L185-L196) | Registra 10 y 30, añade `(10,30)`, re-registra 10; valida 2 vértices, 1 arista y vecinos de 10 `[30]` |
| `Graph` — Arista duplicada | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L197-L208) | Añade dos veces `(10,30)`; valida ambos éxitos, 2 vértices, 1 arista y vecinos `[30]` |
| `Graph` — Extremo inexistente sin mutación | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L209-L231) | Intenta 4 aristas inválidas; valida 4 fallos, conservación de 2 vértices y 1 arista, y vecinos `null` para ausentes |
| `Graph` — Vecinos ordenados y contadores | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L232-L251) | Añade aristas desordenadas; valida orden ascendente `[30, 50, 70]`, 4 vértices y 4 aristas |
| `Graph` — Consulta de arista ausente | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L252-L262) | Valida `HasEdge(10,30) == false`, 2 vértices y 0 aristas |
| `Graph` — Vecinos de vértice inexistente | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L263-L272) | Valida `GetNeighbors(99) == null`, diferenciándose de vecinos vacíos `[]` del vértice 10 |
| `Graph` — Bucle y duplicado | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L273-L284) | Añade bucle `(10,10)` dos veces; valida éxito, 1 vértice, 1 arista y vecinos `[10]` |
| `Graph` — Aislamiento del resultado de vecinos | Sí | [`TestGraphOperations`](test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs#L285-L306) | Modificar la copia devuelta no altera el grafo; snapshot previo `[30]` se conserva tras añadir `(10,50)` |

> **Mapeo estructural de pruebas / Test structural mapping:**  
> La suite se estructura en `test/DataStructuresAdvanced.Tests/DataStructuresAdvancedTests.cs` organizada en 3 métodos de prueba `[Fact]` que cubren respectivamente las 3 unidades del contrato: `TestTreeNodeOperations` (5 casos de `TreeNode`), `TestBinaryTreeOperations` (7 casos de `BinaryTree`) y `TestGraphOperations` (11 casos de `Graph`), sumando 23 escenarios independientes ejecutados mediante el runner xUnit (`dotnet test`).

---

## ⚠️ Limitaciones conocidas / Known limitations

| Limitación / Limitation | Impacto / Impact | Alternativa o plan / Workaround or plan |
|---|---|---|
| Búsqueda lineal en registro de vértices $O(V)$ | El registro enlazado sin tabla hash escala linealmente con el número de vértices | Requisito pedagógico explícito de la especificación para implementar el registro manualmente; en fases aplicadas o bibliotecas de producción se utilizan tablas hash o diccionarios / Explicit educational requirement of the specification to implement manual registry; production libraries use hash tables |
| Nodos monomórficos sobre enteros `int` | Las estructuras almacenan únicamente valores y etiquetas de tipo entero con signo de 32 bits | Decisión de diseño de la Fase 1 para consolidar algoritmos puros sin sobrecarga de tipos genéricos / Phase 1 design decision to focus on pure algorithms without generic type overhead |

---

## 📝 Notas de implementación / Implementation Notes

- **ES:** **Herencia y aislamiento:** `Node` actúa como base abstracta local (`Node.cs`) que porta exclusivamente el valor (`Value`). `TreeNode` hereda de ella para añadir los enlaces de árbol `Left` y `Right`. `GraphNode` hereda de ella usando `Value` como etiqueta identificadora (`label`), y encapsula su lista de vecinos y el enlace `NextVertex` del registro canónico con visibilidad `internal`.
- **EN:** **Inheritance and isolation:** `Node` acts as a local abstract base (`Node.cs`) carrying strictly the value (`Value`). `TreeNode` inherits from it adding tree links `Left` and `Right`. `GraphNode` inherits from it using `Value` as the vertex label (`label`), encapsulating its neighbors list and canonical registry link `NextVertex` with `internal` accessibility.
- **ES:** **Registro manual sin diccionarios:** En estricto cumplimiento de la especificación, el registro de vértices no delega en `Dictionary`, `HashSet` ni ninguna estructura de indexación de la BCL. El registro es una lista enlazada canónica recorrida secuencialmente en `FindVertex` ($O(V)$).
- **EN:** **Manual registry without dictionaries:** In strict accordance with the specification, the vertex registry does not delegate to `Dictionary`, `HashSet`, or any BCL indexing structure. The registry is a canonical linked list traversed sequentially in `FindVertex` ($O(V)$).
- **ES:** **Adyacencia ordenada manual e independencia:** La inserción de aristas en `AddEdge` localiza manualmente la posición ordenada mediante recorrido lineal y la inserta sin recurrir a algoritmos de ordenación de biblioteca. `GetNeighbors` produce un array nuevo mediante `ToArray()`, garantizando aislamiento completo frente a mutaciones externas posteriores.
- **EN:** **Manual sorted adjacency and independence:** Edge insertion in `AddEdge` manually locates the ordered insertion point via linear search and inserts without relying on library sorting algorithms. `GetNeighbors` produces a new array via `ToArray()`, ensuring full isolation against subsequent external modifications.
- **ES:** **Gestión de memoria:** El recolector de basura de .NET (GC) gestiona la liberación automática de nodos desvinculados en `TreeNode` o arrays temporales generados en consultas de vecinos.
- **EN:** **Memory management:** The .NET Garbage Collector (GC) manages automatic reclamation for unlinked `TreeNode` nodes or transient arrays created during neighbor queries.

---

## 🔍 Checklist de validación / Validation checklist

- [x] La suite nativa se ejecutó y su salida real está copiada en este README.
- [x] Cada caso de la especificación tiene su fila en _Cobertura de pruebas_ (o `Omitido` con razón).
- [x] Cada desviación del pseudocódigo o de la ubicación esperada está en _Adaptaciones idiomáticas_.
- [x] Cada operación con fallo posible está en _Indicadores de fallo_.
- [x] No hay rutas absolutas del autor, credenciales ni salidas inventadas.
- [x] Los enlaces relativos resuelven dentro del repositorio y el documento es bilingüe.
- [x] Ninguna sección repite lo que ya dice la especificación.

---

## 📚 Referencias / References

| Tipo / Kind | Referencia / Reference |
|---|---|
| Especificación / Specification | [`07_Data_Structures_Advanced.md`](../../../../../docs/core/algorithms/07_Data_Structures_Advanced.md) |
| Primera base del lenguaje / First language reference | `data_structures_basics` — [`csharp/core/algorithms/data_structures_basics/`](../data_structures_basics/README.md) |
| Segunda base del lenguaje / Second language reference | `numbers` — [`csharp/core/foundations/numbers/`](../../foundations/numbers/README.md) |
| Guía de inicialización / Initialisation guide | [`core/00_Project_Initialization_Guide.md`](../../../../../docs/core/00_Project_Initialization_Guide.md) |
| Adaptaciones idiomáticas / Idiomatic adaptations | [`AGENT_Template.md`](../../../../../docs/AGENT_Template.md) |
| Validación de la documentación / Documentation validation | [`WORKFLOW.md`](../../../../../docs/WORKFLOW.md) |
| Documentación oficial del lenguaje / Language official docs | [learn.microsoft.com/dotnet/csharp](https://learn.microsoft.com/dotnet/csharp/) · [xunit.net](https://xunit.net/) |

---

*[← Volver a Algorithms Pure](../README.md) | [↑ Volver a Core](../../README.md)*

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
