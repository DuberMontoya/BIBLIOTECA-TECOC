using LibraryTecoc.Models;

namespace LibraryTecoc.Services
{
    public interface IUserService
    {
        void RegisterUser(User user);
        void UpdateUser(User user);
        User GetUserById(int userId);
        List<Loan> GetLoanHistory(int userId);
    }
}
