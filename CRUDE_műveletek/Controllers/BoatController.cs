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
            //return Ok(kérdések);
            return new JsonResult(kérdések);
        }
    }
}
