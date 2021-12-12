using Domain.Entities;
using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace IMDB.Application.Services.v1.TitleService.Queries
{
    public class GetTitlesQueryCommandHandler : IRequestHandler<GetTitlesQuery, PagedResponse<TitleBasic>>
    {
        private readonly ITitlesRepository _titlesRepository;
        private readonly IUriService _uriService;

        public GetTitlesQueryCommandHandler(ITitlesRepository titlesRepository, IUriService uriService)
        {
            _titlesRepository = titlesRepository;
            _uriService = uriService;
        }

        public async Task<PagedResponse<TitleBasic>> Handle(GetTitlesQuery request, CancellationToken cancellationToken)
        {
            var titleResponse = await _titlesRepository.GetAllTitles(request.PagedRequest);

            if (request.PagedRequest.PageNumber < 1 || request.PagedRequest.PageSize < 1 || titleResponse.Data is null)
            {
                return titleResponse;
            }

            titleResponse.PageNumber = request.PagedRequest.PageNumber;
            titleResponse.PageSize = request.PagedRequest.PageSize;
            titleResponse.NextPage = _uriService.GetNextPageUri(request.CurrentPathUri, request.PagedRequest);
            titleResponse.PreviousPage = _uriService.GetPreviousPageUri(request.CurrentPathUri, request.PagedRequest);

            return titleResponse;
        }
    }
}
