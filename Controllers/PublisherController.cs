using csharp_webapi_example.ActionResults;
using csharp_webapi_example.Data.Models;
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
        private readonly ILogger<PublisherController> _logger;
        public PublisherController(PublisherService publisherService, ILogger<PublisherController> logger)
        {
            _publisherService = publisherService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllPublishers()
        {
            try
            {
                _logger.LogInformation("Loggin from Publihser GetAllPublishers()");
                var _result = _publisherService.GetAllPublishers();
                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("Error loading publishers");
            }
        }
        public IActionResult GetAllPublishers(string sortBy, string searchString, int pageNumber)
        {
            try
            {
                _logger.LogInformation("Loggin Publihser GetAllPublishers()");
                var _result = _publisherService.GetAllPublishers(sortBy, searchString, pageNumber);
                return Ok(_result);
            }
            catch (Exception)
            {
                return BadRequest("Error loading publishers");
            }
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
            var _response = _publisherService.GetPublisherById(id);

            if (_response != null)
            {
                return Ok(_response);
                //var _responseObj = new CustomActionResultVM()
                //{
                //    Publisher = _response,
                //};
                //return new CustomActionResult(_responseObj);
            }
            else
            {
                return NotFound();
                //var _responseObj = new CustomActionResultVM()
                //{
                //    Exception = new Exception($"This is coming from {nameof(GetPublisherById)} in {this.GetType().Name}"),
                //};
                //return new CustomActionResult(_responseObj);
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
