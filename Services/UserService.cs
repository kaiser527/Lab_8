using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.DTO;

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
                User user = await context.Users
                    .Include(u => u.Histories)
                        .ThenInclude(u => u.Quiz)
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null) return (null, false);

                bool success = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (success) User = user;

                return (success ? user : null, success);
            }
        }

        public async Task<PaginatedResult<User>> GetListUser(
            int pageSize = 100,
            int pageNumber = 1,
            string name = null)
        {
            using (var context = new QuizDBContext())
            {
                var query = context.Users.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(a =>
                        a.Name.ToLower().Contains(name.ToLower()) ||
                        a.Email.ToLower().Contains(name.ToLower())
                    );
                }

                int totalCount = await query.CountAsync();
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var items = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PaginatedResult<User>
                {
                    Items = items,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };
            }
        }

        public async Task CreateUser(User user)
        {
            using (var context = new QuizDBContext())
            {
                bool isExist = await context.Users.AnyAsync(u => u.Email == user.Email);

                if (isExist)
                {
                    MessageBox.Show("User already exists", "Create failed");
                    return;
                }

                context.Users.Add(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateUser(User user)
        {
            using (var context = new QuizDBContext())
            {
                var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);

                if (existingUser == null)
                {
                    MessageBox.Show("User not found", "Update failed");
                    return;
                }

                existingUser.Name = user.Name;

                if (user.Image != null)
                    existingUser.Image = user.Image;

                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int id)
        {
            using (var context = new QuizDBContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    MessageBox.Show("User not found", "Delete failed");
                    return;
                }

                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
