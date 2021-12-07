using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.NameService.Query
{
    public class GetNameByNconstQueryHandler : IRequestHandler<GetNameByNconstQuery, ResponseMessage>
    {
        private readonly INamesRepository _namesRepository;

        public GetNameByNconstQueryHandler(INamesRepository namesRepository)
        {
            _namesRepository = namesRepository;
        }

        public async Task<ResponseMessage> Handle(GetNameByNconstQuery request, CancellationToken cancellationToken)
        {
            return await _namesRepository.GetNameByNconst(request.Nconst);
        }

    }
}