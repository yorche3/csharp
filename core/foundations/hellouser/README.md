# Hello, User! — C\#

Implementación de la especificación [02_Hello_User](https://yorche3.github.io/programming_languages/core/foundations/02_Hello_User/) en **C# (.NET 10)**, usando el **.NET SDK**.

Lee un nombre desde la entrada estándar y saluda al usuario.

---

## 📂 Archivos / Files

| Archivo | Propósito |
|---------|-----------|
| [`Program.cs`](Program.cs) | Código fuente: solicita un nombre al usuario y saluda. |
| [`hellouser.csproj`](hellouser.csproj) | Proyecto .NET — declara el target framework (`net10.0`) y opciones del compilador. |
| [`README.md`](README.md) | Este archivo. |

---

## 🛠️ Enfoque / Approach

**ES:** A diferencia de `helloworld` (que usa top-level statements), este proyecto usa la **estructura clásica** de C#: clase `Program`, método `Main` estático, `namespace` explícito y `using System;` manual. Esto permite apreciar ambos estilos de programación C#.

Las novedades respecto a `helloworld` son:

1. **Lectura de entrada** — `Console.ReadLine()` lee una línea desde `stdin`.
2. **Interpolación de cadenas** — `$"Hello, {name}!"` para construir el saludo.
3. **Variables** — `string name` para almacenar el nombre ingresado.
4. **Estructura explícita** — `namespace`, `class`, `Main` en lugar de top-level statements.

**EN:** Unlike `helloworld` (which uses top-level statements), this project uses the **classic C# structure**: `Program` class, static `Main` method, explicit `namespace`, and manual `using System;`. This allows appreciating both C# programming styles.

The new concepts compared to `helloworld` are:

1. **Input reading** — `Console.ReadLine()` reads a line from `stdin`.
2. **String interpolation** — `$"Hello, {name}!"` to build the greeting.
3. **Variables** — `string name` to store the entered name.
4. **Explicit structure** — `namespace`, `class`, `Main` instead of top-level statements.

---

## 📄 Archivos clave / Key Files

### `Program.cs`

**ES:** El flujo del programa es:

1. Imprimir `"Enter your name: "` con `Console.Write` (sin salto de línea).
2. Leer una línea con `Console.ReadLine()` y asignarla a la variable `name`.
3. Imprimir el saludo con interpolación de cadenas: `$"Hello, {name}!"`.

**EN:** Program flow:

1. Print `"Enter your name: "` with `Console.Write` (no newline).
2. Read a line with `Console.ReadLine()` and assign it to the `name` variable.
3. Print the greeting with string interpolation: `$"Hello, {name}!"`.

```csharp
using System;

namespace HelloUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.WriteLine($"Hello, {name}!");
        }
    }
}
```

| Elemento | Propósito |
|----------|-----------|
| `using System;` | Importa el namespace `System` para usar `Console` |
| `namespace HelloUser` | Organiza el código en un namespace |
| `class Program` | Clase contenedora del punto de entrada |
| `static void Main(string[] args)` | Punto de entrada del programa |
| `Console.Write(...)` | Imprime sin salto de línea al final |
| `Console.ReadLine()` | Lee una línea desde la entrada estándar |
| `string name` | Variable para almacenar el nombre |
| `$"Hello, {name}!"` | Interpolación de cadenas (C# 6+) |

> **ES:** `Console.Write` se usa para el prompt (sin `\n`) y `Console.WriteLine` para el saludo (con `\n`).
> **EN:** `Console.Write` is used for the prompt (no `\n`) and `Console.WriteLine` for the greeting (with `\n`).

### `hellouser.csproj`

**ES:** Misma configuración que `helloworld`. Ver [`helloworld/README.md`](../helloworld/README.md) para la explicación detallada.

**EN:** Same configuration as `helloworld`. See [`helloworld/README.md`](../helloworld/README.md) for the detailed explanation.

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

## 🚀 Compilar y ejecutar / Build & Run

### Requisito: Tener el .NET SDK instalado

```bash
dotnet --version   # Debería mostrar: 10.0.x
```

### Ejecutar

```bash
dotnet run
```

**Salida esperada / Expected output:**

```text
Enter your name: Ada
Hello, Ada!
```

> **ES:** El programa espera a que el usuario escriba su nombre y presione Enter antes de mostrar el saludo.
> **EN:** The program waits for the user to type their name and press Enter before showing the greeting.

---

## 📁 Estructura / Structure

```text
hellouser/
├── Program.cs            # Código fuente
├── hellouser.csproj      # Proyecto .NET
├── README.md             # Este archivo
├── bin/                  # Compilados (generado por dotnet build/run)
└── obj/                  # Objetos intermedios (generado por dotnet build/run)
```

---

### 🌐 Otras implementaciones / Other implementations

Este proyecto también está implementado en otros lenguajes. Explora el [repositorio principal](https://github.com/yorche3/programming_languages) para ver todas las versiones.

---

## 📝 Notas / Notes

- **ES:** Este proyecto usa la estructura clásica (`namespace`, `class`, `Main`) a diferencia de `helloworld` que usa top-level statements. Ambos estilos son válidos en C# 10+.
- **EN:** This project uses the classic structure (`namespace`, `class`, `Main`) unlike `helloworld` which uses top-level statements. Both styles are valid in C# 10+.
- **ES:** La interpolación de cadenas con `$"..."` es una característica de C# 6+ que permite incrustar expresiones dentro de cadenas literales.
- **EN:** String interpolation with `$"..."` is a C# 6+ feature that allows embedding expressions inside string literals.
- **ES:** Los directorios `bin/` y `obj/` son generados por el compilador y no deben versionarse. Ver [`.gitignore`](.gitignore).
- **EN:** The `bin/` and `obj/` directories are compiler-generated and should not be versioned. See [`.gitignore`](.gitignore).

---

*🌐 [github.com/yorche3/programming_languages](https://github.com/yorche3/programming_languages) · [GitHub Pages](https://yorche3.github.io/programming_languages/)*
