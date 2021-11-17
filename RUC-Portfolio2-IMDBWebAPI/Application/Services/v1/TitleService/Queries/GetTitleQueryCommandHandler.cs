using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.TitleService.Queries
{
    public class GetTitleQueryCommandHandler : IRequestHandler<GetTitleQuery, ResponseMessage>
    {
        private readonly ITitlesRepository _titlesRepository;

        public GetTitleQueryCommandHandler(ITitlesRepository titlesRepository)
        {
            _titlesRepository = titlesRepository;
        }

        public async Task<ResponseMessage> Handle(GetTitleQuery request, CancellationToken cancellationToken)
        {

            if (request.Tconst == null)
            {
                return await _titlesRepository.GetAllTitles();
            }
            else
            {
                return await _titlesRepository.GetTitleByTconst(request.Tconst);
            }
        }
    }
}
