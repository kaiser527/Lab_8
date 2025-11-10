using Lab_8.DTO;
using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null) return (null, false);

                bool success = BCrypt.Net.BCrypt.Verify(password, user.Password);

                if (success) User = user;

                return (success ? user : null, success);
            }
        }

        public async Task<(bool, User)> UpdateUserProfile(UpdateUserProfile updateUserProfile)
        {
            using (var context = new QuizDBContext())
            {
                bool isClose = true;

                User user = await context.Users.FirstOrDefaultAsync(a => a.Id == User.Id);

                if (user == null)
                {
                    MessageBox.Show("User is not exists", "Update failed");
                    isClose = false;
                }

                bool success = BCrypt.Net.BCrypt.Verify(updateUserProfile.Password, user.Password);

                if (!success)
                {
                    MessageBox.Show("Password is incorrect", "Update failed");
                    isClose = false;
                }

                if (updateUserProfile.ConfirmPassword != updateUserProfile.NewPassword)
                {
                    MessageBox.Show("Password and confirm password not match", "Update failed");
                    isClose = false;
                }

                if (isClose)
                {
                    user.Email = updateUserProfile.Email;
                    user.Name = updateUserProfile.Name;
                    user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserProfile.ConfirmPassword);
                    user.Image = updateUserProfile.Image;

                    await context.SaveChangesAsync();
                }

                return (isClose, user);
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

        public async Task SaveUserAnswerEachCheck(UserAnswer userAnswer)
        {
            using (var context = new QuizDBContext())
            {
                // Get the QuestionId for the selected AnswerId
                var questionId = await context.Answers
                    .Where(a => a.Id == userAnswer.AnswerId)
                    .Select(a => a.QuestionId)
                    .FirstOrDefaultAsync();

                // Find existing UserAnswer for this user, history, and question
                var existing = await context.UserAnswers
                    .Include(u => u.Answer)
                    .FirstOrDefaultAsync(u =>
                        u.UserId == userAnswer.UserId &&
                        u.HistoryId == userAnswer.HistoryId &&
                        u.Answer.QuestionId == questionId
                    );

                if (existing != null)
                {
                    // Delete old UserAnswer before inserting new one
                    context.UserAnswers.Remove(existing);
                    await context.SaveChangesAsync(); // save deletion first
                }

                // Add new UserAnswer
                context.UserAnswers.Add(new UserAnswer
                {
                    UserId = userAnswer.UserId,
                    HistoryId = userAnswer.HistoryId,
                    AnswerId = userAnswer.AnswerId
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<List<UserAnswer>> GetUserAnswersByHistory(int historyId)
        {
            using (var context = new QuizDBContext())
            {
                var answers = await context.UserAnswers
                    .Include(ua => ua.Answer)
                        .ThenInclude(a => a.Question)
                    .Where(ua => ua.HistoryId == historyId)
                    .ToListAsync();

                return answers;
            }
        }
    }
}
