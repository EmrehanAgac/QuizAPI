using Microsoft.AspNetCore.Mvc;
using QuizApi.Models;
using QuizApi.Models.DTOs;
using QuizApi.Models.Requests;
using QuizApi.Services;
using System.Collections.Generic;

namespace QuizApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionService _questionService;

        public QuestionsController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET /api/questions
        [HttpGet]
        public ActionResult<List<QuestionDto>> GetAllQuestions()
        {
            var questions = _questionService.GetAllQuestions();
            return Ok(questions);
        }

        // GET /api/questions/random
        [HttpGet("random")]
        public ActionResult<QuestionDto> GetRandomQuestion()
        {
            var question = _questionService.GetRandomQuestion();
            if (question == null)
                return NotFound(new { message = "Soru bulunamadı." });
            return Ok(question);
        }

        // POST /api/questions/answer
        [HttpPost("answer")]
        public ActionResult CheckAnswer([FromBody] AnswerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var question = _questionService.GetQuestionById(request.QuestionId);
            if (question == null)
                return NotFound(new { message = "Soru bulunamadı." });

            bool isCorrect = _questionService.CheckAnswer(request.QuestionId, request.SelectedOption);
            return Ok(new { correct = isCorrect });
        }

        // POST /api/questions/submit
        [HttpPost("submit")]
        public ActionResult SubmitAnswerWithSession([FromBody] SessionAnswerRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _questionService.SubmitAnswerWithSession(request);

            if (!string.IsNullOrEmpty(result.ErrorMessage))
                return BadRequest(new { message = result.ErrorMessage });

            return Ok(new
            {
                correct = result.IsCorrect,
                currentScore = result.CurrentScore,
                correctAnswer = result.CorrectAnswer
            });
        }
    }
}
