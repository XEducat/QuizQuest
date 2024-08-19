namespace QuizQuest.Core.Models
{
    /// <summary>
    /// Модель вопроса, который привязан к викторине и содержит текст вопроса и список возможных ответов.
    /// </summary>
    public class Question
    {
        public const int MAX_TEXT_LENGTH = 500;
        private Question(int id, string text, int quizId, Quiz quiz)
        {
            Id = id;
            Text = text;
            QuizId = quizId;
            Quiz = quiz;
            Answers = new List<Answer>();
        }

        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }

        public ICollection<Answer>? Answers { get; set; }


        public static (Question? Question, List<string> Errors) Create(int id, string text, int quizId, Quiz quiz)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(text) || text.Length > MAX_TEXT_LENGTH)
            {
                errors.Add($"Text cannot be empty or longer than {MAX_TEXT_LENGTH} characters.");
            }

            if (errors.Any())
            {
                return (null, errors);
            }

            var question = new Question(id, text, quizId, quiz);
            return (question, errors);
        }
    }
}