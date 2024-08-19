namespace QuizQuest.Core.Models
{
    /// <summary>
    ///  Модель для хранения результатов прохождения викторины, привязанная к пользователю и конкретной викторине.
    /// </summary>
    public class QuizResult
    {
        public int Id { get; set; }
        public DateTime DateTaken { get; set; }
        public int Score { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public int? QuizId { get; set; }
        public Quiz? Quiz { get; set; }

        private QuizResult(int id, DateTime dateTaken, int score, Guid? userId, User? user, int? quizId, Quiz? quiz)
        {
            Id = id;
            DateTaken = dateTaken;
            Score = score;
            UserId = userId;
            User = user;
            QuizId = quizId;
            Quiz = quiz;
        }

        public static (QuizResult? QuizResult, List<string> Errors) Create(int id, DateTime dateTaken, int score, Guid? userId, User? user, int? quizId, Quiz? quiz)
        {
            var errors = new List<string>();

            if (score < 0)
            {
                errors.Add("Score cannot be negative.");
            }

            if (errors.Any())
            {
                return (null, errors);
            }

            var quizResult = new QuizResult(id, dateTaken, score, userId, user, quizId, quiz);
            return (quizResult, errors);
        }
    }
}