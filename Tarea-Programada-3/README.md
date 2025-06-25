# 💻 Daniel Mora Solano - FI23030542 - Tarea Programada 3
## Code First - Aplicación de Consola para registrar eventos respecto a juegos de azar de la Junta de Protección Social (JPS).

---

## 🚀 Repositorio del Proyecto

### 📂 Enlace del repositorio de GitHub
> **Repositorio:** [GitHub - Tareas Programadas](https://github.com/DanielMoraa/Tareas-Programadas)
> 
> **Desarrollador:** Daniel Mora Solano  
> **Carnet:** FI23030542

---

## 🔗 Referencias y Recursos Técnicos

### 💻☝️ Code First en una nueva base de datos.
Cómo aplicar totalmente el Code First en una base de datos.

> **Recurso:** [Microsoft - Code First en una nueva base de datos](https://learn.microsoft.com/es-es/ef/ef6/modeling/code-first/workflows/new-database)
> 
> **Descripción:** Aplicación del Code First desde Visual Studio 2022, desde la creación de entidades, contexto, lectura y escritura en la BD, entre otros`

---


## 🤖 Prompts (consultas y respuestas) y los chatbots de IA (Copilot, Gemini, ChatGPT, etc.) que haya usado

**Referencia:** Anthropic. (2025). Claude 4 Sonnet [Large Language Model]. Recuperado de https://claude.ai

### Prompt 1:
>"Necesito crear una aplicación de consola en C# usando .NET Framework 4.8.1 y Entity Framework 6. 
La aplicación debe gestionar productos y números aleatorios asociados a cada producto. 
Configura el proyecto básico con Entity Framework 6 y crea las entidades Producto y Numero."

**Respuesta:**
Para comenzar, crearemos un proyecto de tipo Console App (.NET Framework) en Visual Studio 2022 y agregaremos Entity Framework 6 desde NuGet (EntityFramework).
A continuación, definimos nuestras dos clases de entidad: Producto y Numero, con la relación uno-a-muchos.
```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP3
{
    // Entidad Producto
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual List<Numero> Numeros { get; set; }
    }

    // Entidad Numero
    public class Numero
    {
        public int NumeroId { get; set; }
        public int Orden { get; set; }
        public int Num { get; set; }

        // Clave foránea
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

```

---

### Prompt 2:
> "Ayúdame a crear el DbContext para Entity Framework 6. Necesito:
>- Clase TP3Context que herede de DbContext
>- DbSet para Productos y Numeros
>- Configuración para crear la base de datos automáticamente si no existe
>- Connection string con nombre "TP3"
>- Relación uno-a-muchos entre Producto y Numero" 

**Respuesta:**
Ahora crearemos la clase TP3Context que extiende de DbContext, y configuraremos el inicializador para crear la BD si no existe.
```csharp
using System.Data.Entity;

namespace TP3
{
    public class TP3Context : DbContext
    {
        public TP3Context() : base("TP3") // Usamos el nombre de la cadena de conexión
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TP3Context>());
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Numero> Numeros { get; set; }
    }
}
```

---

### Prompt 3:
> "Implementa la lógica principal del programa que debe:
>- Pedir al usuario el nombre del producto
>- Pedir la cantidad de números aleatorios a generar (validar que sea > 0)
>- Si la cantidad <= 100, preguntar si los números pueden repetirse (s/n, tiene que ser case insensitive)
>- Almacenar temporalmente los productos antes de guardar en BD
>-- Permitir agregar múltiples productos en un bucle"

**Respuesta:**
Ahora vamos a implementar la lógica principal para capturar datos desde consola. Se almacenan temporalmente en una lista de productos:

```csharp 	
List<Producto> productosTemporales = new List<Producto>();
bool continuar = true;

while (continuar)
{
    Console.Write("Escriba el nombre del producto. R/ ");
    string nombreProducto = Console.ReadLine();

    Console.Write("Escriba la cantidad de números aleatorios a generar. R/ ");
    int cantidadNumeros;
    while (!int.TryParse(Console.ReadLine(), out cantidadNumeros) || cantidadNumeros <= 0)
    {
        Console.Write("Por favor ingrese un número válido mayor que 0. R/ ");
    }


    // Preguntar si desea continuar
    Console.Write("¿Desea continuar agregando Productos? (s/n) ");
    string respuestaContinuar;
    do
    {
        respuestaContinuar = Console.ReadLine();
        if (respuestaContinuar.ToLower() != "s" && respuestaContinuar.ToLower() != "n")
        {
            Console.Write("Por favor ingrese 's' o 'n'. R/ ");
        }
    } while (respuestaContinuar.ToLower() != "s" && respuestaContinuar.ToLower() != "n");

    continuar = respuestaContinuar.ToLower() == "s";
}
```

---
### Prompt 4:
> "Crea la funcionalidad para generar números aleatorios con estas reglas:
>- Rango: 0-99
>- Si pueden repetirse: generar directamente
>- Si no pueden repetirse: validar que no esté ya generado
>- Cada número debe tener un orden secuencial (1, 2, 3, ...)
>- Crear objetos Numero con Orden, Num y referencia al Producto"

**Respuesta:**
A partir de la entrada, generamos los números con o sin repetición:
```csharp
bool puedenRepetirse = true;

if (cantidadNumeros <= 100)
{
    Console.Write("¿Los números se pueden repetir? (s/n). R/ ");
    string respuestaRepetir;
    do
    {
        respuestaRepetir = Console.ReadLine();
        if (respuestaRepetir.ToLower() != "s" && respuestaRepetir.ToLower() != "n")
        {
            Console.Write("Por favor ingrese 's' o 'n'. R/ ");
        }
    } while (respuestaRepetir.ToLower() != "s" && respuestaRepetir.ToLower() != "n");

    puedenRepetirse = respuestaRepetir.ToLower() == "s";
}

Producto producto = new Producto
{
    Nombre = nombreProducto,
    FechaHora = DateTime.Now,
    Numeros = new List<Numero>()
};

Random random = new Random();
List<int> numerosGenerados = new List<int>();

for (int i = 1; i <= cantidadNumeros; i++)
{
    int numeroAleatorio;

    if (puedenRepetirse)
    {
        numeroAleatorio = random.Next(0, 100);
    }
    else
    {
        do
        {
            numeroAleatorio = random.Next(0, 100);
        } while (numerosGenerados.Contains(numeroAleatorio));
    }

    numerosGenerados.Add(numeroAleatorio);

    Numero numero = new Numero
    {
        Orden = i,
        Num = numeroAleatorio,
        Producto = producto
    };

    producto.Numeros.Add(numero);
}

productosTemporales.Add(producto);
```
---

### Prompt 5:
> "Gracias 😊ahora haz una funcionalidad para:
>1. Guardar todos los productos temporales en la base de datos usando Entity Framework
>2. Recuperar todos los productos con sus números usando Include()
>3. Mostrar los datos ordenados por fecha/hora de creación
>4. Formato de salida:
>   - "1. NombreProducto - yyyy/MM/dd HH:mm"
>   - "    NumeroId. [Orden] Valor"

**Respuesta:**
Al finalizar el bucle, se guardan los datos y se visualiza lo que se tiene en la base:

```csharp
using (var db = new TP3Context())
{
    foreach (var producto in productosTemporales)
    {
        db.Productos.Add(producto);
    }

    db.SaveChanges();

    Console.WriteLine();
    var productosDB = db.Productos
        .Include(p => p.Numeros)
        .OrderBy(p => p.FechaHora)
        .ToList();

    int contadorProducto = 1;
    foreach (var producto in productosDB)
    {
        Console.WriteLine($"{contadorProducto}. {producto.Nombre} - {producto.FechaHora:yyyy/MM/dd HH:mm}");

        var numerosOrdenados = producto.Numeros.OrderBy(n => n.Orden).ToList();
        foreach (var numero in numerosOrdenados)
        {
            Console.WriteLine($"    {numero.NumeroId}. [{numero.Orden}] {numero.Num}");
        }

        contadorProducto++;
        Console.WriteLine();
    }
}
```

### Prompt 6:
> "Por último, agrega validaciones y mejoras a la experiencia del usuario:
>- Validar entrada numérica para cantidad de números
>- Validar respuestas s/n con bucle hasta respuesta válida
>- Mensajes de "Guardando cambios..." y "... cambios Guardados"
>- Mensaje final "Programa finalizado. Presione la tecla enter para terminar."
>- Usar Console.ReadKey() al final"

**Respuesta:**
Validaciones ya han sido cubiertas, pero añadimos un cierre más elegante:
```csharp
Console.WriteLine("Guardando cambios...");
Console.WriteLine("... cambios Guardados");

Console.WriteLine("Programa finalizado. Presione la tecla enter para terminar.");
Console.ReadKey();
```


---

## 💻 Código final (interpretación propia)
**Código:**
```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace TP3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se guardan los productos en una lista temporal antes de que los guardemos en la Base de Datos.
            List<Producto> productosTemporales = new List<Producto>();

            bool continuar = true;

            while (continuar)
            {
                //Se consulta al usuario el nombre del producto, la cantidad de números aleatorios a generar y si los números pueden repetirse.
                Console.Write("Escriba el nombre del producto. R/ ");
                string nombreProducto = Console.ReadLine();

                Console.Write("Escriba la cantidad de números aleatorios a generar. R/ ");
                int cantidadNumeros;
                while (!int.TryParse(Console.ReadLine(), out cantidadNumeros) || cantidadNumeros <= 0)
                {
                    Console.Write("Por favor ingrese un número válido mayor que 0. R/ ");
                }

                // 3. Creación de una variable booleana para determinar si los números pueden repetirse o no.
                bool puedenRepetirse = true;
                // Si la cantidad de números es menor o igual a 100, se pregunta si pueden repetirse.
                if (cantidadNumeros <= 100)
                {
                    Console.Write("¿Los números se pueden repetir? (s/n). R/ ");
                    string respuestaRepetir;
                    // Se valida la respuesta del usuario, hay que tener en cuenta que esta tiene que ser case-insensitive.
                    do
                    {
                        respuestaRepetir = Console.ReadLine();
                        if (respuestaRepetir.ToLower() != "s" && respuestaRepetir.ToLower() != "n")
                        {
                            Console.Write("Por favor ingrese 's' o 'n'. R/ ");
                        }
                    } while (respuestaRepetir.ToLower() != "s" && respuestaRepetir.ToLower() != "n");

                    puedenRepetirse = respuestaRepetir.ToLower() == "s";
                }

                // Crear el producto con fecha y hora actuales.
                Producto producto = new Producto
                {
                    Nombre = nombreProducto,
                    FechaHora = DateTime.Now,
                    Numeros = new List<Numero>()
                };

                // Generar números aleatorios mediante la clase Random.
                Random random = new Random();
                // Se crea una lista para almacenar los números generados.
                List<int> numerosGenerados = new List<int>();

                // Se crea un for para generar la cantidad de números aleatorios solicitada por el usuario.
                for (int i = 1; i <= cantidadNumeros; i++)
                {
                    int numeroAleatorio;

                    if (puedenRepetirse)
                    {
                        numeroAleatorio = random.Next(0, 100); 
                    }
                    else
                    {
                        do
                        {
                            numeroAleatorio = random.Next(0, 100); 
                        } while (numerosGenerados.Contains(numeroAleatorio));
                    }

                    numerosGenerados.Add(numeroAleatorio);

                    //Se crea un objeto Numero con el número aleatorio generado y se agrega a la lista de números del producto.
                    Numero numero = new Numero
                    {
                        Orden = i,
                        Num = numeroAleatorio,
                        Producto = producto
                    };

                    producto.Numeros.Add(numero);
                }

                productosTemporales.Add(producto);

                //Se le avisa al usuario que se guardaron los cambios en la lista. 
                Console.WriteLine("Guardando cambios...");
                Console.WriteLine("... cambios Guardados");

                // 4. Pregunta si desea agregar otro producto
                Console.Write("¿Desea continuar agregando Productos? (s/n) ");
                string respuestaContinuar;
                do
                {
                    respuestaContinuar = Console.ReadLine();
                    if (respuestaContinuar.ToLower() != "s" && respuestaContinuar.ToLower() != "n")
                    {
                        Console.Write("Por favor ingrese 's' o 'n'. R/ ");
                    }
                } while (respuestaContinuar.ToLower() != "s" && respuestaContinuar.ToLower() != "n");

                continuar = respuestaContinuar.ToLower() == "s";
            }

            // A. Forma de guardar los productos en la base de datos y mostrar los productos y números generados.
            using (var db = new TP3Context()) //Se llama al contexto de la base de datos
            {
                foreach (var producto in productosTemporales) //por cada producto en la lista temporal 
                {
                    db.Productos.Add(producto); //guardamos el productos en la base de datos
                }
                db.SaveChanges(); //Mediante SaveChanges guardamos los cambios en la base de datos.

                // B. Forma para mostrar todos los productos y números desde la base de datos 
                Console.WriteLine();
                var productosDB = db.Productos
                    .Include(p => p.Numeros)
                    .OrderBy(p => p.FechaHora)
                    .ToList();

                foreach (var producto in productosDB)
                {
                    Console.WriteLine($"{producto.ProductoId} → {producto.Nombre} - {producto.FechaHora:dd/MM/yyyy HH:mm}");

                    var numerosOrdenados = producto.Numeros.OrderBy(n => n.Orden).ToList();
                    foreach (var numero in numerosOrdenados)
                    {
                        Console.WriteLine($"    {numero.NumeroId} →[{numero.Orden}] {numero.Num}");
                    }
                    Console.WriteLine();
                }
            }

            // C. Mensaje de finalización
            Console.WriteLine("Programa finalizado. Presione la tecla enter para terminar.");
            Console.ReadKey();
        }
    }

    // Entidad Producto (Por cuestiones de EntityFramework, se pluraliza al inglés, "Productoes" o "Numeroes", en este caso se define desde la creación de la entidad, el nombre de la tabla).
    [Table("Producto")]
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaHora { get; set; }

        public virtual List<Numero> Numeros { get; set; }
    }

    // Entidad Numero
    [Table("Numero")]
    public class Numero
    {
        public int NumeroId { get; set; }
        public int Orden { get; set; }
        public int Num { get; set; }
        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
    }

    // Contexto de Entity Framework (Base de Datos)
    public class TP3Context : DbContext
    {
        public TP3Context() : base("TP3")
        {
            // Configurar para que cree la base de datos si no existe
            Database.SetInitializer(new CreateDatabaseIfNotExists<TP3Context>());
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Numero> Numeros { get; set; }
    }
}
```

