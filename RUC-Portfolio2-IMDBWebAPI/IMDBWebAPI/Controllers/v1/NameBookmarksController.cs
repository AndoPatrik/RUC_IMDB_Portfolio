using IMDB.Application.DTOs;
using IMDB.Application.Services.v1.BookmarksService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB.WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameBookmarksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NameBookmarksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BookmarksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BookmarksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BookmarksController>
        [HttpPost("create")]
        public async Task<ActionResult<ResponseMessage>> CreateNameBookmark([FromBody] NameBookmarkDTO bodyPayload)
        {
            try
            {
                var result = await _mediator.Send(new AddNameBookmarkCommand { Bookmark = bodyPayload });
                if (result.Data is null) return NotFound(result);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<BookmarksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
