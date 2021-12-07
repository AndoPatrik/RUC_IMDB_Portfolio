using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.TitleService.Queries
{
    public class GetTitleByTconstQueryHandler : IRequestHandler<GetTitleByTconstQuery, ResponseMessage>
    {
        private readonly ITitlesRepository _titlesRepository;

        public GetTitleByTconstQueryHandler(ITitlesRepository titlesRepository)
        {
            _titlesRepository = titlesRepository;
        }

        public async Task<ResponseMessage> Handle(GetTitleByTconstQuery request, CancellationToken cancellationToken)
        {
            return await _titlesRepository.GetTitleByTconst(request.Tconst);
        }
    }
}
