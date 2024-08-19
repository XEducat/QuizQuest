namespace QuizQuest.Core.Models
{
    /// <summary>
    /// Это базовая модель пользователя, включающая поля для идентификации и авторизации.
    /// </summary>
    public class User
    {
        public const int MAX_USERNAME_LENGTH = 50;
        public const int MAX_EMAIL_LENGTH = 100;

        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public ICollection<QuizResult> QuizResults { get; set; }

        private User(Guid id, string userName, string email, string passwordHash, string role)
        {
            Id = id;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Role = role;
            QuizResults = new List<QuizResult>();
        }

        public static (User? User, List<string> Errors) Create(Guid id, string userName, string email, string passwordHash, string role)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(userName) || userName.Length > MAX_USERNAME_LENGTH)
            {
                errors.Add($"UserName cannot be empty or longer than {MAX_USERNAME_LENGTH} characters.");
            }

            if (string.IsNullOrEmpty(email) || email.Length > MAX_EMAIL_LENGTH)
            {
                errors.Add($"Email cannot be empty or longer than {MAX_EMAIL_LENGTH} characters.");
            }

            if (string.IsNullOrEmpty(passwordHash))
            {
                errors.Add("PasswordHash cannot be empty.");
            }

            if (string.IsNullOrEmpty(role))
            {
                errors.Add("Role cannot be empty.");
            }

            if (errors.Any())
            {
                return (null, errors);
            }

            var user = new User(id, userName, email, passwordHash, role);
            return (user, errors);
        }
    }
}
