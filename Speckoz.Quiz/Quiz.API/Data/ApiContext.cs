using Microsoft.EntityFrameworkCore;
using Quiz.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            modelBuilder.Entity<QuestionModel>().ToTable("Questions").HasKey(q => q.QuestionID);

            modelBuilder.Entity<UserBaseModel>().ToTable("Users").HasKey(u => u.UserID);

            modelBuilder.Entity<QuestionSuggestionModel>().ToTable("Suggestions").HasKey(s => s.QuestionSuggestionID);
        }

        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<UserBaseModel> Users { get; set; }
        public DbSet<QuestionSuggestionModel> Suggestions { get; set; }
    }
}
