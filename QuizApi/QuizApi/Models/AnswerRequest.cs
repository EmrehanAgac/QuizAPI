using System.ComponentModel.DataAnnotations;

namespace QuizApi.Models
{
    public class AnswerRequest
    {
        [Required(ErrorMessage = "questionId boş olamaz")]
        [Range(1, int.MaxValue, ErrorMessage = "Geçersiz questionId")]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "selectedOption boş olamaz")]
        [MinLength(1, ErrorMessage = "Seçilen seçenek boş olamaz")]
        public string SelectedOption { get; set; } = string.Empty;
    }
}
