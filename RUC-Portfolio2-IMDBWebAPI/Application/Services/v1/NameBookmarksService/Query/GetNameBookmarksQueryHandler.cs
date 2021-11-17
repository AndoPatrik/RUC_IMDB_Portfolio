using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.BookmarksService.Query
{
    public class GetNameBookmarksQueryHandler : IRequestHandler<GetNameBookmarksQuery, ResponseMessage>
    {
        private readonly IBookmarksRepository _bookmarksRepository;

        public GetNameBookmarksQueryHandler(IBookmarksRepository bookmarksRepository)
        {
            _bookmarksRepository = bookmarksRepository;
        }

        public async Task<ResponseMessage> Handle(GetNameBookmarksQuery request, CancellationToken cancellationToken)
        {
            return await _bookmarksRepository.GetNamesBookmarksByUser(request.JWTToken);
        }
    }
}
