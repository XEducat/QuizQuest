using LearnRazor.DataAccess;
using Microsoft.EntityFrameworkCore;
using QuizQuest.Core.Interfaces;
using QuizQuest.Core.Models;
using QuizQuest.DataAccess.Entites;

namespace QuizQuest.Core.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizDbContext _context;

        public AnswerRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task<List<Answer>> GetAllAsync()
        {
            var answerEntities = await _context.Answers.AsNoTracking().ToListAsync();

            var answers = answerEntities
                .Select(a => Answer.Create(a.Id, a.Text, a.IsCorrect, a.QuestionId, null).Answer)
                .ToList();

            return answers;
        }

        public async Task<Answer?> GetByIdAsync(int id)
        {
            var answerEntity = await _context.Answers
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (answerEntity == null) return null;

            var answer = Answer.Create(
                answerEntity.Id,
                answerEntity.Text,
                answerEntity.IsCorrect,
                answerEntity.QuestionId,
                null).Answer;

            return answer;
        }

        public async Task<int> CreateAsync(Answer answer)
        {
            var answerEntity = new AnswerEntity
            {
                Id = answer.Id,
                Text = answer.Text,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId
            };

            await _context.Answers.AddAsync(answerEntity);
            await _context.SaveChangesAsync();

            return answerEntity.Id;
        }

        public async Task<int> UpdateAsync(int id, string text, bool isCorrect, int questionId)
        {
            await _context.Answers
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(a => a.Text, a => text)
                    .SetProperty(a => a.IsCorrect, a => isCorrect)
                    .SetProperty(a => a.QuestionId, a => questionId));

            return id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            await _context.Answers
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
