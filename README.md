# Tarea-Programada-1
## 🔗 Enlace del repositorio si lo subió a GitHub , GitLab o algún otro proveedor.
### Link del repositorio de Github:
- **Recurso:** [Github - Repositorio](https://github.com/DanielMoraa/Tarea-Programada-1)


## 📚 Páginas web donde halló posibles soluciones a problemas encontrados o snippets de código

### ¿Cómo hacemos un input básico en C#?
- **Recurso:** [YouTube - Input básico en C#](https://www.youtube.com/watch?v=_SXJyA605bI)

### ¿Cómo convertimos o "parseamos" un tipo de dato en C#?
- **Recurso:** [TryParse - Converting Datatypes in C#](https://tutorials.eu/tryparse-converting-datatypes-in-csharp-net-7/#:~:text=TryParse%20tries%20to%20convert%20a,output%20gets%20a%20default%20value.)

### Función matemática "Math.Sqrt()" (para raíz cuadrada) en C# y cómo aplicarla:
- **Recurso:** [Codecademy - Math.Sqrt()](https://www.codecademy.com/resources/docs/c-sharp/math-functions/sqrt)

### Función matemática "Math.Abs()" (en este caso, para obtener el valor absoluto) en C# y cómo aplicarla:
- **Recurso:** [Codecademy - Math.Abs()](https://www.codecademy.com/resources/docs/c-sharp/math-functions/abs)

---

## 🤖 Prompts (consultas y respuestas) y los chatbots de IA (Copilot, Gemini, ChatGPT, etc.) que haya usado

**Referencia:** Anthropic. (2025). Claude 4 Sonnet [Large Language Model]. Recuperado de https://claude.ai

### Prompt 1:
> "Teniendo en cuenta el golden ratio (phi) y usando la secuencia de Fibonacci, necesito que le solicites al usuario un número entre 2 y 45, posteriormente, mostrarás tres cosas, el valor de Phi, las aproximaciones y los dos últimos valores de Fibonacci."

**Respuesta:**
Perfecto, vamos a estructurar tu programa paso a paso. Necesitas tres secciones principales:

```csharp
class Program 
{
    static void Main(string[] args)
    {
        Console.Write("Type an integer from 2 to 45: ");
            string input = Console.ReadLine();
            
            // Validar entrada
            if (!int.TryParse(input, out int n) || n < 2 || n > 45)
            {
                Console.WriteLine("Input is out of range");
                return;
            }
            
            // 1. Calcular Phi usando la fórmula: (1 + sqrt(5)) / 2
            double phi = (1 + Math.Sqrt(5)) / 2;
            Console.WriteLine($"Phi ~ {phi}");
            
            // Calcular los valores de Fibonacci iterativamente
            int[] fibonacci = new int[n + 1];
            fibonacci[0] = 0;
            fibonacci[1] = 1;
            
            for (int i = 2; i <= n; i++)
            {
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            }
            
            // 2. Mostrar aproximaciones de Phi usando ratios de Fibonacci
            for (int i = 2; i <= n; i++)
            {
                double ratio = (double)fibonacci[i] / fibonacci[i - 1];
                double difference = Math.Abs(ratio - phi);
                Console.WriteLine($"Fib({i}) / Fib({i - 1}) ~ {ratio} [+- {difference}]");
            }
            
            // 3. Mostrar Fib(n) y Fib(n-1)
            Console.WriteLine($"Fib({n}) = {fibonacci[n]}");
            Console.WriteLine($"Fib({n - 1}) = {fibonacci[n - 1]}");
    }
}
```

La clave está en usar un algoritmo iterativo para Fibonacci (más eficiente que recursión) y ir calculando cada ratio conforme generas los números. ¿Te parece bien esta estructura básica?

---

### Prompt 2:
> "Gracias, la estructura está bien, sin embargo y por cuestiones de eficiencia, es realmente necesario tener un bucle for dedicado al calculo de Fibonacci?"

**Respuesta:**
Excelente pregunta sobre optimización. Definitivamente es mejor calcular los valores de Fibonacci conforme los necesitas en un solo bucle. Esto es más eficiente por varias razones:

**Opción menos eficiente (dos bucles separados):**
```csharp
// Primer bucle: calcular todos los Fibonacci
for (int i = 2; i <= n; i++) {
    fibonacci[i] = fibonacci[i-1] + fibonacci[i-2];
}

// Segundo bucle: mostrar ratios
for (int i = 2; i <= n; i++) {
    double ratio = (double)fibonacci[i] / fibonacci[i-1];
    // mostrar resultado
}
```

**Opción más eficiente (un solo bucle):**
```csharp
for (int i = 2; i <= n; i++) {
    fibonacci[i] = fibonacci[i-1] + fibonacci[i-2];  // Calcular
    double ratio = (double)fibonacci[i] / fibonacci[i-1];  // Usar inmediatamente
    double difference = Math.Abs(ratio - phi);
    Console.WriteLine($"Fib({i}) / Fib({i-1}) ~ {ratio} [+- {difference}]");
}
```

La segunda opción es mejor porque reduces iteraciones, usas menos memoria activa, y el código es más limpio y directo.

---

### Prompt 3:
> "Perfecto, ya por último y para ver si entendí correctamente, podrías explicarme exactamente que hace esta parte del código:"

```csharp
// Calcular los valores de Fibonacci iterativamente
int[] fibonacci = new int[n + 1];
fibonacci[0] = 0;
fibonacci[1] = 1;
// 2. Mostrar aproximaciones de Phi usando ratios de Fibonacci
for (int i = 2; i <= n; i++)
{
    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
    double ratio = (double)fibonacci[i] / fibonacci[i - 1];
    double difference = Math.Abs(ratio - phi);
    Console.WriteLine($"Fib({i}) / Fib({i - 1}) ~ {ratio} [+- {difference}]");
}
```

**Respuesta:**
¡Por supuesto! Analicemos esta sección línea por línea:

**Preparación del arreglo:**
```csharp
int[] fibonacci = new int[n + 1];  // Crea arreglo con posiciones 0 hasta n
fibonacci[0] = 0;  // Fib(0) = 0 (caso base)
fibonacci[1] = 1;  // Fib(1) = 1 (caso base)
```

**El bucle principal:**
```csharp
for (int i = 2; i <= n; i++)  // Desde Fib(2) hasta Fib(n)
{
    // Paso 1: Calcular el siguiente Fibonacci
    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
    
    // Paso 2: Calcular la aproximación a Phi
    double ratio = (double)fibonacci[i] / fibonacci[i - 1];
    
    // Paso 3: Medir qué tan cerca está de Phi real
    double difference = Math.Abs(ratio - phi);
    
    // Paso 4: Mostrar el resultado formateado
    Console.WriteLine($"Fib({i}) / Fib({i - 1}) ~ {ratio} [+- {difference}]");
}
```

Lo brillante de este diseño es que combina cálculo y presentación en una sola pasada. Cada iteración genera un nuevo número de Fibonacci y inmediatamente lo usa para mostrar qué tan bien aproxima a Phi. Es eficiente, claro y matemáticamente elegante.

---

## 💻 Código final (interpretación propia)

```csharp
Console.Write("Ingrese un entero entre 2 y 45: "); //Mediante Console.Write se pide el valor entre 2 y 45 al usuario.
string input = Console.ReadLine(); //Se lee el valor que ingresó el usuario y se guarda en la variable input.

// Se valida la entrada 
if (!int.TryParse(input, out int n) || n < 2 || n > 45)
{
    Console.WriteLine("El valor está fuera de rango!"); //Mensaje si es que el valor ingresado es "a" o "1", o sea, si no cumple con los estándares de parseo o con el rango establecido.
    return;
}

// Cálculo del valor de Phi, además de su impresión mediante un Console.WriteLine.
double phi = (1 + Math.Sqrt(5)) / 2; //El valor de phi corresponde a esta fórmula que utiliza la funcion matemática Math.Sqrt.
Console.WriteLine($"Phi ~ {phi}"); //Se imprime el valor calculado anteriormente.

// De forma iterativa, se calculan los valores de Fibonacci
int[] fibonacci = new int[n + 1]; //Creación del arreglo 
fibonacci[0] = 0; //Asignacion de valor a las primeras 2 posiciones del arreglo. 
fibonacci[1] = 1;

// Mostrar aproximaciones de Phi usando ratios de Fibonacci
for (int i = 2; i <= n; i++) //Creación del bucle for iniciando en 2
{
    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2]; //Formula de Fibonacci
    double division = (double)fibonacci[i] / fibonacci[i - 1]; //División entre dos valores secuenciales de Fibonacci
    double diferencia = Math.Abs(division - phi); //Diferencia, séase el valor absoluto de la resta de los valores de la variable "division" y "phi". 
    Console.WriteLine($"Fib({i}) / Fib({i - 1}) ~ {division} [+- {diferencia}]"); //Se imprimen de forma iterada los valores secuenciales de Fibonacci, la división entre ellos y la diferencia absoluta.
}

// Se muestran Fib(n) y Fib(n-1)
Console.WriteLine($"Fib({n}) = {fibonacci[n]}");
Console.WriteLine($"Fib({n - 1}) = {fibonacci[n - 1]}");
```

