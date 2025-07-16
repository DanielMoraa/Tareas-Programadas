# 💻 Daniel Mora Solano - FI23030542 - Tarea Programada 4
## ¡Implementación de NodeJS, Transformación de sintáxis JavaScript Vanilla a JQuery, Criba de Eratóstenes, Números pares, impares y primos!

---

## 🚀 Repositorio del Proyecto

### 📂 Enlace del repositorio de GitHub
> **Repositorio:** [GitHub - Tareas Programadas](https://github.com/DanielMoraa/Tareas-Programadas)
> 
> **Desarrollador:** Daniel Mora Solano  
> **Carnet:** FI23030542

---

## 🔗 Referencias y Recursos Técnicos

### 💻🌟Código de referencia para extracción de números primos.

> **Recurso:** [TutorialsPoint - Using Sieve of Eratosthenes to find primes JavaScript](https://www.tutorialspoint.com/using-sieve-of-eratosthenes-to-find-primes-javascript)
> **Recurso:** [StackOverFlow - Sieve of Eratosthenes algorithm in JavaScript running endless for large number](https://stackoverflow.com/questions/15471291/sieve-of-eratosthenes-algorithm-in-javascript-running-endless-for-large-number)
> 
> **Descripción:** Aplicación de la Criba de Eratóstenes en el contexto del código (extracción de números primos).`

### 🖥❓JavaScript Vanilla vs. JQuery ¿Qué diferencias tienen?.

> **Recurso:** [SimpliLearn - jQuery vs JavaScript: Know Their Differences](https://www.simplilearn.com/jquery-vs-javascript-article)
> 
> **Descripción:** Diferencias de sintaxis entre el lenguaje de programación JavaScript y la librería JQuery.`

---


## 🤖 Prompts (consultas y respuestas) y los chatbots de IA (Copilot, Gemini, ChatGPT, etc.) que haya usado

**Referencia:** Anthropic. (2025). Claude 4 Sonnet [Large Language Model]. Recuperado de https://claude.ai

### Link a la conversación con Claude AI:
https://claude.ai/share/751e6bdb-2885-4a9e-86f5-79e4b56ca596

---

## 💻 Código final (interpretación propia)
**Código:**
```JQuery
  <script defer>
    $(document).ready(() => {
      const $numeros = $("#numeros"); //Equivalente a document.querySelector("#numeros") selecciona los elementos.

      const limite = 100; //Máximo de números
      const esPrimo = new Array(limite + 1).fill(true); //Creación del arreglo que tiene que empezar "n+1" y tiene que inicializarse su valor en true.
      esPrimo[0] = esPrimo[1] = false; //Se definen los dos primeros valores como falso ¿Por qué? Porque 0 y 1 no son números primos.

      //Ciclo que elimina los múltiplos de los números primos, los marca como false en el arreglo.
      for (let i = 2; i <= Math.sqrt(limite); i++) { //Empieza por dos, primer número primo.
        if (esPrimo[i]) {
          for (let j = i * i; j <= limite; j += i) {
            esPrimo[j] = false;
          }
        }
      }

      //Ciclo principal de los números mostrados
      for (let num = 1; num <= limite; num++) {
        const $li = $("<li>") //Equivalencia a document.createElement("li") - como dice el nombre, crea el elemento.
          .attr("id", num) //En JS = li.id = num - Configura los atributos
          .text(num) //li.innerText = num - Configura el texto
          .addClass(num % 2 === 0 ? "par" : "impar"); //li.classList.add() - Añade una clase
        //En el caso de que el número sea primo, añade la clase pertinente.  
        if (esPrimo[num]) {
          $li.addClass("primo");
        }
        $numeros.append($li); //numeros.appendChild(li) - Añadir elementos/datos
      }

      //Definición de los switches!
      $("#pares").on("click", function (ev) { //document.getElementById("pares") = $("#pares") - Consigue el id del main 
        const $paresLista = $(".par"); //En JS, sería document.querySelectorAll(".par")
        const func = ev.target.checked ? "removeClass" : "addClass";
        $paresLista[func]("oculto");
      });
      // Final # 1

      // Inicio # 2
      $("#impares").on("click", function (ev) { //on("click", callback) = addEventListener("click", callback) - Llama al evento, en este caso cuando se le da click
        const $imparesLista = $(".impar");
        const func = ev.target.checked ? "removeClass" : "addClass";
        $imparesLista[func]("oculto"); //classList[func]("oculto") - Se manipulan las clases de los eventos para que se oculten al momento de darle click al switch
      });
      // Final # 2

      // Inicio # 3
      $("#primos").on("click", function (ev) {
        const $primosLista = $(".primo");
        const func = ev.target.checked ? "removeClass" : "addClass";
        $primosLista[func]("oculto");
      });
      // Final # 3
    });
  </script>
```

