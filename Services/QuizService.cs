using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormApp.DTO;

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
                var query = context.Quizzes.AsQueryable();

                if (!string.IsNullOrEmpty(name))
                {
                    query = query.Where(a =>
                        a.Name.ToLower().Contains(name.ToLower())
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

        public async Task CreateQuiz(Quiz quiz)
        {
            using (var context = new QuizDBContext())
            {
                bool isExist = await context.Quizzes.AnyAsync(q => q.Name == quiz.Name);

                if (isExist)
                {
                    MessageBox.Show("Quiz is already exists", "Create failed");
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
                    MessageBox.Show("Quiz is not exists", "Update failed");
                    return;
                }

                bool isExist = await context.Quizzes.AnyAsync(q => q.Name == quiz.Name && q.Id != quiz.Id);

                if (isExist)
                {
                    MessageBox.Show("Quiz is already exists", "Update failed");
                    return;
                }

                existingQuiz.Name = quiz.Name;
                existingQuiz.Difficulty = quiz.Difficulty;
                existingQuiz.Image = quiz.Image;

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
                    MessageBox.Show("Quiz is not exists", "Update failed");
                    return;
                }

                context.Quizzes.Remove(existingQuiz);

                await context.SaveChangesAsync();
            }
        }
    }
}
