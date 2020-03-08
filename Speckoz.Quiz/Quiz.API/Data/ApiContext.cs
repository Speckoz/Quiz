using Microsoft.EntityFrameworkCore;

using Quiz.Dependencies.Models;

using System;

namespace Quiz.API.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException(nameof(modelBuilder));

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserBaseModel>().ToTable("Users").HasKey(u => u.UserID);

            modelBuilder.Entity<QuestionModel>().ToTable("Questions").HasKey(q => q.QuestionID);
        }

        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<UserBaseModel> Users { get; set; }
    }
}