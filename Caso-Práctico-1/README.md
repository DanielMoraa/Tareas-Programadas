# Caso Práctico 1

| Curso                         | Programación Avanzada           |
| :---------------------------- | :------------------------------ |
| Código                        | SC-601                          |
| Profesor                      | Luis Andrés Rojas Matey         |
| Fecha y hora de entrega final | Miércoles 25 de mayo a las 9 pm |
| Valor                         | 15 %                            |

<br />

## Especificaciones generales

El _solution_ contiene 3 _projects_ hechos con el `.NET Framework 4.8.1`, los cuales no tienen relación entre sí, es decir, son independientes:

- **Console**: una aplicación de consola.

- **EF**: una aplicación de consola que utiliza el `Entity Framework 6` (`EF6`).

- **MVC**: una aplicación web con arquitectura _Model-View-Controller_.

En cada proyecto se deben trabajar 4 categorías:

- **_Errors_**: arreglar los errores de compilación.
- **_Fix_**: arreglar el error de ejecución.
- **_Update_**: incluir un nuevo componente o lógica de ejecución.
- **_Improvement_**: mejorar algún componente o lógica de ejecución.

Los **_Errors_** sin arreglar no permiten la ejecución del proyecto, por lo que esto es lo primero que se debe resolver.

<br />

## Console

Esta aplicación contiene una implementación del algoritmo de [Tribonacci](https://mathworld.wolfram.com/TribonacciNumber.html) de tipo recursivo (el método se llama `TribonacciRecursivo`). Esta secuencia está definida como:

```
T(1) = 1
T(2) = 1
T(3) = 2
T(n) = T(n - 1) + T(n - 2) + T(n - 3)
```

Al ejecutarse, el programa le consulta al usuario por un número entero positivo `n` (se puede suponer que el usuario siempre va a digitar un número entero) y luego ejecuta el algoritmo con ese número.

<br />

### **_Improvement_**

Mostrarle al usuario un mensaje cuando este digita un número que no está en el rango adecuado: mayor que 0 y menor que 40.

<br />

### **_Update_**

Implementar el algoritmo de Tribonacci de modo iterativo. Para esto se debe actualizar el método `TribonacciIterativo`.

<br />

### **_Fix_**

Arreglar la implementación de ambos algoritmos (`TribonacciRecursivo` y `TribonacciIterativo`) para que el resultado de `n = 38` y `n = 39` sean correctos (enteros positivos). Es decir, por ejemplo, este resultado es erróneo (`n = 39`):

```
Digite el valor de 'n': 39
Tribonacci Recursivo: -1543615208
Tribonacci Iterativo: -1543615208
```

Debido a que el correcto sería:

```
Digite el valor de 'n': 39
Tribonacci Recursivo: 7046319384
Tribonacci Iterativo: 7046319384
```

<br />

## EF

Aplicación de consola para utilizar la estrategia de _Code-First_ con el `Entity Framework 6` (`EF6`). Cuando se ejecuta, simula un juego de **Lotto** generando aleatoriamente sus cinco **Números** del cero (0) al cuarenta (40) sin repetir, guardándolos en la base de datos SQL Server por defecto.

<br />

### **_Fix_**

Arregle el programa para que los cambios (el nuevo juego de **Lotto** y sus **Números**) sean guardados en la base de datos.

<br />

### **_Improvement_**

Mejorar el código para que el `orden` de los **Números** de cada juego de **Lotto** sea guardado en la base de datos empezando en 1 en vez de 0. Es decir, los valores de `orden` deben ser del 1 al 5 (en vez del 0 al 4).

<br />

### **_Update_**

Imprima todos los valores guardados en las tablas de la base de datos en cada ejecución, luego de que se haya generado el nuevo juego de **Lotto** con sus respectivos **Números**.

<br />

## MVC

Sitio web con arquitectura _Model-View-Controller_ con varias páginas.

<br />

### **_Fix_**

Arregle el _view_ **\_Layout.cshtml** para que permita cargar adecuadamente las páginas.

<br />

### **_Update_**

Agregue un _annotation_ al _action_ **Identificacion** (del _controller_ **CasaController**) para que solo sea accesible en la ruta `/Casa/Cedula/{id}`. Por ejemplo: `/Casa/Cedula/123456789`

<br />

### **_Improvement_**

Agregue, por medio de _annotations_, las siguientes validaciones a los _properties_ del _model_ **ClienteModel**:

- **Cedula**: `La cédula debe tener exactamente 9 dígitos.`
- **Edad**: `La edad debe estar entre 18 y 125.`
- **Nombre**: `El nombre no puede exceder los 10 caracteres.`
- **Correo**: `El correo electrónico debe contener el símbolo @.`

<br />

## Rúbrica de evaluación

|                   | **Console** | **MVC** | **WebApi** |
| ----------------: | :---------: | :-----: | :--------: |
|      **_Errors_** |      2      |    2    |     2      |
|         **_Fix_** |      1      |    1    |     1      |
|      **_Update_** |      1      |    1    |     1      |
| **_Improvement_** |      1      |    1    |     1      |
|       **Totales** |    **5**    |  **5**  |   **5**    |

<br />

## Entregables

Un único archivo comprimido **ZIP** con el siguiente nombre: `CP1-[Carné].zip`. Ejemplo de nombre del archivo **ZIP**: `CP1-FH12345678.zip`.

Si el archivo comprimido no es del tipo correcto (**ZIP**) o el nombre del archivo no está en el formato correcto, entonces se evaluará como "no entregado".

El mismo (archivo comprimido **ZIP**) debe contener todo el código fuente que incluya el archivo _solution_ y las carpetas de los _projects_. Sin embargo, no debe contener los archivos compilados, es decir, excluir las carpetas `bin` y `obj`.

El código fuente debe incluir, en forma de comentarios, de dónde obtuvo la respuesta/implementación, ya sea el vínculo (_link_) de una página o el nombre del _chatbot_. Ejemplos:

```js
// https://mathworld.wolfram.com/TribonacciNumber.html

// Gemini
```
