using Microsoft.EntityFrameworkCore;

using Quiz.API.Models;

namespace Quiz.API.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuestionModel>().
                ToTable("Questions").
                HasKey(q => q.QuestionID);

            modelBuilder.Entity<UserBaseModel>().
                ToTable("Users").
                HasKey(u => u.UserID);

            modelBuilder.Entity<QuestionSuggestionModel>().
                ToTable("Suggestions").
                HasKey(s => s.QuestionSuggestionID);

            modelBuilder.Entity<QuestionsStatusModel>().
                ToTable("QuestionsStatus").
                HasKey(q => q.ID);
        }

        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<UserBaseModel> Users { get; set; }
        public DbSet<QuestionSuggestionModel> Suggestions { get; set; }
        public DbSet<QuestionsStatusModel> QuestionsStatus { get; set; }
    }
}