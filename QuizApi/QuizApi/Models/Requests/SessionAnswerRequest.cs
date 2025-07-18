using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models.Requests
{
    public class SessionAnswerRequest
    {
        public Guid SessionId { get; set; }
        public int QuestionId { get; set; }
        public string SelectedAnswer { get; set; }

        // Yeni eklenen alan
        public DateTime AnsweredAt { get; set; } = DateTime.UtcNow;
    }

}
