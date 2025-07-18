using System;
using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models.DTOs
{
    public class SessionAnswerRequestDto
    {
        [Required]
        public Guid SessionId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public string SelectedOption { get; set; } = string.Empty;
    }
}
