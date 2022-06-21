using csharp_webapi_example.Exceptions;
using csharp_webapi_example.Services;
using csharp_webapi_example.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_webapi_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly PublisherService _publisherService;
        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var oPublisher = _publisherService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), oPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Publisher name: {ex.PublisherName}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPublisherById(int id)
        {
            throw new Exception("Exception handled by middleware");

            var _response = _publisherService.GetPublisherById(id);
            if(_response != null)
            {
                return Ok(_response);
            } else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/full")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _publisherService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete]
        public IActionResult DeletePublisher(int id)
        {
            try
            {
                _publisherService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
