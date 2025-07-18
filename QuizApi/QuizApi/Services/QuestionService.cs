using QuizApi.Models;
using QuizApi.Models.Data;
using QuizApi.Models.DTOs;
using QuizApi.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuizApi.Services
{
    public class QuestionService
    {
        private readonly Random _random = new Random();

        // 🧠 In-memory cevap logları
        private readonly List<AnswerLog> _answerLogs = new List<AnswerLog>();

        private QuestionDto ToDTO(Question question)
        {
            return new QuestionDto
            {
                Id = question.Id,
                QuestionText = question.QuestionText ?? string.Empty,
                Options = question.Options ?? new List<string>()
            };
        }

        public List<QuestionDto> GetAllQuestions()
        {
            return QuestionData.Questions.Select(q => ToDTO(q)).ToList();
        }

        public QuestionDto? GetRandomQuestion()
        {
            var questions = QuestionData.Questions;
            if (questions.Count == 0)
                return null;

            int index = _random.Next(questions.Count);
            return ToDTO(questions[index]);
        }

        public Question? GetQuestionById(int id)
        {
            return QuestionData.Questions.FirstOrDefault(q => q.Id == id);
        }

        public bool CheckAnswer(int questionId, string selectedOption)
        {
            var question = GetQuestionById(questionId);
            if (question == null)
                return false;

            return string.Equals(question.CorrectAnswer, selectedOption, StringComparison.OrdinalIgnoreCase);
        }

        public (bool IsCorrect, int CurrentScore, string? CorrectAnswer, string? ErrorMessage) SubmitAnswerWithSession(SessionAnswerRequest request)
        {
            var session = SessionData.Sessions.FirstOrDefault(s => s.SessionId == request.SessionId);
            if (session == null)
                return (false, 0, null, "Oturum bulunamadı.");

            var question = GetQuestionById(request.QuestionId);
            if (question == null)
                return (false, 0, null, "Soru bulunamadı.");

            if (session.AnsweredQuestionIds.Contains(request.QuestionId))
                return (false, session.Score, question.CorrectAnswer, "Bu soruya zaten cevap verildi.");

            // Zaman sınırı kontrolü (1 dakika = 60 saniye)
            var timeLimit = TimeSpan.FromSeconds(60);

            if (request.AnsweredAt == null)
            {
                return (false, session.Score, question.CorrectAnswer, "Cevap zamanı belirtilmedi.");
            }

            DateTime answeredAtUtc = request.AnsweredAt.ToUniversalTime();
            DateTime nowUtc = DateTime.UtcNow;

            if ((nowUtc - answeredAtUtc) > timeLimit)
            {
                return (false, session.Score, question.CorrectAnswer, "Cevap süresi aşıldı.");
            }

            bool isCorrect = string.Equals(question.CorrectAnswer, request.SelectedAnswer, StringComparison.OrdinalIgnoreCase);
            if (isCorrect) session.Score += 10;

            session.AnsweredQuestionIds.Add(request.QuestionId);

            // Log kaydı ekle
            // Log kaydı ekle
            _answerLogs.Add(new AnswerLog
            {
                SessionId = request.SessionId.ToString(),
                QuestionId = request.QuestionId,
                SelectedAnswer = request.SelectedAnswer,
                IsCorrect = isCorrect,
                AnsweredAt = request.AnsweredAt
            });


            return (isCorrect, session.Score, question.CorrectAnswer, null);
        }

        // 🔎 İstersen logları dışarıdan erişmek için ekleyebilirsin:
        public List<AnswerLog> GetLogsForSession(string sessionId)
        {
            return _answerLogs.Where(log => log.SessionId == sessionId).ToList();
        }
    }
}
