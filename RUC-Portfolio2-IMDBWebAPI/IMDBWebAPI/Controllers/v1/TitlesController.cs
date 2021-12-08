using IMDB.Application.DTOs;
using IMDB.Application.Services.v1.TitleService.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.WebAPI.Controllers.v1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TitlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<TitlesController/id>
        [HttpGet("{tconst}")]
        public async Task<ActionResult<ResponseMessage>> GetTitleByTconst(string tconst)
        {
            try
            {
                //TOOD: Return DTO
                var result = await _mediator.Send(new GetTitleByTconstQuery { Tconst = tconst });
                if (result.Data is null) return NotFound(result);
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> GetAllTitles([FromQuery] PagedRequest pagedRequest)
        {
            try
            {
                //TOOD: Return DTO
                var currentUri = string.Format("{0}://{1}{2}{3}", HttpContext.Request.Scheme, HttpContext.Request.Host, HttpContext.Request.Path, HttpContext.Request.QueryString);
                var result = await _mediator.Send(new GetTitlesQuery { PagedRequest = pagedRequest, CurrentPathUri = currentUri });
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