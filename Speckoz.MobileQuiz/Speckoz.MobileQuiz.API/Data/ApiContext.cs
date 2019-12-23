using Microsoft.EntityFrameworkCore;
using Speckoz.MobileQuiz.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Speckoz.MobileQuiz.API.Data
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

            modelBuilder.Entity<UserModel>().ToTable("Users").HasKey(u => u.UserID);
        }

        public DbSet<QuestionModel> Questions { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}
