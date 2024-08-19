using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizQuest.Core.Models;
using QuizQuest.DataAccess.Entites;

namespace QuizQuest.DataAccess.Configurations
{
    public class QuizConfiguration : IEntityTypeConfiguration<QuizEntity>
    {
        public void Configure(EntityTypeBuilder<QuizEntity> builder)
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Title)
                .IsRequired()
                .HasMaxLength(Quiz.MAX_TITLE_LENGTH);

            builder.Property(q => q.Description)
                .IsRequired()
                .HasMaxLength(Quiz.MAX_DESCRIPTION_LENGTH);

            builder.HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.QuizResults)
                .WithOne(qr => qr.Quiz)
                .HasForeignKey(qr => qr.QuizId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}