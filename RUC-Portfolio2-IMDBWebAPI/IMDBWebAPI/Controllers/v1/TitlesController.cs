﻿using IMDB.Application.DTOs;
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
                    var result = await _mediator.Send(new GetTitleQuery { Tconst = tconst });
                    if (result.Data is null) return NotFound(result);
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }

        [HttpGet]
        public async Task<ActionResult<ResponseMessage>> GetAllTitles()
        {
            try
            {
                var result = await _mediator.Send(new GetTitleQuery { });
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