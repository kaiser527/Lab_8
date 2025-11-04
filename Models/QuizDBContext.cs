using Microsoft.EntityFrameworkCore;

namespace Lab_8.Models
{
    public class QuizDBContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"
                    Data Source=MSI\SQLEXPRESS;
                    Initial Catalog=ManageQuiz;
                    Integrated Security=True;
                    Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // UserAnswer composite key
            modelBuilder.Entity<UserAnswer>()
                .HasKey(ua => new { ua.UserId, ua.AnswerId, ua.HistoryId });

            // UserAnswer -> User
            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAnswers)
                .HasForeignKey(ua => ua.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserAnswer -> Answer
            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.Answer)
                .WithMany()
                .HasForeignKey(ua => ua.AnswerId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserAnswer -> History
            modelBuilder.Entity<UserAnswer>()
                .HasOne(ua => ua.History)
                .WithMany(h => h.UserAnswers)
                .HasForeignKey(ua => ua.HistoryId)
                .OnDelete(DeleteBehavior.NoAction);

            // Quiz -> Questions
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            // Quiz -> Histories
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Histories)
                .WithOne(h => h.Quiz)
                .HasForeignKey(h => h.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            // Question -> Answers
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // User -> Histories
            modelBuilder.Entity<User>()
                .HasMany(u => u.Histories)
                .WithOne(h => h.User)
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
