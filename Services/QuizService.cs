using Lab_8.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using WinFormApp.DTO;
using Microsoft.EntityFrameworkCore;

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
    }
}
