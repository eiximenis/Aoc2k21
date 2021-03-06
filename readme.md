# Advent of code 2021

Este repo contiene mis soluciones al ["Advent of Code 2021"](https://adventofcode.com/2021). Está desarrollado con C# y compilado bajo NET6.

El repo contiene dos proyectos:

- `Aoc2k21`: Implementación de las soluciones de cada uno de los ejercicios. Es una librería de clases, con una clase por cada reto.
- `Aoc2k21.Tests`: Tests unitarios (xUnit) para cada implementación

## Reto 1 - Sonar Sweep

Puedes [ver el reto aquí](https://adventofcode.com/2021/day/1).

Hay dos implementaciones del reto: la primera (`Quiz1.GetDepthIncreases`) es una solución iterativa clásica, mientras que la segunda (`Quiz2.GetDepthIncreases_V2`) es más funcional y se basa en recorrer la colección de entrada en parejas de elementos (i, i+1) (siendo i el índice) y contar en cuantas de esas parejas se cumple que el segundo elemento sea mayor al primero.

En la segunda parte del reto nos piden que ahora hagamos ventanas de tres valores, es decir que obtengamos todas las tuplas ternarias de los valores y por cada tupla sumemos sus valores y luego miremos cuantas veces se incrementa el valor. Es decir, cuantas veces se cumple que sum(i+1, i+2, i+3) > sum(i, i+1, i+2) siendo i el índice.

La solución es relativamente sencilla (`Quiz1b.GetDepthIncreasesByTriples`) y se trata de proyectar todas las tuplas ternarias en una colección con sus sumas y luego usar esa colección como entrada a la función que nos resolvía la primera parte del reto :)


## Reto 2 - Dive!

Puedes [ver el reto aquí](https://adventofcode.com/2021/day/2).

La primera parte del reto es sencillita: tenemos un submarino que tiene una posición inicial (horizontal=0, profunidad=0) y tres comandos (forward, up, down) que desplazan la posición horizontal y la profundidad. Nos preguntan a que profundidad y posición horizontal estará el submarino al cabo de N movimientos.

Aquí, para facilitarme el _parsing_ del fichero de entrada he creado un `Enum` con los tres movimientos y una función `Move` en el la clase `Quiz2.Submarine` que recibe un valor de este enum, junto con el número de unidades a desplazar y llama al método correspondiente. El fichero de entrada tiene una orden por línea en formato:

```
forward 10
up 20
...
```

Al tener ese `Enum` puedo parsear el fichero usando `Enum.parse` y a otra cosa mariposa...

En la segunda parte del reto nos añaden una nueva variable (`aim`) y la profundidad depende del valor de dicha variable. Se trata de una modificación relativamente sencilla y que podéis ver en la clase `Quiz2b.AimedSubmarine`: ahora `Up` y `Down` modifican el valor de `Aim` y el valor de `Depth` se modifica al llamar a `Forward`.

## Reto 3 - Binary Diagnostic

Esa ha sido divertida, y es que todo lo que tiene que ver con manejo de bits, lo es xD

A grandes rasgos en la primera parte nos contar qué digito binario se repite en cada posición de todos los elementos de un array y construir dos valores (uno llamado gamma y su complemento a uno, llamado epsilon). Lo único a tener presente es que no todos los bits importan (p. ej. en la web los valores son todos de 5 bits, pero en los datos de ejemplo son de 12). He perdido un poco de tiempo porque tenía un error, pero el único test unitario que tenía (basado en los datos de ejemplo de la web), no lo pillaba: un recordatorio de que es necesario que los tests cubran cuantos más casos mejor :) He añadido un test específico para el error (`Given_All_Ones_Gamma_Should_Be_All_Ones_And_Epsilon_Should_Be_Zero`).

La segunda parte del reto consiste en ir filtrando la colección de entrada en base a cuantos valores hay por cada bit. He optado por una solución iterativa pura y dura. La única diferencia es que el valor del _oxygen generating rate_ se puede ir calculando a medida que se va filtrando, el de CO2 no he encontrado como y debo ir filtrando hasta quedarme con un único valor.