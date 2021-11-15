using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.UsersService.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResponseMessage>
    {
        private readonly IUsersRepository _usersRepository;

        public CreateUserCommandHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<ResponseMessage> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           return await _usersRepository.RegisterUser(request.User);
        }
    }
}
