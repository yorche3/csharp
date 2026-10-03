# Data Structures Basics — C\#

Implementación de la especificación [06_Data_Structures_Basics](https://yorche3.github.io/programming_languages/core/algorithms/06_Data_Structures_Basics/) en **C# (.NET 10)**, usando **xUnit** como framework de pruebas unitarias.

Define un tipo `Node` compartido y tres ADTs independientes: `LinkedList`, `Stack` y `Queue`, implementados manualmente sobre el mismo `Node` sin dependencias entre estructuras ni uso de colecciones de la biblioteca estándar.

Implementation of the [06_Data_Structures_Basics](https://yorche3.github.io/programming_languages/core/algorithms/06_Data_Structures_Basics/) specification in **C# (.NET 10)**, using **xUnit** as the unit testing framework.

Defines a shared `Node` type and three independent ADTs: `LinkedList`, `Stack`, and `Queue`, all manually implemented over the same `Node` without cross-structure dependencies or standard library collection usage.

---

## 📂 Archivos y estructura / Files & Structure

| Archivo / Directory | Propósito / Purpose |
|---|---|
| [`DataStructuresBasics.slnx`](DataStructuresBasics.slnx) | Archivo de solución .NET — referencia los proyectos `src/` y `test/` / .NET solution file — references `src/` and `test/` projects |
| [`src/DataStructuresBasics/Node.cs`](src/DataStructuresBasics/Node.cs) | Clase `Node` — nodo enlazado compartido con `Value` y enlace `Next` / `Node` class — shared linked node with `Value` and `Next` link |
| [`src/DataStructuresBasics/LinkedList.cs`](src/DataStructuresBasics/LinkedList.cs) | Clase `LinkedList` — lista lineal enlazada con inserción en ambos extremos y borrado / `LinkedList` class — linear linked list with head/tail insertions and deletion |
| [`src/DataStructuresBasics/Stack.cs`](src/DataStructuresBasics/Stack.cs) | Clase `Stack` — pila LIFO con operaciones sobre `_top` / `Stack` class — LIFO stack with operations on `_top` |
| [`src/DataStructuresBasics/Queue.cs`](src/DataStructuresBasics/Queue.cs) | Clase `Queue` — cola FIFO con punteros `_front` y `_rear` / `Queue` class — FIFO queue with `_front` and `_rear` pointers |
| [`src/DataStructuresBasics/DataStructuresBasics.csproj`](src/DataStructuresBasics/DataStructuresBasics.csproj) | Proyecto de biblioteca de clases — target `net10.0` / Class library project — target `net10.0` |
| [`test/DataStructuresBasics.Tests/UnitTest1.cs`](test/DataStructuresBasics.Tests/UnitTest1.cs) | Suite xUnit — 4 tests (`[Fact]`) que ejecutan pasos sucesivos sobre la misma instancia por ADT / xUnit suite — 4 tests (`[Fact]`) executing successive steps on the same instance per ADT |
| [`test/DataStructuresBasics.Tests/DataStructuresBasics.Tests.csproj`](test/DataStructuresBasics.Tests/DataStructuresBasics.Tests.csproj) | Proyecto de tests xUnit — referencia la biblioteca de clases / xUnit test project — references class library |

**Estructura de directorios / Directory structure:**

```text
data_structures_basics/
├── DataStructuresBasics.slnx
├── src/
│   └── DataStructuresBasics/
│       ├── DataStructuresBasics.csproj
│       ├── LinkedList.cs
│       ├── Node.cs
│       ├── Queue.cs
│       └── Stack.cs
├── test/
│   └── DataStructuresBasics.Tests/
│       ├── DataStructuresBasics.Tests.csproj
│       └── UnitTest1.cs
└── README.md
```

> **Nota de desviación / Deviation note:**  
> **ES:** La especificación propone un único archivo `src/data_structures_basics.ext` y `test/data_structures_basics_test.ext` con `run_tests.ext`. En C# (.NET), la convención idiomática separa cada tipo público en su propio archivo (`Node.cs`, `LinkedList.cs`, `Stack.cs`, `Queue.cs`) dentro de un proyecto de biblioteca `src/DataStructuresBasics/`, y las pruebas se alojan en un proyecto xUnit (`test/DataStructuresBasics.Tests/`). No se requiere un ejecutable `run_tests` manual porque `dotnet test` descubre y ejecuta automáticamente los métodos marcados con `[Fact]`.  
> **EN:** The specification suggests a single file `src/data_structures_basics.ext` and `test/data_structures_basics_test.ext` along with `run_tests.ext`. In C# (.NET), idiomatic convention separates each public type into its own source file (`Node.cs`, `LinkedList.cs`, `Stack.cs`, `Queue.cs`) within a library project `src/DataStructuresBasics/`, and tests reside in an xUnit project (`test/DataStructuresBasics.Tests/`). A manual `run_tests` script is not needed because `dotnet test` automatically discovers and runs `[Fact]` methods.

---

## 🛠️ Enfoque y construcción / Approach & Build

**ES:** Proyecto estructurado mediante solución .NET (`.slnx`) que coordina el proyecto de biblioteca de clases y el proyecto de pruebas unitarias xUnit. Las estructuras se implementan manualmente mediante clases selladas (`sealed class`) sobre enlaces directos de `Node`. Se utilizan referencias anulables (`Node?`) para representar la ausencia nativa de enlaces (`null`), y centinela `-1` como indicador de fallo para operaciones con retorno de valor.

**EN:** Project structured via a .NET solution (`.slnx`) organizing the class library project and the xUnit test project. Data structures are manually implemented using sealed classes (`sealed class`) over direct `Node` links. Nullable reference types (`Node?`) represent native absence of links (`null`), and the sentinel `-1` represents failure for value-returning operations.

```bash
dotnet new sln -n DataStructuresBasics
dotnet new classlib -n DataStructuresBasics -o src/DataStructuresBasics
dotnet new xunit -n DataStructuresBasics.Tests -o test/DataStructuresBasics.Tests
dotnet sln add src/DataStructuresBasics/DataStructuresBasics.csproj
dotnet sln add test/DataStructuresBasics.Tests/DataStructuresBasics.Tests.csproj
```

---

## 📄 Configuración clave / Key Configuration

### `src/DataStructuresBasics/DataStructuresBasics.csproj`

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

### `test/DataStructuresBasics.Tests/DataStructuresBasics.Tests.csproj`

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
    <ProjectReference Include="..\..\src\DataStructuresBasics\DataStructuresBasics.csproj" />
  </ItemGroup>

</Project>
```

---

## 🚀 Compilación y ejecución / Build & Run

```bash
dotnet --version
dotnet build DataStructuresBasics.slnx -warnaserror
dotnet test DataStructuresBasics.slnx
```

**Salida real / Actual output:**

```text
  Determining projects to restore...
  All projects are up-to-date for restore.
  DataStructuresBasics -> ~/programming_languages/csharp/core/algorithms/data_structures_basics/src/DataStructuresBasics/bin/Debug/net10.0/DataStructuresBasics.dll
  DataStructuresBasics.Tests -> ~/programming_languages/csharp/core/algorithms/data_structures_basics/test/DataStructuresBasics.Tests/bin/Debug/net10.0/DataStructuresBasics.Tests.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:01.27
```

```text
  Determining projects to restore...
  All projects are up-to-date for restore.
  DataStructuresBasics -> ~/programming_languages/csharp/core/algorithms/data_structures_basics/src/DataStructuresBasics/bin/Debug/net10.0/DataStructuresBasics.dll
  DataStructuresBasics.Tests -> ~/programming_languages/csharp/core/algorithms/data_structures_basics/test/DataStructuresBasics.Tests/bin/Debug/net10.0/DataStructuresBasics.Tests.dll
Test run for ~/programming_languages/csharp/core/algorithms/data_structures_basics/test/DataStructuresBasics.Tests/bin/Debug/net10.0/DataStructuresBasics.Tests.dll (.NETCoreApp,Version=v10.0)
VSTest version 18.0.2 (x64)

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     4, Skipped:     0, Total:     4, Duration: 17 ms - DataStructuresBasics.Tests.dll (net10.0)
```

---

## 🧠 Algoritmos y operaciones / Algorithms & Operations

| Operación / Operation | Entrada → salida / Input → output | Complejidad / Complexity | Notas / Notes |
|---|---|---|---|
| `Node(value)` | `int → Node` | $O(1)$ | Constructor; asigna `Value = value` y `Next = null` / Constructor; sets `Value = value` and `Next = null` |
| `Node.Value` | `() → int` | $O(1)$ | Propiedad get / Getter property |
| `Node.Next` | `() → Node?` | $O(1)$ | Propiedad get/set; enlace al siguiente nodo o `null` / Getter/setter property; link to next node or `null` |
| `LinkedList()` | `() → LinkedList` | $O(1)$ | Inicializa `_head = null`, `_tail = null`, `_count = 0` / Initializes `_head = null`, `_tail = null`, `_count = 0` |
| `LinkedList.IsEmpty()` | `() → bool` | $O(1)$ | Informa si `_count == 0` / Returns whether `_count == 0` |
| `LinkedList.Size()` | `() → int` | $O(1)$ | Devuelve `_count` / Returns `_count` |
| `LinkedList.HeadValue()` | `() → int` | $O(1)$ | Devuelve `_head.Value` o `-1` si la lista está vacía / Returns `_head.Value` or `-1` if empty |
| `LinkedList.InsertHead(value)` | `int → void` | $O(1)$ | Inserta un nuevo nodo al inicio y ajusta `_head`, `_tail` y `_count` / Prepends node at head, updates pointers and count |
| `LinkedList.InsertTail(value)` | `int → void` | $O(1)$ | Inserta un nuevo nodo al final y actualiza `_tail` y `_count` / Appends node at tail, updates pointers and count |
| `LinkedList.Delete(value)` | `int → bool` | $O(n)$ | Elimina la primera aparición de `value`; devuelve `true` en éxito y `false` si no se encuentra / Removes first occurrence of `value`; returns `true` on success and `false` if not found |
| `Stack()` | `() → Stack` | $O(1)$ | Inicializa `_top = null` y `_count = 0` / Initializes `_top = null` and `_count = 0` |
| `Stack.IsEmpty()` | `() → bool` | $O(1)$ | Informa si `_count == 0` / Returns whether `_count == 0` |
| `Stack.Size()` | `() → int` | $O(1)$ | Devuelve `_count` / Returns `_count` |
| `Stack.Push(value)` | `int → void` | $O(1)$ | Apila un nuevo `Node` en `_top` / Pushes a new `Node` onto `_top` |
| `Stack.Pop()` | `() → int` | $O(1)$ | Extrae y devuelve el valor del tope, o `-1` si la pila está vacía / Pops and returns top value, or `-1` if empty |
| `Stack.Peek()` | `() → int` | $O(1)$ | Devuelve el valor del tope sin extraerlo, o `-1` si la pila está vacía / Returns top value without removal, or `-1` if empty |
| `Queue()` | `() → Queue` | $O(1)$ | Inicializa `_front = null`, `_rear = null` y `_count = 0` / Initializes `_front = null`, `_rear = null`, and `_count = 0` |
| `Queue.IsEmpty()` | `() → bool` | $O(1)$ | Informa si `_count == 0` / Returns whether `_count == 0` |
| `Queue.Size()` | `() → int` | $O(1)$ | Devuelve `_count` / Returns `_count` |
| `Queue.Enqueue(value)` | `int → void` | $O(1)$ | Encola un nuevo nodo tras `_rear` / Appends a new node after `_rear` |
| `Queue.Dequeue()` | `() → int` | $O(1)$ | Desencola y devuelve el valor de `_front`, o `-1` si la cola está vacía / Dequeues and returns front value, or `-1` if empty |
| `Queue.Peek()` | `() → int` | $O(1)$ | Devuelve el valor de `_front` sin extraerlo, o `-1` si la cola está vacía / Returns front value without removal, or `-1` if empty |

---

## 🧩 Decisiones de diseño / Design decisions

| Decisión / Decision | Alternativa considerada / Alternative | Razón / Reason |
|---|---|---|
| Clases selladas (`sealed class`) para `Node`, `LinkedList`, `Stack` y `Queue` | Clases no selladas (`class`) o estructuras (`struct`) | `sealed` evita herencia no deseada y optimiza llamadas virtuales; las estructuras requerirían copia por valor incompatible con el modelo de nodos referenciales |
| Propiedades de C# (`Value`, `Next`) en lugar de métodos getter/setter explícitos | Métodos `GetValue()`, `GetNext()`, `SetNext()` | En C#, las propiedades auto-implementadas son el mecanismo idiomático para exponer campos con control de acceso |
| Nombre `HeadValue()` en `LinkedList` | `GetHead()` | Sigue la convención idiomática de nombres en C# y refleja que devuelve el valor contenido en la cabeza y no la referencia al nodo |
| Centinela entero `-1` para operaciones que retornan valor sobre estructuras vacías | Lanzar `InvalidOperationException` o retornar `int?` | La especificación prohíbe el uso de excepciones en la Fase 1 y exige un valor indicador representable dentro del tipo devuelto |

---

## 🔀 Adaptaciones idiomáticas / Idiomatic adaptations

| Especificación / Specification | Adaptación / Adaptation | Justificación / Justification |
|---|---|---|
| Inicialización explícita `init` (`Node.init(value)`, `LinkedList.init()`, etc.) | Constructores nativos `new Node(value)`, `new LinkedList()`, `new Stack()`, `new Queue()` | En C#, los constructores son la forma idiomática y segura de garantizar que toda instancia nace en un estado válido antes de cualquier operación |
| `Node.get_value()`, `Node.get_next()`, `Node.set_next(next)` | Propiedades `Value` (solo lectura) y `Next` (lectura/escritura) | En C#, las propiedades encapsulan getters y setters de forma limpia y directa |
| `Node.next` ausente | Referencia nula (`null`) con tipo anulable `Node?` | `null` es la representación nativa de ausencia de referencias en .NET; `<Nullable>enable</Nullable>` garantiza seguridad estática en tiempo de compilación |
| `delete(value)` retorna `success`/`failure` | `bool Delete(int value)` que retorna `true` o `false` | `bool` es el tipo booleano nativo en C# para operaciones con resultado de éxito/fracaso lógico |
| `get_head`, `pop`, `dequeue`, `peek` retornan indicador de fallo en vacío | Retornan `-1` | En Fase 1 se exige evitar excepciones; `-1` es el centinela entero unificado que no colisiona con los casos de prueba |

---

## 🚨 Indicadores de fallo / Failure indicators

| Operación / Operation | Situación de fallo / Failure situation | Indicador / Indicator | Ejemplo / Example |
|---|---|---|---|
| `Node.Next` | Ausencia de nodo siguiente / Absence of next node | `null` (ausencia nativa) | `firstNode.Next` tras `new Node(10)` → `null` |
| `LinkedList.HeadValue()` | Lista vacía / Empty list | `-1` | `list.HeadValue()` tras `new LinkedList()` → `-1` |
| `LinkedList.Delete(value)` | Valor no encontrado en la lista / Value not found in list | `false` | `list.Delete(99)` → `false` |
| `Stack.Pop()` | Pila vacía / Empty stack | `-1` | `stack.Pop()` tras `new Stack()` → `-1` |
| `Stack.Peek()` | Pila vacía / Empty stack | `-1` | `stack.Peek()` tras `new Stack()` → `-1` |
| `Queue.Dequeue()` | Cola vacía / Empty queue | `-1` | `queue.Dequeue()` tras `new Queue()` → `-1` |
| `Queue.Peek()` | Cola vacía / Empty queue | `-1` | `queue.Peek()` tras `new Queue()` → `-1` |

---

## ✅ Cobertura de pruebas / Test coverage

| Caso de la especificación / Specification case | Cubierto / Covered | Prueba / Test | Notas / Notes |
|---|---|:--:|---|
| `Node` — Inicializar y observar valor/enlace | Sí | [`TestNodeOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L24-L30) | Valida `Value == 10` y `Next == null` |
| `Node` — Inicializar otro nodo, enlazar y recorrer | Sí | [`TestNodeOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L31-L39) | Valida enlace `firstNode.Next = secondNode`, lectura de `Value == 20` y fin de cadena |
| `LinkedList` — Estado vacío | Sí | [`TestLinkedListOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L48-L55) | Valida `IsEmpty() == true`, `Size() == 0`, `HeadValue() == -1` |
| `LinkedList` — Insertar por ambos extremos | Sí | [`TestLinkedListOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L56-L62) | Valida inserciones al inicio y cola, `Size() == 4` y cabeza `5` |
| `LinkedList` — Eliminar primera aparición | Sí | [`TestLinkedListOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L63-L70) | Elimina primera aparición de `10`, valida `Size() == 3` y conservación de cabeza |
| `LinkedList` — Valor ausente | Sí | [`TestLinkedListOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L71-L78) | Intento de borrado de `99` retorna `false` y conserva tamaño y cabeza |
| `LinkedList` — Vaciar la lista | Sí | [`TestLinkedListOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L79-L91) | Borra elementos restantes (`5`, `20`, `10`), valida `IsEmpty() == true`, `Size() == 0` y `HeadValue() == -1` |
| `Stack` — Estado vacío y extracción fallida | Sí | [`TestStackOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L100-L108) | Valida `IsEmpty() == true`, `Size() == 0`, `Peek() == -1` y `Pop() == -1` |
| `Stack` — LIFO y `peek` no mutante | Sí | [`TestStackOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L109-L115) | Apila `10, 20, 30`, valida `Peek() == 30` sin mutar y `Size() == 3` |
| `Stack` — Extracción y reutilización | Sí | [`TestStackOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L116-L127) | Secuencia de `Pop`, `Push` y vaciado; verifica orden LIFO `30, 40, 20, 10` y tamaño final `0` |
| `Stack` — Vacío tras extracción | Sí | [`TestStackOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L128-L134) | `Pop()` en pila vacía retorna `-1` y mantiene `IsEmpty() == true` |
| `Queue` — Estado vacío y extracción fallida | Sí | [`TestQueueOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L143-L151) | Valida `IsEmpty() == true`, `Size() == 0`, `Peek() == -1` y `Dequeue() == -1` |
| `Queue` — FIFO y `peek` no mutante | Sí | [`TestQueueOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L152-L158) | Encola `10, 20, 30`, valida `Peek() == 10` sin mutar y `Size() == 3` |
| `Queue` — Extracción y reutilización | Sí | [`TestQueueOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L159-L170) | Secuencia de `Dequeue`, `Enqueue` y vaciado; verifica orden FIFO `10, 20, 30, 40` y tamaño final `0` |
| `Queue` — Vacío tras extracción | Sí | [`TestQueueOperations`](test/DataStructuresBasics.Tests/UnitTest1.cs#L171-L177) | `Dequeue()` en cola vacía retorna `-1` y mantiene `IsEmpty() == true` |

---

## ⚠️ Limitaciones conocidas / Known limitations

| Limitación / Limitation | Impacto / Impact | Alternativa o plan / Workaround or plan |
|---|---|---|
| Indicador de fallo entero `-1` | Si se insertase el valor `-1` en la estructura, no sería posible distinguir entre el dato almacenado y una señal de fallo en `HeadValue()`, `Pop()`, `Dequeue()` o `Peek()` | El contrato de la especificación restringe las pruebas a enteros positivos; fases posteriores abordarán tipos opcionales (`Option`/`Result`) y excepciones |
| Estructuras monomórficas sobre `int` | Las clases almacenan exclusivamente enteros de 32 bits (`int`) | En Fase 1 se implementan tipos de datos elementales sin sobrecargas genéricas prematuras |

---

## 📝 Notas de implementación / Implementation Notes

- **ES:** `Node` es la única celda compartida del módulo. `LinkedList`, `Stack` y `Queue` usan instancias de `Node` directamente gestionando sus propios punteros (`_head`/`_tail`, `_top`, `_front`/`_rear`) y contadores `_count`. No hay encapsulación ni delegación de `Stack` o `Queue` sobre `LinkedList`.
- **EN:** `Node` is the sole shared cell type in the module. `LinkedList`, `Stack`, and `Queue` directly consume `Node` instances, managing their own pointers (`_head`/`_tail`, `_top`, `_front`/`_rear`) and `_count` fields. Neither `Stack` nor `Queue` wrap or delegate to `LinkedList`.
- **ES:** La nulabilidad de referencias (`<Nullable>enable</Nullable>`) asegura que las referencias no asignadas o finales (`Next`, `_head`, `_top`, etc.) sean explícitamente `null`, evitando advertencias `CS8600`/`CS8602`/`CS8603`.
- **EN:** Reference type nullability (`<Nullable>enable</Nullable>`) ensures that unassigned or terminal references (`Next`, `_head`, `_top`, etc.) are explicitly `null`, avoiding `CS8600`/`CS8602`/`CS8603` warnings.
- **ES:** El recolector de basura de .NET (GC) gestiona la liberación de memoria de los nodos desvinculados en `Delete`, `Pop` y `Dequeue`.
- **EN:** The .NET Garbage Collector (GC) handles memory reclamation for nodes unlinked during `Delete`, `Pop`, and `Dequeue`.

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
| Especificación / Specification | [`06_Data_Structures_Basics.md`](../../../../../docs/core/algorithms/06_Data_Structures_Basics.md) |
| Módulo homologado del lenguaje / Homologated module | [`csharp/core/algorithms/naive_sort/`](../naive_sort/README.md) |
| Guía de inicialización / Initialisation guide | [`core/00_Project_Initialization_Guide.md`](../../../../../docs/core/00_Project_Initialization_Guide.md) |
| Adaptaciones idiomáticas / Idiomatic adaptations | [`AGENT_Template.md`](../../../../../docs/AGENT_Template.md) |
| Validación de la documentación / Documentation validation | [`WORKFLOW.md`](../../../../../docs/WORKFLOW.md) |
| Documentación oficial del lenguaje / Language official docs | [learn.microsoft.com/dotnet/csharp](https://learn.microsoft.com/dotnet/csharp/) · [xunit.net](https://xunit.net/) |

---

*[← Volver a Algorithms Pure](../README.md) | [↑ Volver a Core](../../README.md)*

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
