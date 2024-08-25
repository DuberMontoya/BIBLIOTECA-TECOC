using LibraryTecoc.Models;

namespace LibraryTecoc.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>();

        public void RegisterUser(User user)
        {
            _users.Add(user);
        }

        public void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.IdentificationNumber = user.IdentificationNumber;
                existingUser.Address = user.Address;
            }
        }

        public User GetUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public List<Loan> GetLoanHistory(int userId)
        {
            var user = GetUserById(userId);
            return user?.LoanHistory ?? new List<Loan>();
        }
    }
}
