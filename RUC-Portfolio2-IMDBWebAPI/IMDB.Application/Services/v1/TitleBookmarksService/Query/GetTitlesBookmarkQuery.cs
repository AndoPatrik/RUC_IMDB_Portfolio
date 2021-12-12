using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.TitleBookmarksService.Query
{
    public class GetTitlesBookmarkQuery : IRequest<ResponseMessage>
    {
        public string JWTToken { get; set; }
    }
}
