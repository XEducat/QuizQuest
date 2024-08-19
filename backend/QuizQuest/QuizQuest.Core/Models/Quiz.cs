namespace QuizQuest.Core.Models
{
    public class Quiz
    {
        public const int MAX_TITLE_LENGTH = 100;
        public const int MAX_DESCRIPTION_LENGTH = 500;

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Question> Questions { get; set; }

        private Quiz(int id, string title, string? description)
        {
            Id = id;
            Title = title;
            Description = description;
            Questions = new List<Question>();
        }

        public static (Quiz? Quiz, List<string> Errors) Create(int id, string title, string? description)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                errors.Add($"Title cannot be empty or longer than {MAX_TITLE_LENGTH} characters.");
            }

            if (description?.Length > MAX_DESCRIPTION_LENGTH)
            {
                errors.Add($"Description cannot be longer than {MAX_DESCRIPTION_LENGTH} characters.");
            }

            if (errors.Any())
            {
                return (null, errors);
            }

            var quiz = new Quiz(id, title, description);
            return (quiz, errors);
        }
    }
}