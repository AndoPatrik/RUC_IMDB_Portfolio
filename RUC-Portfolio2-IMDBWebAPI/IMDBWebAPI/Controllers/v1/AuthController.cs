using Application.Services.v1.AuthService.Command;
using IMDB.Application.DTOs;
using IMDB.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB.WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<AuthController>
        [HttpPost()]
        public async Task<ActionResult<AuthInstance>> Authenticate([FromBody] UserDTO bodyPayload)
        {
            try
            {
                var result = await _mediator.Send(new AuthenticateCommand { User = bodyPayload});
                if (result.Data is null) return Unauthorized(result);
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
