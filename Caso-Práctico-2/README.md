# Caso Práctico 2

| Curso                         | Programación Avanzada            |
| :---------------------------- | :------------------------------- |
| Código                        | SC-601                           |
| Profesor                      | Luis Andrés Rojas Matey          |
| Fecha y hora de entrega final | Miércoles 6 de agosto a las 9 pm |
| Valor                         | 15 %                             |

<br />

## Especificaciones generales

El _Solution_ contiene un _Project_ hecho con el `.NET Framework 4.8.1`. Este _Project_ es una aplicación web con arquitectura MVC (_Model-View-Controller_) que incluye un servicio web (_Web API_).

El objetivo es que se resuelvan los diferentes ítemes aquí establecidos. Se recomienda hacerlos en el orden indicado.

Se especificarán los componentes (elementos de HTML, _Interfaces_, _Controllers_, _Views_, _Endpoints_, etc.) en los cuales se debe trabajar cada ítem.

<br />

### 1. _Build_

Este debe ser el primer paso, debido a que si no se resuelven los errores de compilación, la aplicación no se puede ejecutar.

- Arregle el error de compilación del _Interface_ `IAuth`.

- Arregle el error de compilación de la _Class_ `LogAttribute`.

<br />

### 2. _Helpers_

- Cambie los elementos HTML de tipo _Anchor Links_ (`<a>...</a>`) por sus correspondientes _HTML Helpers_ de `ASP.NET` en el _View_ `_Layout`.

<br />

### 3. _Filters_

- Agregue el _Action Filter_ `LogAttribute` en el _Controller_ `HomeController`, una sola vez, de tal modo que todos sus _Actions_ "logueen" al _Debug Console_, según está definido en dicho _Filter_.

- Agregue el _Action Filter_ `AuthAttribute` al _Action_ `Unauth` del _Controller_ `HomeController`. Esto hará que cada vez que se acceda a su correspondiente página (con la URL `/Home/Unauth`) se tire un _Exception_.

<br />

### 4. _Errors_ 

- Modifique el _Controller_ `HomeController` para que los detalles de cualquier _Exception_ (de sus _Actions_) sea desplegado con el _View_ `Error`. Note que, por ejemplo, esto sucederá cuando se accede a la página con el URL `/Home/Unauth`, debido al _Exception_ lanzado por el _Filter_ `AuthAttribute`.

<br />

### 5. _Data_

- Modifique los _Actions_ `Index` y `Redirect` del _Controller_ `HomeController`, de tal forma que cuando el `Redirect` es ejecutado, el _Title_ de la página sea **Redirect** en vez de **Home**.

<br />

### 6. _View_ 

- Modifique el _Action_ `Ajax` del _Controller_ `HomeController`, para que el _Title_ de la página sea `Ajax` y retorne el _View_ `Ajax`.

<br />

### 7. jQuery

- Modifique la función de **JavaScript** `showName` del _View_ `Index` con el objetivo de mantener su comportamiento pero utilizando únicamente "vanilla" **JavaScript**, es decir, remover todo uso de **jQuery**. Esta función despliega el nombre, caracter por caracter, introducido en el campo de texto.

<br />

### 8. _Web API_ 

- Modifique el _Action_ `Get()` del _Controller_ `ValuesController`, para que también retorne (como parte del _List_ de _Key/Value Pair_) otro elemento que contenga la hora actual en [UTC](https://es.wikipedia.org/wiki/Tiempo_universal_coordinado), donde su _Key_ sea `Utc` y su _Value_ sea su valor en _String_. Esta información se puede observar en el URL `/Home/Ajax`, específicamente al hacer clic al botón llamado `Dates & Times`.

- Modifique el _Action_ `Get(int number)` del _Controller_ `ValuesController`, para que retorne un _List_ de _Integers_ generados aleatoriamente, con una cantidad correspondiente al parámetro `number`. Estos datos se pueden ver en el URL `/Home/Ajax`, específicamente al cambiar el valor del campo `Randoms`.

<br />

### 9. _Dictionary_

- Modifique el _Dictionary_ `items` del _Controller_ `HomeController`, de tal forma que se indique por medio de un _Boolean_ con valor de **true**, aquellos ítemes de este Caso Práctico que fueron resueltos satisfactoriamente.

<br />

## Rúbrica de evaluación

| **Ítem**        | **Puntos** |
| :-------------- | :--------: |
| 1. _Build_      |     2      |
| 2. _Helpers_    |     1      |
| 3. _Filters_    |     2      |
| 4. _Errors_     |     1      |
| 5. _Data_       |     2      |
| 6. _View_       |     1      |
| 7. jQuery       |     3      |
| 8. _Web API_    |     2      |
| 9. _Dictionary_ |     1      |
| **Total**       |   **15**   |

<br />

## Entregables

Un único archivo comprimido **ZIP** con el siguiente nombre: `CP2-[Carné].zip`. Ejemplo de nombre del archivo **ZIP**: `CP2-FH12345678.zip`.

Si el archivo comprimido no es del tipo correcto (**ZIP**) o el nombre del archivo no está en el formato correcto, entonces se evaluará como "no entregado".

El mismo (archivo comprimido **ZIP**) debe contener todo el código fuente que incluya el archivo _Solution_ y la carpeta del _Project_. Sin embargo, no debe contener los archivos compilados, es decir, excluir las carpetas `bin` y `obj`.

El código fuente debe incluir, en forma de comentarios, de dónde obtuvo la respuesta/implementación, ya sea el vínculo (_link_) de una página o el nombre del _chatbot_. Ejemplos:

```js
// https://mathworld.wolfram.com/TribonacciNumber.html

// Gemini
```
