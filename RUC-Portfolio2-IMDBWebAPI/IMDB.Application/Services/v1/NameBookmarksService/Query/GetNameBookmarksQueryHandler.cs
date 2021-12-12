using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.BookmarksService.Query
{
    public class GetNamesBookmarkQueryHandler : IRequestHandler<GetNamesBookmarksQuery, ResponseMessage>
    {
        private readonly IBookmarksRepository _bookmarksRepository;

        public GetNamesBookmarkQueryHandler(IBookmarksRepository bookmarksRepository)
        {
            _bookmarksRepository = bookmarksRepository;
        }

        public async Task<ResponseMessage> Handle(GetNamesBookmarksQuery request, CancellationToken cancellationToken)
        {
            return await _bookmarksRepository.GetNamesBookmarksByUser(request.JWTToken);
        }
    }
}
