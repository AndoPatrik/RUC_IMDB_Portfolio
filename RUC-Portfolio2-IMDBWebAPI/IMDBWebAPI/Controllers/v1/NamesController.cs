using IMDB.Application.DTOs;
using IMDB.Application.Services.v1.NameService.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMDB.WebAPI.Controllers.v1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NamesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<TitlesController/id>
        [HttpGet("{nconst}")]
        public async Task<ActionResult<ResponseMessage>> GetNameByNconst(string nconst)
        {
            try
            {
                var result =  await _mediator.Send(new GetNameByNconstQuery { Nconst = nconst });
                if (result.Data == null) return NotFound(result);
                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> GetAllNames([FromQuery] PagedRequest pagedRequest)
        {
            try
            {
                var currentUri = string.Format("{0}://{1}{2}{3}", HttpContext.Request.Scheme, HttpContext.Request.Host, HttpContext.Request.Path, HttpContext.Request.QueryString);
                var result = await _mediator.Send(new GetNamesQuery { PagedRequest = pagedRequest, CurrentPathUri = currentUri });
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