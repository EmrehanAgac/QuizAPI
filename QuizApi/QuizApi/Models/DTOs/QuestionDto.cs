using System.Collections.Generic;

namespace QuizApi.Models.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new List<string>();
        // CorrectAnswer client’a gönderilmiyor, güvenlik için gizli tutuluyor
    }
}
