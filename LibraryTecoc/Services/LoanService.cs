using LibraryTecoc.Models;

namespace LibraryTecoc.Services
{
    public class LoanService : ILoanService
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;
        private readonly List<Loan> _loans = new List<Loan>();

        public LoanService(IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        public void LoanBook(int bookId, int userId)
        {
            var book = _bookService.GetBookById(bookId);
            var user = _userService.GetUserById(userId);

            if (book != null && user != null && book.Status == BookStatus.Available)
            {
                var loan = new Loan
                {
                    LoanId = _loans.Count + 1,
                    BookId = bookId,
                    UserId = userId,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14)
                };

                _loans.Add(loan);
                user.LoanHistory.Add(loan);
                book.Status = BookStatus.Loaned;
            }
        }

        public void ReturnBook(int bookId)
        {
            var loan = _loans.FirstOrDefault(l => l.BookId == bookId && l.ReturnDate == null);
            var book = _bookService.GetBookById(bookId);

            if (loan != null && book != null)
            {
                loan.ReturnDate = DateTime.Now;
                book.Status = BookStatus.Available;
            }
        }

        public void NotifyOverdueLoans()
        {
            var overdueLoans = _loans.Where(l => l.DueDate < DateTime.Now && l.ReturnDate == null);
            foreach (var loan in overdueLoans)
            {
                var user = _userService.GetUserById(loan.UserId);
                Console.WriteLine($"Loan ID: {loan.LoanId}, Book ID: {loan.BookId} is overdue. User: {user.Name}");
            }
        }

        public IEnumerable<Loan> GetOverdueLoans()
        {
            foreach (var loan in _loans)
            {
                Console.WriteLine($"LoanId: {loan.LoanId}, DueDate: {loan.DueDate}, ReturnDate: {loan.ReturnDate}");
            }


            return _loans.Where(l => l.DueDate < DateTime.Now && l.ReturnDate == null);

        }

        public IEnumerable<Book> GetMostLoanedBooks()
        {
            var mostLoanedBooks = _loans
                .GroupBy(l => l.BookId)
                .Select(g => new
                {
                    Book = _bookService.GetBookById(g.Key),
                    LoanCount = g.Count()
                })
                .OrderByDescending(bg => bg.LoanCount)
                .Take(5)
                .Select(bg => new Book
                {
                    Id = bg.Book.Id,
                    Title = bg.Book.Title,
                    Author = bg.Book.Author,
                    Genre = bg.Book.Genre,
                    Status = bg.Book.Status,
                    LoanCount = bg.LoanCount
                });

            return mostLoanedBooks;
        }
    }
}
