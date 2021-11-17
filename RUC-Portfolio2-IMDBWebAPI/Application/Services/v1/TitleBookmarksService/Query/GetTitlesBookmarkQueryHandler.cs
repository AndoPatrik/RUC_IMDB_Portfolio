using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.TitleBookmarksService.Query
{
    public class GetTitlesBookmarkQueryHandler : IRequestHandler<GetTitlesBookmarkQuery, ResponseMessage>
    {
        private readonly IBookmarksRepository _bookmarksRepository;

        public GetTitlesBookmarkQueryHandler(IBookmarksRepository bookmarksRepository)
        {
            _bookmarksRepository = bookmarksRepository;
        }

        public async Task<ResponseMessage> Handle(GetTitlesBookmarkQuery request, CancellationToken cancellationToken)
        {
            return await _bookmarksRepository.GetTitleBookmarksByUser(request.JWTToken);
        }
    }
}
