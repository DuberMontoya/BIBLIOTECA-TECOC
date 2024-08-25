using LibraryTecoc.Models;
using LibraryTecoc.Reports;
using LibraryTecoc.Services;
using System;

namespace LibraryTecoc
{
    class Program
    {
        static void Main(string[] args)
        {
            // Inicialización de servicios
            var bookService = new BookService();
            var userService = new UserService();
            var loanService = new LoanService(bookService, userService);
            var reportService = new ReportService(bookService, userService, loanService);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== Biblioteca del TECOC ===");
                Console.WriteLine("1. Gestión de Libros");
                Console.WriteLine("2. Gestión de Préstamos");
                Console.WriteLine("3. Gestión de Usuarios");
                Console.WriteLine("4. Reportes y Consultas");
                Console.WriteLine("5. Notificaciones de Préstamos Vencidos");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        BookManagementMenu(bookService);
                        break;
                    case "2":
                        LoanManagementMenu(loanService);
                        break;
                    case "3":
                        UserManagementMenu(userService);
                        break;
                    case "4":
                        ReportMenu(reportService);
                        break;
                    case "5":
                        NotifyOverdueLoans(loanService);
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("Gracias por usar la Biblioteca del TECOC. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void BookManagementMenu(BookService bookService)
        {
            Console.WriteLine("=== Gestión de Libros ===");
            Console.WriteLine("1. Agregar un nuevo libro");
            Console.WriteLine("2. Eliminar un libro");
            Console.WriteLine("3. Actualizar la información de un libro");
            Console.WriteLine("4. Buscar libros");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Ingrese el título del libro: ");
                    string title = Console.ReadLine();
                    Console.Write("Ingrese el autor del libro: ");
                    string author = Console.ReadLine();
                    Console.Write("Ingrese el género del libro: ");
                    string genre = Console.ReadLine();

                    bookService.AddBook(new Book { Title = title, Author = author, Genre = genre });
                    Console.WriteLine("Libro agregado exitosamente.");
                    break;

                case "2":
                    Console.Write("Ingrese el ID del libro a eliminar: ");
                    int deleteBookId = int.Parse(Console.ReadLine());
                    bookService.RemoveBook(deleteBookId);
                    Console.WriteLine("Libro eliminado exitosamente.");
                    break;

                case "3":
                    Console.Write("Ingrese el ID del libro a actualizar: ");
                    int updateBookId = int.Parse(Console.ReadLine());
                    var bookToUpdate = bookService.GetBookById(updateBookId);
                    if (bookToUpdate != null)
                    {
                        Console.Write("Nuevo título (dejar en blanco para mantener actual): ");
                        string newTitle = Console.ReadLine();
                        Console.Write("Nuevo autor (dejar en blanco para mantener actual): ");
                        string newAuthor = Console.ReadLine();
                        Console.Write("Nuevo género (dejar en blanco para mantener actual): ");
                        string newGenre = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(newTitle)) bookToUpdate.Title = newTitle;
                        if (!string.IsNullOrWhiteSpace(newAuthor)) bookToUpdate.Author = newAuthor;
                        if (!string.IsNullOrWhiteSpace(newGenre)) bookToUpdate.Genre = newGenre;

                        bookService.UpdateBook(bookToUpdate);
                        Console.WriteLine("Libro actualizado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Libro no encontrado.");
                    }
                    break;

                case "4":
                    Console.Write("Ingrese el término de búsqueda (título, autor o género): ");
                    string searchTerm = Console.ReadLine();
                    var foundBooks = bookService.SearchBooks(searchTerm);
                    foreach (var book in foundBooks)
                    {
                        Console.WriteLine($"{book.Id} - {book.Title} by {book.Author}, Género: {book.Genre}, Estado: {book.Status}");
                    }
                    break;

                case "5":
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }

        static void LoanManagementMenu(LoanService loanService)
        {
            Console.WriteLine("=== Gestión de Préstamos ===");
            Console.WriteLine("1. Registrar un nuevo préstamo");
            Console.WriteLine("2. Registrar la devolución de un libro");
            Console.WriteLine("3. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Ingrese el ID del libro: ");
                    int bookId = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese el ID del usuario: ");
                    int userId = int.Parse(Console.ReadLine());

                    loanService.LoanBook(bookId, userId);
                    Console.WriteLine("Préstamo registrado exitosamente.");
                    break;

                case "2":
                    Console.Write("Ingrese el ID del libro a devolver: ");
                    int returnBookId = int.Parse(Console.ReadLine());
                    loanService.ReturnBook(returnBookId);
                    Console.WriteLine("Libro devuelto exitosamente.");
                    break;

                case "3":
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }

        static void UserManagementMenu(UserService userService)
        {
            Console.WriteLine("=== Gestión de Usuarios ===");
            Console.WriteLine("1. Registrar un nuevo usuario");
            Console.WriteLine("2. Actualizar la información de un usuario");
            Console.WriteLine("3. Consultar historial de préstamos");
            Console.WriteLine("4. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Ingrese el nombre del usuario: ");
                    string name = Console.ReadLine();
                    Console.Write("Ingrese el número de identificación: ");
                    string identification = Console.ReadLine();
                    Console.Write("Ingrese la dirección del usuario: ");
                    string address = Console.ReadLine();

                    userService.RegisterUser(new User { Name = name, IdentificationNumber = identification, Address = address });
                    Console.WriteLine("Usuario registrado exitosamente.");
                    break;

                case "2":
                    Console.Write("Ingrese el ID del usuario a actualizar: ");
                    int updateUserId = int.Parse(Console.ReadLine());
                    var userToUpdate = userService.GetUserById(updateUserId);
                    if (userToUpdate != null)
                    {
                        Console.Write("Nuevo nombre (dejar en blanco para mantener actual): ");
                        string newName = Console.ReadLine();
                        Console.Write("Nueva identificación (dejar en blanco para mantener actual): ");
                        string newIdentification = Console.ReadLine();
                        Console.Write("Nueva dirección (dejar en blanco para mantener actual): ");
                        string newAddress = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(newName)) userToUpdate.Name = newName;
                        if (!string.IsNullOrWhiteSpace(newIdentification)) userToUpdate.IdentificationNumber = newIdentification;
                        if (!string.IsNullOrWhiteSpace(newAddress)) userToUpdate.Address = newAddress;

                        userService.UpdateUser(userToUpdate);
                        Console.WriteLine("Usuario actualizado exitosamente.");
                    }
                    else
                    {
                        Console.WriteLine("Usuario no encontrado.");
                    }
                    break;

                case "3":
                    Console.Write("Ingrese el ID del usuario: ");
                    int userId = int.Parse(Console.ReadLine());
                    var loanHistory = userService.GetLoanHistory(userId);
                    foreach (var loan in loanHistory)
                    {
                        Console.WriteLine($"Préstamo ID: {loan.LoanId}, Libro: {loan.BookId}, Fecha de préstamo: {loan.LoanDate}, Fecha de devolución: {loan.ReturnDate?.ToString() ?? "No devuelto"}");
                    }
                    break;

                case "4":
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }

        static void ReportMenu(ReportService reportService)
        {
            Console.WriteLine("=== Reportes y Consultas ===");
            Console.WriteLine("1. Libros más prestados");
            Console.WriteLine("2. Libros vencidos");
            Console.WriteLine("3. Estado actual de la biblioteca");
            Console.WriteLine("4. Búsqueda de libros");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    reportService.GenerateMostLoanedBooksReport();
                    break;

                case "2":
                    reportService.GenerateOverdueBooksReport();
                    break;

                case "3":
                    reportService.GenerateLibraryStatusReport();
                    break;

                case "4":
                    Console.Write("Ingrese el término de búsqueda (título, autor o género): ");
                    string searchTerm = Console.ReadLine();
                    reportService.SearchBooks(searchTerm);
                    break;

                case "5":
                    break;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }

        static void NotifyOverdueLoans(LoanService loanService)
        {
            Console.WriteLine("=== Notificaciones de Préstamos Vencidos ===");
            var overdueLoans = loanService.GetOverdueLoans();

            if (overdueLoans.Count() > 0)
            {
                Console.WriteLine("Préstamos vencidos:");
                foreach (var loan in overdueLoans)
                {
                    Console.WriteLine($"Préstamo ID: {loan.LoanId}, Libro: {loan.BookId}, Usuario: {loan.UserId}, Fecha de vencimiento: {loan.DueDate}");
                }
            }
            else
            {
                Console.WriteLine("No hay préstamos vencidos.");
            }
        }
    }
}