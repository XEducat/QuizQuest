using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizQuest.Core.Models;
using QuizQuest.DataAccess.Entites;

namespace QuizQuest.DataAccess.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<AnswerEntity>
    {
        public void Configure(EntityTypeBuilder<AnswerEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.Text)
                .HasMaxLength(Answer.MAX_TEXT_LENGTH)
                .IsRequired();

            builder.Property(a => a.IsCorrect)
                .IsRequired();
        }
    }
}