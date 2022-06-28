using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_webapi_example.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiVersion("1.4")]
    [ApiVersion("1.9")]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetV1()
        {
            return Ok($"This is TestController V1.0");
        }
        [HttpGet, MapToApiVersion("1.4")]
        public IActionResult GetV14()
        {
            return Ok($"This is TestController V1.4");
        }
        [HttpGet, MapToApiVersion("1.9")]
        public IActionResult GetV19()
        {
            return Ok($"This is TestController V1.9");
        }
    }
}
