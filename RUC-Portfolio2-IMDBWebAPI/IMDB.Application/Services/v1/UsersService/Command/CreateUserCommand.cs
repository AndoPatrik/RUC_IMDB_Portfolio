using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.UsersService
{
    public class CreateUserCommand : IRequest<ResponseMessage>
    {
        public UserDTO User { get; set; }
    }
}
