namespace LibraryTecoc.Services
{
    public interface ILoanService
    {
        void LoanBook(int bookId, int userId);
        void ReturnBook(int bookId);
        void NotifyOverdueLoans();
    }
}
