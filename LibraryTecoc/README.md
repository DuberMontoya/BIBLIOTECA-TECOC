# Gestión de Préstamos de Libros en la Biblioteca del TECOC

## Principios SOLID
- **S**ingle Responsibility Principle: Cada clase en este proyecto tiene una única responsabilidad. Por ejemplo, `BookService` se encarga únicamente de la gestión de libros.
- **O**pen/Closed Principle: Las clases están abiertas a la extensión mediante interfaces, pero cerradas a la modificación directa.
- **L**iskov Substitution Principle: Se pueden usar las clases derivadas sin alterar el comportamiento del sistema.
- **I**nterface Segregation Principle: Se han creado interfaces separadas para gestionar libros, usuarios y préstamos.
- **D**ependency Inversion Principle: Las clases de alto nivel dependen de abstracciones (interfaces) en lugar de implementaciones concretas.

## Propósito del Proyecto
Este proyecto permite a los bibliotecarios gestionar de manera eficiente los préstamos y devoluciones de libros
