using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.TitleService.Queries
{
    public class GetTitleQuery : IRequest<ResponseMessage>
    {
        public string Tconst { get; set; }
    }
}
