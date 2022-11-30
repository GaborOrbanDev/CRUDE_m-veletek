using Microsoft.AspNetCore.Mvc;

namespace CRUDE_műveletek.Controllers
{
    [ApiController]
    public class TesztContorller : ControllerBase
    {
        [HttpGet]
        [Route("api/szerverido")]
        public IActionResult Szerveridő()
        {
            string pontosIdő = DateTime.Now.ToShortTimeString();
            return new ContentResult {
                ContentType = System.Net.Mime.MediaTypeNames.Text.Plain,
                Content = pontosIdő
            };
            //ezt lehet egyszerűbben return Ok(pontosIdő);
        }
    }
}
