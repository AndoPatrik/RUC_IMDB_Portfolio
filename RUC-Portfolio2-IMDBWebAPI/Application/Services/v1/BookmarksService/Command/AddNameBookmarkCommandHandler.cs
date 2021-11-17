using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.BookmarksService.Command
{
    public class AddNameBookmarkCommandHandler : IRequestHandler<AddNameBookmarkCommand, ResponseMessage>
    {
        private readonly IBookmarksRepository _bookmarksRepository;

        public AddNameBookmarkCommandHandler(IBookmarksRepository bookmarksRepository)
        {
            _bookmarksRepository = bookmarksRepository;
        }

        public async Task<ResponseMessage> Handle(AddNameBookmarkCommand request, CancellationToken cancellationToken)
        {
            return await _bookmarksRepository.AddNameBookmarkToUser(request.Bookmark);
        }
    }
}
