using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.BookmarksService.Query
{
    public class GetNamesBookmarksQuery : IRequest<ResponseMessage>
    {
        public string JWTToken { get; set; }
    }
}
