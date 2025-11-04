using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab_8.Services
{
    internal class UserService
    {
        private static UserService instance;

        public static UserService Instance
        {
            get
            {
                if (instance == null) instance = new UserService();
                return instance;
            }
            private set { instance = value; }
        }

        private UserService() { }

        public User User;

        public async Task<(User, bool)> Login(string email, string password)
        {
            using (var context = new QuizDBContext())
            {
                User user = await context.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null) return (null, false);

                bool success = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (success) User = user;

                return (success ? user : null, success);
            }
        }
    }
}
