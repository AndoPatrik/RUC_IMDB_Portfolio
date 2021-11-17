using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.BookmarksService.Command
{
    public class DeleteNameBookmarkingCommandHandler : IRequestHandler<DeleteNameBookmarkingCommand, ResponseMessage>
    {
        private readonly IBookmarksRepository _bookmarksRepository;
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager;

        public DeleteNameBookmarkingCommandHandler(IBookmarksRepository bookmarksRepository, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _bookmarksRepository = bookmarksRepository;
            _jWTAuthenticationManager = jWTAuthenticationManager;
        }

        public async Task<ResponseMessage> Handle(DeleteNameBookmarkingCommand request, CancellationToken cancellationToken)
        {
            NameBookmarkDTO nameBookmark = new NameBookmarkDTO 
            {
                Uconst = _jWTAuthenticationManager.DecodeJWT(request.JWTToken).UserID,
                Nconst = request.Nconst
            };
            return await _bookmarksRepository.DeleteNameBookmarksByUser(nameBookmark);
        }
    }
}
