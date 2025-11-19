using Lab_8.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_8.Services
{
    internal class QuestionService
    {
        private static QuestionService instance;

        public static QuestionService Instance
        {
            get
            {
                if (instance == null) instance = new QuestionService();
                return instance;
            }
            private set { instance = value; }
        }

        private QuestionService() { }

        public async Task<IEnumerable<Question>> GetListQuestionByQuiz(int quizId)
        {
            using (var context = new QuizDBContext())
            {
                return await context.Questions
                    .Where(q => q.QuizId == quizId)
                    .Include(q => q.Answers)
                    .ToListAsync();
            }
        }

        public async Task UpsertQuestionAnswer(List<Question> questions, int quizId)
        {
            using (var context = new QuizDBContext())
            {
                var questionsInDb = await context.Questions
                    .Where(q => q.QuizId == quizId)
                    .Include(q => q.Answers)
                    .ToListAsync();

                var newQuestions = questions
                    .Where(q => q.Id == 0)
                    .ToList();

                var deletedQuestions = questionsInDb
                    .Where(dbQ => !questions.Any(q => q.Id == dbQ.Id))
                    .ToList();

                var existingQuestions = questions
                   .Where(q => q.Id != 0 && questionsInDb.Any(dbQ => dbQ.Id == q.Id))
                   .ToList();

                //Add
                if (newQuestions.Any()) context.Questions.AddRange(newQuestions);            

                //Delete
                if (deletedQuestions.Any()) context.Questions.RemoveRange(deletedQuestions);

                //Update
                existingQuestions.ForEach(q =>
                {
                    var dbQuestion = questionsInDb.First(dbQ => dbQ.Id == q.Id);

                    // Update question fields
                    dbQuestion.Name = q.Name;
                    dbQuestion.Image = q.Image;
                    dbQuestion.Audio = q.Audio;

                    // --- Handle Answers ---
                    // 1. New answers to add
                    var newAnswers = q.Answers.Where(a => a.Id == 0).ToList();
                    foreach (var a in newAnswers)
                    {
                        a.QuestionId = dbQuestion.Id; 
                        context.Answers.Add(a);
                    }

                    // 2. Answers to update
                    var answersToUpdate = q.Answers
                        .Where(a => a.Id != 0 && dbQuestion.Answers.Any(dbA => dbA.Id == a.Id))
                        .ToList();

                    foreach (var a in answersToUpdate)
                    {
                        var dbAnswer = dbQuestion.Answers.First(dbA => dbA.Id == a.Id);
                        dbAnswer.Name = a.Name;
                        dbAnswer.IsCorrect = a.IsCorrect;
                    }

                    // 3. Answers to delete
                    var answersToDelete = dbQuestion.Answers
                        .Where(dbA => !q.Answers.Any(a => a.Id == dbA.Id))
                        .ToList();

                    if (answersToDelete.Any())
                        context.Answers.RemoveRange(answersToDelete);
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
