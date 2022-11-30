using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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

        [HttpGet]
        [Route("/api/nagybetus/{szoveg}")]
        public IActionResult Nagybetus(string szoveg)
        {
            try
            {
                return Ok(szoveg.ToUpper());
            }
            catch
            {
                return BadRequest("Nem szöveg");
            }
        }
    }
}
