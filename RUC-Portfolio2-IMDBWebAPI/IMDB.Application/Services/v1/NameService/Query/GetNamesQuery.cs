using Domain.Entities;
using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.NameService.Query
{
    public class GetNamesQuery : IRequest<PagedResponse<NameBasic>>
    {
        public PagedRequest? PagedRequest { get; set; }
        public string CurrentPathUri { get; set; }
    }
}
