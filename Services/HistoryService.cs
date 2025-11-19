using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                var query = context.Histories.Where(h => h.QuizId == quizId && h.UserId == userId);

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

        public async Task SubmitQuizHistory(History history, List<Answer> checkedAnswers)
        {
            using (var context = new QuizDBContext())
            {
                var correctAnswers = await context.Answers
                    .Include(a => a.Question)
                    .Where(a => a.IsCorrect && a.Question.QuizId == history.QuizId)
                    .ToListAsync();

                var questions = await context.Questions
                    .Where(q => q.QuizId == history.QuizId)
                    .ToListAsync();

                int totalQuestions = questions.Count;
                int correctCount = 0;

                foreach (var question in questions)
                {
                    var correctAnswer = correctAnswers.FirstOrDefault(a => a.QuestionId == question.Id);
                    var userAnswer = checkedAnswers.FirstOrDefault(a => a.QuestionId == question.Id);

                    if (correctAnswer != null && userAnswer != null && correctAnswer.Id == userAnswer.Id)
                    {
                        correctCount++;
                    }
                }

                double totalScore = totalQuestions > 0
                    ? ((double)correctCount / totalQuestions) * 100
                    : 0;

                var currentHistory = await context.Histories.FindAsync(history.Id);
                if (currentHistory == null) return;

                currentHistory.TimeFinish = DateTime.Now;
                currentHistory.TotalScore = totalScore;
                currentHistory.IsFinish = true;

                await context.SaveChangesAsync();
            }
        }
    }
}
