using IMDB.Application.Requests;
using MediatR;

namespace Application.Services.v1.AuthService.Command
{
    public class AuthenticateCommand : IRequest<AuthInstance>
    {
    }
}
