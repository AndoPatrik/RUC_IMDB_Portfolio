using Application.Interfaces.v1.Repositories;
using IMDB.Application.DTOs;
using IMDB.Application.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.v1.AuthService.Command
{
    public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, ResponseMessage>
    {
        private readonly IAuthRepository _authRepository;

        public AuthenticateCommandHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<ResponseMessage> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            return await _authRepository.Authenticate(request.User);
        }
    }
}
