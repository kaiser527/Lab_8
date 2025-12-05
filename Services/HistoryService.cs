using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WinFormApp.DTO;

namespace Lab_8.Services
{
    internal class HistoryService
    {
        private static HistoryService instance;

        public static HistoryService Instance
        {
            get
            {
                if (instance == null) instance = new HistoryService();
                return instance;
            }
            private set { instance = value; }
        }

        private HistoryService() { }

        public async Task<PaginatedResult<History>> GetListHistoryByQuizIdAndUserId(
            int quizId,
            int userId,
            int pageSize = 100,
            int pageNumber = 1,
            DateTime? timeStart = null,
            DateTime? timeFinish = null
        )
        {
            using (var context = new QuizDBContext())
            {
                var query = context.Histories
                    .Include(h => h.Quiz)
                        .ThenInclude(q => q.Category)
                    .Where(h => h.QuizId == quizId && h.UserId == userId);

                if (timeStart.HasValue)
                {
                    query = query.Where(h => h.TimeFinish >= timeStart.Value);
                }

                if (timeFinish.HasValue)
                {
                    query = query.Where(h => h.TimeStart <= timeFinish.Value);
                }

                int totalCount = await query.CountAsync(); 
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var items = await query
                    .OrderByDescending(h => h.IsFinish ? h.TimeFinish : h.TimeStart)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return new PaginatedResult<History>
                {
                    Items = items,
                    TotalCount = totalCount,
                    TotalPages = totalPages
                };
            }
        }

        public async Task CreateUserHistory(History history)
        {
            using (var context = new QuizDBContext())
            {
                context.Histories.Add(history); 
                
                await context.SaveChangesAsync();
            }
        }

        public async Task<int> GetFirstHistoryId()
        {
            using (var context = new QuizDBContext())
            {
                return (await context.Histories.FirstAsync()).Id;    
            }
        }

        public async Task SubmitQuizHistory(History history)
        {
            using (var context = new QuizDBContext())
            {
                var currentHistory = await context.Histories.FindAsync(history.Id);
                if (currentHistory == null) return;

                currentHistory.TimeFinish = DateTime.Now;
                currentHistory.IsFinish = true;

                await context.SaveChangesAsync();
            }
        }

    }
}

