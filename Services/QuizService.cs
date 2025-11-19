using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.DTO;
using WinFormApp.Forms;

namespace Lab_8.Services
{
    internal class QuizService
    {
        private static QuizService instance;

        public static QuizService Instance
        {
            get
            {
                if (instance == null) instance = new QuizService();
                return instance;
            }
            private set { instance = value; }
        }

        private QuizService() { }


        public async Task<PaginatedResult<Quiz>> GetListQuiz(
            int pageSize = 100,
            int pageNumber = 1,
            string name = null)
        {
            using (var context = new QuizDBContext())
            {
                var query = context.Quizzes
                    .Include(q => q.Category)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(a =>
                        a.Name.ToLower().Contains(name.ToLower()) ||
                        a.Category.Name.ToLower().Contains(name.ToLower()) ||
                        a.Difficulty.ToLower().Contains(name.ToLower())
                    );
                }

                int totalCount = await query.CountAsync();
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var items = await query
                    .OrderBy(q => q.Id)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PaginatedResult<Quiz>
                {
                    Items = items,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };
            }
        }

        public async Task<Quiz> GetQuizById(int quizId)
        {
            using (var context = new QuizDBContext())
            {
                Quiz existingQuiz = await context.Quizzes
                    .Include(q => q.Questions)
                        .ThenInclude(q => q.Answers)  
                    .FirstOrDefaultAsync(q => q.Id == quizId);

                if (existingQuiz == null)
                {
                    Alert.ShowAlert("Quiz is not exists", Alert.AlertType.Error);
                    return null;
                }

                return existingQuiz;    
            }
        }

        public async Task CreateQuiz(Quiz quiz)
        {
            using (var context = new QuizDBContext())
            {
                bool isExist = await context.Quizzes.AnyAsync(q => q.Name == quiz.Name);

                if (isExist)
                {
                    Alert.ShowAlert("Quiz is already exists", Alert.AlertType.Error);
                    return;
                }

                context.Quizzes.Add(quiz);

                await context.SaveChangesAsync();   
            }
        }

        public async Task UpdateQuiz(Quiz quiz)
        {
            using (var context = new QuizDBContext())
            {
                Quiz existingQuiz = await context.Quizzes.FindAsync(quiz.Id);

                if (existingQuiz == null)
                {
                    Alert.ShowAlert("Quiz is not exists", Alert.AlertType.Error);
                    return;
                }

                bool isExist = await context.Quizzes.AnyAsync(q => q.Name == quiz.Name && q.Id != quiz.Id);

                if (isExist)
                {
                    Alert.ShowAlert("Quiz is already exists", Alert.AlertType.Error);
                    return;
                }

                existingQuiz.Name = quiz.Name;
                existingQuiz.Difficulty = quiz.Difficulty;
                existingQuiz.Image = quiz.Image;
                existingQuiz.CategoryId = quiz.CategoryId;  

                await context.SaveChangesAsync();   
            }
        }

        public async Task DeleteQuiz(int quizId)
        {
            using (var context = new QuizDBContext())
            {
                Quiz existingQuiz = await context.Quizzes.FindAsync(quizId);

                if (existingQuiz == null)
                {
                    Alert.ShowAlert("Quiz is not exists", Alert.AlertType.Error);
                    return;
                }

                var histories = await context.Histories
                    .Where(h => h.QuizId == quizId)
                    .Include(h => h.UserAnswers)
                    .ToListAsync();

                context.UserAnswers.RemoveRange(histories.SelectMany(h => h.UserAnswers));
                context.Histories.RemoveRange(histories);

                context.Quizzes.Remove(existingQuiz);

                await context.SaveChangesAsync();
            }
        }
    }
}
