using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.BookmarksService
{
    public class AddNameBookmarkCommand : IRequest<ResponseMessage>
    {
        public NameBookmarkDTO Bookmark { get; set; }
    }
}
