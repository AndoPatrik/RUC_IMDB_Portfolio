using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.NameService.Query
{
    public class GetNameQuery : IRequest<ResponseMessage>
    {
        public string Nconst { get; set; }

        public GetNameQuery() { }
    }
}