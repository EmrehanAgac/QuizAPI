using Microsoft.AspNetCore.Mvc;
using QuizApi.Models;
using QuizApi.Models.Data;
using QuizApi.Models.Requests; 

namespace QuizApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizController : ControllerBase
    {
        [HttpPost("start")]
        public ActionResult StartQuiz()
        {
            var session = new QuizSession();
            SessionData.Sessions.Add(session);

            return Ok(new { sessionId = session.SessionId });
        }

    }
}
