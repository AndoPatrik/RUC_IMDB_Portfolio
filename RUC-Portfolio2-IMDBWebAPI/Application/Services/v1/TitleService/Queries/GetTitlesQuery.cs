using Domain.Entities;
using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.TitleService.Queries
{
    public class GetTitlesQuery : IRequest<PagedResponse<TitleBasic>>
    {
        public PagedRequest? PagedRequest { get; set; }
        public string CurrentPathUri { get; set; }
    }
}
