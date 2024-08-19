namespace QuizQuest.DataAccess.Entites
{
    public class QuizResultEntity
    {
        public int Id { get; set; }
        public DateTime DateTaken { get; set; }
        public int Score { get; set; }

        public Guid? UserId { get; set; }
        public UserEntity? User { get; set; }

        public int? QuizId { get; set; }
        public QuizEntity? Quiz { get; set; }
    }
}