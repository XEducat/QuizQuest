using QuizQuest.Core.Models;

namespace QuizQuest.Core.Interfaces
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllAsync();
        Task<Answer?> GetByIdAsync(int id);
        Task<int> CreateAsync(Answer answer);
        Task<int> UpdateAsync(int id, string text, bool isCorrect, int questionId);
        Task<int> DeleteAsync(int id);
    }
}
