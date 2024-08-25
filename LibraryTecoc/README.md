# Gesti�n de Pr�stamos de Libros en la Biblioteca del TECOC

## Principios SOLID
- **S**ingle Responsibility Principle: Cada clase en este proyecto tiene una �nica responsabilidad. Por ejemplo, `BookService` se encarga �nicamente de la gesti�n de libros.
- **O**pen/Closed Principle: Las clases est�n abiertas a la extensi�n mediante interfaces, pero cerradas a la modificaci�n directa.
- **L**iskov Substitution Principle: Se pueden usar las clases derivadas sin alterar el comportamiento del sistema.
- **I**nterface Segregation Principle: Se han creado interfaces separadas para gestionar libros, usuarios y pr�stamos.
- **D**ependency Inversion Principle: Las clases de alto nivel dependen de abstracciones (interfaces) en lugar de implementaciones concretas.

## Prop�sito del Proyecto
Este proyecto permite a los bibliotecarios gestionar de manera eficiente los pr�stamos y devoluciones de libros
