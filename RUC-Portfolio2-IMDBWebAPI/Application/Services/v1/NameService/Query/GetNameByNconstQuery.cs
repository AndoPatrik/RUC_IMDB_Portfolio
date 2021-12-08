using IMDB.Application.DTOs;
using MediatR;

namespace IMDB.Application.Services.v1.NameService.Query
{
    public class GetNameByNconstQuery : IRequest<ResponseMessage>
    {
        public string Nconst { get; set; }
    }
}