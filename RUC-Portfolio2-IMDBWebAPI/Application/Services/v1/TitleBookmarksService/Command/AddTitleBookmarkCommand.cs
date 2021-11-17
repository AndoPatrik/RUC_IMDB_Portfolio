using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.TitleBookmarksService.Command
{
    public class AddTitleBookmarkCommand : IRequest<ResponseMessage>
    {
        public TitleBookmarkDTO titleBookmark { get; set; }
    }
}
