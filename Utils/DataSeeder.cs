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
            // Ensure DB exists
            context.Database.EnsureCreated();


            //=========================================================
            //                      PERMISSIONS
            //=========================================================
            if (!context.Permissions.Any())
            {
                var permissions = new List<Permission>
                {
                    new Permission { Name = "Create User", Module = "User" },
                    new Permission { Name = "Update User", Module = "User" },
                    new Permission { Name = "Delete User", Module = "User" },
                    new Permission { Name = "View User", Module = "User" },

                    new Permission { Name = "Create Quiz", Module = "Quiz" },
                    new Permission { Name = "Update Quiz", Module = "Quiz" },
                    new Permission { Name = "Delete Quiz", Module = "Quiz" },
                    new Permission { Name = "View Quiz", Module = "Quiz" },

                    new Permission { Name = "Create Category", Module = "Category" },
                    new Permission { Name = "Update Category", Module = "Category" },
                    new Permission { Name = "Delete Category", Module = "Category" },
                    new Permission { Name = "View Category", Module = "Category" },

                    new Permission { Name = "Upsert Question Answer", Module = "Question" },

                    new Permission { Name = "Create Role", Module = "Role" },
                    new Permission { Name = "Update Role", Module = "Role" },
                    new Permission { Name = "Delete Role", Module = "Role" },
                    new Permission { Name = "View Role", Module = "Role" },

                    new Permission { Name = "Create Permission", Module = "Permission" },
                    new Permission { Name = "Update Permission", Module = "Permission" },
                    new Permission { Name = "Delete Permission", Module = "Permission" },
                    new Permission { Name = "View Permission", Module = "Permission" },
                };

                context.Permissions.AddRange(permissions);
                context.SaveChanges();   // IMPORTANT: generate IDs
            }

            var allPermissions = context.Permissions.ToList();


            //=========================================================
            //                          ROLES
            //=========================================================
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(new[]
                {
                    new Role { Name = "Admin", IsActive = true },
                    new Role { Name = "User", IsActive = true },
                    new Role { Name = "Tester", IsActive = true }
                });

                context.SaveChanges();
            }

            var adminRole = context.Roles.First(r => r.Name == "Admin");
            var userRole = context.Roles.First(r => r.Name == "User");
            var testerRole = context.Roles.First(r => r.Name == "Tester");


            //=========================================================
            //                     ROLE PERMISSIONS
            //=========================================================
            if (!context.RolePermissions.Any())
            {
                var rolePermissions = new List<RolePermission>();

                // Admin → ALL permissions
                rolePermissions.AddRange(
                    allPermissions.Select(p =>
                        new RolePermission { RoleId = adminRole.Id, PermissionId = p.Id }
                    )
                );

                // Tester → first 13 permissions
                rolePermissions.AddRange(
                    allPermissions.Take(13).Select(p =>
                        new RolePermission { RoleId = testerRole.Id, PermissionId = p.Id }
                    )
                );

                // User → View Quiz + View Category
                rolePermissions.Add(new RolePermission
                {
                    RoleId = userRole.Id,
                    PermissionId = allPermissions.First(p => p.Name == "View Quiz").Id
                });

                rolePermissions.Add(new RolePermission
                {
                    RoleId = userRole.Id,
                    PermissionId = allPermissions.First(p => p.Name == "View Category").Id
                });

                context.RolePermissions.AddRange(rolePermissions);
                context.SaveChanges();
            }


            //=========================================================
            //                         CATEGORIES
            //=========================================================
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Listening", IsActive = true },
                    new Category { Name = "Grammar", IsActive = true },
                    new Category { Name = "Vocabulary", IsActive = true },
                    new Category { Name = "Reading", IsActive = true },
                    new Category { Name = "General", IsActive = true }
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            var generalCategory = context.Categories.First(c => c.Name == "General");


            //=========================================================
            //                         USERS
            //=========================================================
            string basePath = Path.Combine(Application.StartupPath, "Image");
            string userImg = Path.Combine(basePath, "User");

            if (!context.Users.Any())
            {
                var admin = new User
                {
                    Name = "Admin",
                    Email = "admin@test.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Image = File.ReadAllBytes(Path.Combine(userImg, "admin.png")),
                    RoleId = adminRole.Id
                };

                var john = new User
                {
                    Name = "John Doe",
                    Email = "john@test.com",
                    Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                    Image = File.ReadAllBytes(Path.Combine(userImg, "user.png")),
                    RoleId = userRole.Id
                };

                context.Users.AddRange(admin, john);
                context.SaveChanges();
            }

            var johnUser = context.Users.First(u => u.Email == "john@test.com");


            //=========================================================
            //                           QUIZ
            //=========================================================
            string quizImg = Path.Combine(basePath, "Quiz");

            Quiz quiz;
            if (!context.Quizzes.Any())
            {
                quiz = new Quiz
                {
                    Name = "English Basics Quiz",
                    Difficulty = "Easy",
                    Image = File.ReadAllBytes(Path.Combine(quizImg, "general.jpg")),
                    CategoryId = generalCategory.Id
                };

                context.Quizzes.Add(quiz);
                context.SaveChanges();
            }
            else
            {
                quiz = context.Quizzes.First();
            }


            //=========================================================
            //                QUESTIONS & ANSWERS
            //=========================================================
            if (!context.Questions.Any())
            {
                var questions = new List<Question>
                {
                    new Question
                    {
                        Name = "Select the correct plural form of 'child'.",
                        QuizId = quiz.Id,
                        Answers = new List<Answer>
                        {
                            new Answer { Name = "Childs", IsCorrect = false },
                            new Answer { Name = "Children", IsCorrect = true },
                            new Answer { Name = "Childes", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Name = "Which word is a synonym of 'happy'?",
                        QuizId = quiz.Id,
                        Answers = new List<Answer>
                        {
                            new Answer { Name = "Sad", IsCorrect = false },
                            new Answer { Name = "Joyful", IsCorrect = true },
                            new Answer { Name = "Angry", IsCorrect = false },
                        }
                    },
                    new Question
                    {
                        Name = "Choose the correct sentence:",
                        QuizId = quiz.Id,
                        Answers = new List<Answer>
                        {
                            new Answer { Name = "She don't like apples.", IsCorrect = false },
                            new Answer { Name = "She doesn't like apples.", IsCorrect = true },
                            new Answer { Name = "She not like apples.", IsCorrect = false },
                        }
                    }
                };

                context.Questions.AddRange(questions);
                context.SaveChanges();
            }

            var historyExists = context.Histories.Any();
            var answers = context.Answers.ToList();


            //=========================================================
            //                         HISTORY
            //=========================================================
            if (!historyExists)
            {
                var history = new History
                {
                    UserId = johnUser.Id,
                    QuizId = quiz.Id,
                    IsFinish = true,
                    TimeStart = DateTime.Now.AddMinutes(-5),
                    TimeFinish = DateTime.Now,
                    TotalScore = 33.33
                };

                context.Histories.Add(history);
                context.SaveChanges();

                // USER ANSWERS
                var userAnswers = new List<UserAnswer>
                {
                    new UserAnswer
                    {
                        UserId = johnUser.Id,
                        AnswerId = answers.First(a => a.Name == "Sad").Id,
                        HistoryId = history.Id
                    },
                    new UserAnswer
                    {
                        UserId = johnUser.Id,
                        AnswerId = answers.First(a => a.Name == "She doesn't like apples.").Id,
                        HistoryId = history.Id
                    }
                };

                context.UserAnswers.AddRange(userAnswers);
                context.SaveChanges();
            }
        }
    }
}
