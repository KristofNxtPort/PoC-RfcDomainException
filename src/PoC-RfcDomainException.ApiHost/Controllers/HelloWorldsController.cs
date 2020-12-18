using Microsoft.AspNetCore.Mvc;

namespace PoC_RfcDomainException.ApiHost.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Hello, World!");
        }
    }
}