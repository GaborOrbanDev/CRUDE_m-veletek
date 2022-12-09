using CRUDE_műveletek.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDE_műveletek.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        [HttpGet]
        [Route("/questions/all")]
        public IActionResult GetAllQuestions()
        {
            HajosContext contecxt = new();
            var kérdések = contecxt.Questions.Select(x => x.Question1);
            return Ok(kérdések);
            //return new JsonResult(kérdések);
        }

        [HttpGet]
        [Route("questions/{sorszam}")]
        public IActionResult GetAction(int sorszam)
        {
            HajosContext context = new HajosContext();
            var kérdés = context.Questions.Where(q=>q.QuestionId==sorszam).Select(x => x).FirstOrDefault();
            if (kérdés == null) return BadRequest("Nincs ilyen sorszámú kérdés");
            return new JsonResult(kérdés);
        }
    }
}
