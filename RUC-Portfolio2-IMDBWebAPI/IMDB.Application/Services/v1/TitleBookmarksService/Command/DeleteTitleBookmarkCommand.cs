using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.TitleBookmarksService.Command
{
    public class DeleteTitleBookmarkCommand : IRequest<ResponseMessage>
    {
        public string Tconst { get; set; }
        public string JWTToken { get; set; }
    }
}
