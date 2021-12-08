using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.TitleService.Queries
{
    public class GetTitleByTconstQuery : IRequest<ResponseMessage>
    {
        public string Tconst { get; set; }
    }
}
