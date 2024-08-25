using LibraryTecoc.Services;

namespace LibraryTecoc.Reports
{
    public class ReportService
    {
        private readonly BookService _bookService;
        private readonly UserService _userService;
        private readonly LoanService _loanService;

        public ReportService(BookService bookService, UserService userService, LoanService loanService)
        {
            _bookService = bookService;
            _userService = userService;
            _loanService = loanService;
        }

        public void GenerateMostLoanedBooksReport()
        {
            Console.WriteLine("=== Reporte de Libros más Prestados ===");
            var mostLoanedBooks = _loanService.GetMostLoanedBooks();
            foreach (var book in mostLoanedBooks)
            {
                Console.WriteLine($"{book.Title} - {book.Author}, Género: {book.Genre}, Préstamos: {book.LoanCount}");
            }
        }

        public void GenerateOverdueBooksReport()
        {
            Console.WriteLine("=== Reporte de Libros Vencidos ===");
            var overdueBooks = _loanService.GetOverdueLoans();
            foreach (var loan in overdueBooks)
            {
                Console.WriteLine($"Libro: {loan.BookId}, Usuario: {loan.UserId}, Fecha de vencimiento: {loan.DueDate}");
            }
        }

        public void GenerateLibraryStatusReport()
        {
            Console.WriteLine("=== Estado Actual de la Biblioteca ===");
            var books = _bookService.GetAllBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} by {book.Author} - {book.Genre}, Estado: {book.Status}");
            }
        }

        public void SearchBooks(string searchTerm)
        {
            var foundBooks = _bookService.SearchBooks(searchTerm);
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"{book.Id} - {book.Title} by {book.Author}, Género: {book.Genre}, Estado: {book.Status}");
            }
        }
    }
}
