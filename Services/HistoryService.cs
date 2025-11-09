using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task CreateUserHistory(History history)
        {
            using (var context = new QuizDBContext())
            {
                context.Histories.Add(history); 
                
                await context.SaveChangesAsync();
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
