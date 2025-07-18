using QuizApi.Models;
using QuizApi.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace QuizApi.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public List<Question> GetAll()
        {
            return QuestionData.Questions;
        }

        public Question? GetById(int id)
        {
            return QuestionData.Questions.FirstOrDefault(q => q.Id == id);
        }
    }
}
