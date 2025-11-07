using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<History>> GetListHistoryByQuizIdAndUserId(int quizId, int userId)
        {
            using (var context = new QuizDBContext())
            {
                return await context.Histories
                    .Where(h => h.QuizId == quizId && h.UserId == userId)
                    .ToListAsync();
            }
        }
    }
}
