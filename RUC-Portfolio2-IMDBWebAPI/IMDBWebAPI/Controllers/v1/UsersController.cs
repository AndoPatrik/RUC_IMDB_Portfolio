using IMDB.Application.DTOs;
using IMDB.Application.Services.v1.UsersService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB.WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<UsersController/register>
        [HttpPost("register")]
        public async Task<ActionResult<ResponseMessage>> RegisterUser ([FromBody] UserDTO bodyPayload)
        {
            try
            {
               return await _mediator.Send(new CreateUserCommand{ User = bodyPayload});
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
