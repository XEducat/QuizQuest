using Microsoft.EntityFrameworkCore;
using QuizQuest.DataAccess.Entites;

namespace LearnRazor.DataAccess
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options)
            : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<QuizEntity> Quizzes { get; set; }
        public DbSet<QuizResultEntity> QuizResults { get; set; }
    }
}
