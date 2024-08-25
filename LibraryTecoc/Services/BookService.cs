using LibraryTecoc.Models;

namespace LibraryTecoc.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books = new List<Book>();
        private readonly List<Loan> _loans = new List<Loan>();


        public void AddBook(Book book)
        {
            _books.Add(book);
        }

        public void RemoveBook(int bookId)
        {
            var book = _books.FirstOrDefault(b => b.Id == bookId);
            if (book != null) _books.Remove(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Genre = book.Genre;
                existingBook.Status = book.Status;
            }
        }

        public Book GetBookById(int bookId)
        {
            return _books.FirstOrDefault(b => b.Id == bookId); 
        }

        public List<Book> SearchBooks(string query)
        {
            return _books.Where(b => b.Title.Contains(query) || b.Author.Contains(query) || b.Genre.Contains(query)).ToList();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }
    }
}
