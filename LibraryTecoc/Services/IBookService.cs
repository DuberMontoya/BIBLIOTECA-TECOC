using LibraryTecoc.Models;

namespace LibraryTecoc.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        void RemoveBook(int bookId);
        void UpdateBook(Book book);
        Book GetBookById(int bookId);
        List<Book> SearchBooks(string query);
    }
}
