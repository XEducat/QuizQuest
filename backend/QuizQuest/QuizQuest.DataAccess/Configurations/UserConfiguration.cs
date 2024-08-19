using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizQuest.Core.Models;
using QuizQuest.DataAccess.Entites;

namespace QuizQuest.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(User.MAX_USERNAME_LENGTH);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(User.MAX_EMAIL_LENGTH);

            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(256);  // Установите длину в соответствии с вашими требованиями

            builder.Property(u => u.Role)
                .IsRequired()
                .HasMaxLength(50);  // Установите длину в соответствии с вашими требованиями

            builder.HasMany(u => u.QuizResults)
                .WithOne(qr => qr.User)
                .HasForeignKey(qr => qr.UserId)
                .OnDelete(DeleteBehavior.SetNull);  // Настройка каскадного удаления
        }
    }
}