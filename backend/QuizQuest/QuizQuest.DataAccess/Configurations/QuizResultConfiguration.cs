using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizQuest.DataAccess.Entites;

namespace QuizQuest.DataAccess.Configurations
{
    public class QuizResultConfiguration : IEntityTypeConfiguration<QuizResultEntity>
    {
        public void Configure(EntityTypeBuilder<QuizResultEntity> builder)
        {
            builder.HasKey(qr => qr.Id);

            builder.Property(qr => qr.DateTaken)
                .IsRequired();

            builder.Property(qr => qr.Score)
                .IsRequired();

            builder.HasOne(qr => qr.User)
                .WithMany(u => u.QuizResults)
                .HasForeignKey(qr => qr.UserId)
                .OnDelete(DeleteBehavior.SetNull);  // Настройка каскадного удаления

            builder.HasOne(qr => qr.Quiz)
                .WithMany(q => q.QuizResults)
                .HasForeignKey(qr => qr.QuizId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}