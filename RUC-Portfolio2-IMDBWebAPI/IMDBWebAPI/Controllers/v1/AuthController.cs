using Application.Interfaces.v1.Repositories;
using Application.Services.v1.AuthService.Command;
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
        private readonly IAuthRepository _repositroy;
        private readonly IMediator _mediator;

        public AuthController(IAuthRepository repositroy, IMediator mediator)
        {
            _repositroy = repositroy;
            _mediator = mediator;
        }

        // POST api/<AuthController>
        [HttpPost]
        public async Task<ActionResult<AuthInstance>> Post([FromBody] string value)
        {
            try
            {
                var result = await _mediator.Send(new AuthenticateCommand());
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
