using QuizApi.Models;
using System.Collections.Generic;

namespace QuizApi.Repositories
{
    public interface IQuestionRepository
    {
        List<Question> GetAll();
        Question? GetById(int id);
    }
}
