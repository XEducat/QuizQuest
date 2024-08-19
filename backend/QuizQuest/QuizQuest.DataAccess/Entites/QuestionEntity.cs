namespace QuizQuest.DataAccess.Entites
{
    public class QuestionEntity
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public int QuizId { get; set; }
        public QuizEntity? Quiz { get; set; }

        public ICollection<AnswerEntity>? Answers { get; set; }
    }
}
