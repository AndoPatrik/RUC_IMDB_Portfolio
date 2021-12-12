using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.BookmarksService.Command
{
    public class DeleteNameBookmarkingCommand : IRequest<ResponseMessage>
    {
        public string Nconst { get; set; }
        public string JWTToken { get; set; }
    }
}
