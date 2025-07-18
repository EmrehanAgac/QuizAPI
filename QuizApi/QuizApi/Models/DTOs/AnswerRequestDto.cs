using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models.DTOs
{
    public class AnswerRequestDto
    {
        [Required]
        public int QuestionId { get; set; }

        [Required]
        public string SelectedOption { get; set; } = string.Empty;
    }
}
