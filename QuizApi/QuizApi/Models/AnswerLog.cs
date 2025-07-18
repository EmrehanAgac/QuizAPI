namespace QuizApi.Models
{
    public class AnswerLog
    {
        public string SessionId { get; set; }
        public int QuestionId { get; set; }
        public string SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }  // Bunu ekle
        public DateTime AnsweredAt { get; set; }
    }
}