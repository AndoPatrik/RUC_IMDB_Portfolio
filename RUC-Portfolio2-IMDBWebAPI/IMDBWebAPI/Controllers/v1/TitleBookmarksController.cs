using IMDB.Application.DTOs;
using IMDB.Application.Services.v1.TitleBookmarksService.Command;
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
    public class TitleBookmarksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TitleBookmarksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TitleBookmarksController>
        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> GetTitleBookmarks()
        {
            try
            {
                var bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
                var response = await _mediator.Send(new GetTitlesBookmarkQuery { JWTToken = bearer_token });
                if (response.Data is null) return NotFound(response);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<TitleBookmarksController>
        [HttpPost("create")]
        public async Task<ActionResult<ResponseMessage>> CreateTitleBookmark([FromBody] TitleBookmarkDTO titleBookmark)
        {
            try
            {
                var response = await _mediator.Send(new AddTitleBookmarkCommand { titleBookmark = titleBookmark });
                if (response.Data is null) return NotFound(response);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{tconst}")]
        public async Task<ActionResult<ResponseMessage>> DeleteTitleBookmark(string tconst)
        {
            try
            {
                var bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
                var result = await _mediator.Send(new DeleteTitleBookmarkCommand { Tconst = tconst, JWTToken = bearer_token });
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
