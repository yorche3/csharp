# Hello, World! — C\#

Implementación de la especificación [01_Hello_World](https://yorche3.github.io/programming_languages/core/foundations/01_Hello_World/) en **C# (.NET 10)**, usando el **.NET SDK** y el modelo de **top-level statements**.

---

## 📂 Archivos y estructura / Files & Structure

| Archivo | Propósito |
|---------|-----------|
| [`Program.cs`](Program.cs) | Código fuente: imprime `"Hello, World! from C#!"` en la consola. |
| [`helloworld.csproj`](helloworld.csproj) | Proyecto .NET — declara el target framework (`net10.0`), output type (`Exe`), y opciones del compilador. |

**Estructura de directorios esperada:**

```text
helloworld/
├── Program.cs            # Código fuente
├── helloworld.csproj     # Proyecto .NET
├── README.md             # Este archivo
├── bin/                  # Compilados (generado por dotnet build/run)
└── obj/                  # Objetos intermedios (generado por dotnet build/run)
```

---

## 🛠️ Enfoque y construcción / Approach & Build

**ES:** Este proyecto usa el **.NET SDK** y sigue el modelo más moderno de C#: **top-level statements** (introducido en C# 9 / .NET 5). No se necesita una clase `Program` explícita ni un método `Main`.

**EN:** This project uses the **.NET SDK** and follows the modern C# model: **top-level statements** (introduced in C# 9 / .NET 5). No explicit `Program` class or `Main` method is needed.

---

## 📄 Nomenclatura / Naming

> **ES:** La especificación `01_Hello_World.md` define nombres con guión bajo (`hello_world`), pero las herramientas de .NET usan convenciones diferentes:
>
> | Especificación | Este proyecto | Motivo |
> |----------------|---------------|--------|
> | `hello_world/` | `helloworld/` | El nombre del proyecto .NET no admite guiones bajos por convención de nomenclatura de ensamblados |
> | `hello_world.cs` | `Program.cs` | .NET SDK genera `Program.cs` por defecto al crear un proyecto con `dotnet new console` |
> | — | `helloworld.csproj` | Archivo de proyecto .NET con configuración del SDK |
>
> **EN:** The `01_Hello_World.md` specification defines underscore names (`hello_world`), but .NET tools use different conventions:
>
> | Specification | This project | Reason |
> |---------------|--------------|--------|
> | `hello_world/` | `helloworld/` | .NET project names don't use underscores by assembly naming convention |
> | `hello_world.cs` | `Program.cs` | .NET SDK generates `Program.cs` by default when creating a project with `dotnet new console` |
> | — | `helloworld.csproj` | .NET project file with SDK configuration |

---

## 📄 Archivos de configuración clave / Key Configuration Files

### `Program.cs`

**ES:** Código fuente en C# usando top-level statements. El compilador envuelve automáticamente este código en un método `Main` implícito dentro de una clase `Program` generada.

**EN:** C# source code using top-level statements. The compiler automatically wraps this code in an implicit `Main` method inside a generated `Program` class.

```csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! from C#!");
```

| Elemento | Propósito |
|----------|-----------|
| `// ...` | Comentario de una línea (generado por la plantilla `dotnet new`) |
| `Console.WriteLine(...)` | Imprime una línea con salto de línea al final en la consola |

> **ES:** No se necesita `using System;` porque el proyecto tiene `<ImplicitUsings>enable</ImplicitUsings>`, que importa automáticamente `System` y otros namespaces comunes.
> **EN:** No `using System;` is needed because the project has `<ImplicitUsings>enable</ImplicitUsings>`, which automatically imports `System` and other common namespaces.

### `helloworld.csproj`

**ES:** Archivo de proyecto .NET en formato MSBuild. Define:

- **`OutputType`** = `Exe` → genera un ejecutable de consola.
- **`TargetFramework`** = `net10.0` → apunta a .NET 10.0.
- **`ImplicitUsings`** = `enable` → imports automáticos de namespaces comunes.
- **`Nullable`** = `enable` → habilita tipos anulables (nullable reference types).

**EN:** .NET project file in MSBuild format. Defines:

- **`OutputType`** = `Exe` → generates a console executable.
- **`TargetFramework`** = `net10.0` → targets .NET 10.0.
- **`ImplicitUsings`** = `enable` → automatic imports of common namespaces.
- **`Nullable`** = `enable` → enables nullable reference types.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

---

## 🚀 Compilación y ejecución / Build & Run

### Requisito: Tener el .NET SDK instalado

```bash
# Verificar instalación
dotnet --version
# Debería mostrar: 10.0.x
```

> **ES:** Descargar desde [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/10.0).
> **EN:** Download from [dotnet.microsoft.com](https://dotnet.microsoft.com/download/dotnet/10.0).

### Ejecutar

```bash
# Ejecutar directamente (compila y ejecuta en un solo paso)
dotnet run

# O compilar primero y luego ejecutar
dotnet build
./bin/Debug/net10.0/helloworld
```

**Salida esperada / Expected output:**

```text
Hello, World! from C#!
```

> **ES:** `dotnet run` compila y ejecuta en un solo paso. `dotnet build` solo compila y genera los artefactos en `bin/` y `obj/`.
> **EN:** `dotnet run` compiles and runs in a single step. `dotnet build` only compiles and generates artifacts in `bin/` and `obj/`.

---

## 📝 Notas de implementación / Implementation Notes

- **ES:** El proyecto se creó con `dotnet new console -n helloworld`. La plantilla genera `Program.cs` y `helloworld.csproj` automáticamente.
- **EN:** The project was created with `dotnet new console -n helloworld`. The template generates `Program.cs` and `helloworld.csproj` automatically.
- **ES:** Los top-level statements (C# 9+) eliminan la necesidad de escribir `class Program { static void Main() { ... } }`. El compilador genera el boilerplate automáticamente.
- **EN:** Top-level statements (C# 9+) eliminate the need to write `class Program { static void Main() { ... } }`. The compiler generates the boilerplate automatically.
- **ES:** Los directorios `bin/` y `obj/` son generados por el compilador y no deben versionarse. Ver [`.gitignore`](.gitignore).
- **EN:** The `bin/` and `obj/` directories are compiler-generated and should not be versioned. See [`.gitignore`](.gitignore).

---

### 🌐 Otras implementaciones / Other implementations

Este proyecto también está implementado en otros lenguajes. Explora el [repositorio principal](https://github.com/yorche3/programming_languages) para ver todas las versiones.

---

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
