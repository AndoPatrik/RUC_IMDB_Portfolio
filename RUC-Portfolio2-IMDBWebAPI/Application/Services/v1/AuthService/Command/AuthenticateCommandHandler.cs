using Application.Interfaces.v1.Repositories;
using IMDB.Application.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.v1.AuthService.Command
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, AuthInstance>
    {
        private readonly IAuthRepository _authRepository;

        public AuthenticateCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<AuthInstance> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
           AuthInstance x = new AuthInstance();
           x.Msg = await _authRepository.Test();
           return x;
        }
    }
}
