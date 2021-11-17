using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.NameService.Query
{
    public class GetNameQueryHandler : IRequestHandler<GetNameQuery, ResponseMessage>
    {
        private readonly INamesRepository _namesRepository;

        public GetNameQueryHandler(INamesRepository namesRepository)
        {
            _namesRepository = namesRepository;
        }

        public async Task<ResponseMessage> Handle(GetNameQuery request, CancellationToken cancellationToken)
        {
            if (request.Nconst == null)
            {
                return await _namesRepository.GetAllNames();
            }
            else
            {
                return await _namesRepository.GetNameByNconst(request.Nconst);
            }

        }

    }
}