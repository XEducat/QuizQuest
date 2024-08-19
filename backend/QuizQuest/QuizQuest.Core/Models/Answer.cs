namespace QuizQuest.Core.Models
{
    /// <summary>
    /// Модель ответа, которая содержит текст ответа и флаг, указывающий, является ли он правильным.
    /// </summary>
    public class Answer
    {
        public const int MAX_TEXT_LENGTH = 270;
        private Answer(int id, string text, bool isCorrect, int questionId, Question? question)
        {
            Id = id;
            Text = text;
            IsCorrect = isCorrect;
            QuestionId = questionId;
            Question = question;
        }

        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }


        public static (Answer? Answer, List<string> Errors) Create(int id, string text, bool isCorrect, int questionId, Question? question)
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

            var answer = new Answer(id, text, isCorrect, questionId, question);
            return (answer, errors);
        }
    }
}
