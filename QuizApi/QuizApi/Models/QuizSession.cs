using System;
using System.Collections.Generic;

namespace QuizApi.Models
{
    public class QuizSession
    {
        public Guid SessionId { get; set; } = Guid.NewGuid();
        public int Score { get; set; } = 0;
        public List<int> AnsweredQuestionIds { get; set; } = new List<int>();
        public DateTime StartTime { get; set; } = DateTime.UtcNow;  // Burada UTC kullanmak en iyisi
    }
}
