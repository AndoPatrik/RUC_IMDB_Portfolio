using IMDB.Application.DTOs;
using IMDB.Application.Services.v1.BookmarksService;
using IMDB.Application.Services.v1.BookmarksService.Command;
using IMDB.Application.Services.v1.BookmarksService.Query;
using IMDB.Application.Services.v1.TitleBookmarksService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB.WebAPI.Controllers.v1
{
    [Authorize]
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
        public async Task<ActionResult<ResponseMessage>> GetNamesBookmarks()
        {
            try
            {
                var bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
                var response = await _mediator.Send(new GetNamesBookmarksQuery { JWTToken = bearer_token });
                if (response.Data is null) return NotFound(response);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
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
        [HttpDelete("{nconst}")]
        public async Task<ActionResult<ResponseMessage>> RemoveNameBookmark(string nconst)
        {
            try
            {
                var bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
                var result = await _mediator.Send(new DeleteNameBookmarkingCommand { Nconst = nconst, JWTToken = bearer_token });
                if (result.Data is null) return NotFound(result);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
