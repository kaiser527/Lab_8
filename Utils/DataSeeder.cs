using Lab_8.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab_8.Utils
{
    internal class DataSeeder
    {
        public static void Seed(QuizDBContext context)
        {
            // Ensure database created
            context.Database.EnsureCreated();

            // Stop if already seeded
            if (context.Users.Any())
                return;

            // Path to images folder
            string basePath = Path.Combine(Application.StartupPath, "Image");

            // Paths to user & quiz images
            string userImgPath = Path.Combine(basePath, "User");
            string quizImgPath = Path.Combine(basePath, "Quiz");

            // ===== USERS =====
            var admin = new User
            {
                Name = "Admin",
                Email = "admin@test.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                Image = File.ReadAllBytes(Path.Combine(userImgPath, "admin.png"))
            };

            var john = new User
            {
                Name = "John Doe",
                Email = "john@test.com",
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                Image = File.ReadAllBytes(Path.Combine(userImgPath, "user.png"))
            };

            context.Users.AddRange(admin, john);
            context.SaveChanges();

            // ===== QUIZ =====
            var quiz = new Quiz
            {
                Name = "General Knowledge",
                Difficulty = "Easy",
                Image = File.ReadAllBytes(Path.Combine(quizImgPath, "general.jpg"))
            };

            context.Quizzes.Add(quiz);
            context.SaveChanges();

            // ===== QUESTIONS + ANSWERS =====
            var questions = new List<Question>
            {
                new Question
                {
                    Name = "What is the capital of France?",
                    QuizId = quiz.Id,

                    Answers = new List<Answer>
                    {
                        new Answer { Name = "Paris", IsCorrect = true },
                        new Answer { Name = "London", IsCorrect = false },
                        new Answer { Name = "Madrid", IsCorrect = false }
                    }
                },
                new Question
                {
                    Name = "5 + 3 = ?",
                    QuizId = quiz.Id,
                    Answers = new List<Answer>
                    {
                        new Answer { Name = "7", IsCorrect = false },
                        new Answer { Name = "8", IsCorrect = true },
                        new Answer { Name = "9", IsCorrect = false }
                    }
                }
            };

            context.Questions.AddRange(questions);
            context.SaveChanges();

            // ===== HISTORY (John completes quiz) =====
            var history = new History
            {
                UserId = john.Id,
                QuizId = quiz.Id,
                IsFinish = true,
                TimeStart = DateTime.Now.AddMinutes(-5),
                TimeFinish = DateTime.Now,
                TotalScore = 100,
                Image = null
            };

            context.Histories.Add(history);
            context.SaveChanges();

            // ===== USER ANSWERS (John selected correct answers) =====
            var allAnswers = context.Answers.ToList();

            var userAnswers = new List<UserAnswer>
            {
                new UserAnswer
                {
                    UserId = john.Id,
                    AnswerId = allAnswers.First(a => a.Name == "Paris").Id,
                    HistoryId = history.Id
                },
                new UserAnswer
                {
                    UserId = john.Id,
                    AnswerId = allAnswers.First(a => a.Name == "8").Id,
                    HistoryId = history.Id
                }
            };

            context.UserAnswers.AddRange(userAnswers);
            context.SaveChanges();
        }
    }
}
