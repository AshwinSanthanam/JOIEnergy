using Microsoft.AspNetCore.Mvc;

namespace JOIEnergy.Controllers
{
    [Route("test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("Test");
        }
    }
}
