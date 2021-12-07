1# Advent of code 2021

Este repo contiene mis soluciones al "Advent of Code 2021". Está desarrollado con C# y compilado bajo NET6.

El repo contiene dos proyectos:

- `Aoc2k21`: Implementación de las soluciones de cada uno de los ejercicios. Es una librería de clases, con una clase por cada reto.
- `Aoc2k21.Tests`: Tests unitarios (xUnit) para cada implementación

## Reto 1

Hay dos implementaciones del reto: la primera (`Quiz1.GetDepthIncreases`) es una solución iterativa clásica, mientras que la segunda (`Quiz2.GetDepthIncreases_V2`) es más funcional y se basa en recorrer la colección de entrada en parejas de elementos (i, i+1) (siendo i el índice) y contar en cuantas de esas parejas se cumple que el segundo elemento sea mayor al primero.

En la segunda parte del reto nos piden que ahora hagamos ventanas de tres valores, es decir que obtengamos todas las tuplas ternarias de los valores y por cada tupla sumemos sus valores y luego miremos cuantas veces se incrementa el valor. Es decir, cuantas veces se cumple que sum(i+1, i+2, i+3) > sum(i, i+1, i+2) siendo i el índice.

La solución es relativamente sencilla (`Quiz1b.GetDepthIncreasesByTriples`) y se trata de proyectar todas las tuplas ternarias en una colección con sus sumas y luego usar esa colección como entrada a la función que nos resolvía la primera parte del reto :)
