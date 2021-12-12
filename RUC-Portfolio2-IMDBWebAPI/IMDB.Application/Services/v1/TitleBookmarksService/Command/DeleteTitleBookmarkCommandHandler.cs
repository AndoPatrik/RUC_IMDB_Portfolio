using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.TitleBookmarksService.Command
{
    public class DeleteTitleBookmarkCommandHandler : IRequestHandler<DeleteTitleBookmarkCommand, ResponseMessage>
    {
        private readonly IBookmarksRepository _bookmarksRepository;
        private readonly IJWTAuthenticationManager _jWTAuthenticationManager;

        public DeleteTitleBookmarkCommandHandler(IBookmarksRepository bookmarksRepository, IJWTAuthenticationManager jWTAuthenticationManager)
        {
            _bookmarksRepository = bookmarksRepository;
            _jWTAuthenticationManager = jWTAuthenticationManager;
        }

        public async Task<ResponseMessage> Handle(DeleteTitleBookmarkCommand request, CancellationToken cancellationToken)
        {
            TitleBookmarkDTO titleBookmark = new TitleBookmarkDTO
            {
                Uconst = _jWTAuthenticationManager.DecodeJWT(request.JWTToken).UserID,
                Tconst = request.Tconst
            };
            return await _bookmarksRepository.DeleteTitleBookmarksByUser(titleBookmark);
        }
    }
}
