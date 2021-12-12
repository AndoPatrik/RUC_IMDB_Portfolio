using IMDB.Application.DTOs;
using MediatR;

namespace Application.Services.v1.AuthService.Command
{
    public class AuthenticateCommand : IRequest<ResponseMessage>
    {
        public UserDTO User { get; set; }
    }
}
