using csharp_webapi_example.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_webapi_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogService _logService;
        public LogsController(LogService logService)
        {
            _logService = logService;
        }

        [HttpGet]
        public IActionResult GetAllLogsFromDb()
        {
            try
            {
                var alllogs = _logService.GetAllLogsFromDb();
                return Ok(alllogs);
            }
            catch (Exception)
            {
               return BadRequest("Could not load logs");
            }
        }
    }
}
