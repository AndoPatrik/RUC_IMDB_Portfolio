using Domain.Entities;
using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.NameService.Query
{
    public class GetNamesQueryHandler : IRequestHandler<GetNamesQuery, PagedResponse<NameBasic>>
    {
        private readonly INamesRepository _namesRepository;
        private readonly IUriService _uriService;

        public GetNamesQueryHandler(INamesRepository namesRepository, IUriService uriService)
        {
            _namesRepository = namesRepository;
            _uriService = uriService;
        }

        public async Task<PagedResponse<NameBasic>> Handle(GetNamesQuery request, CancellationToken cancellationToken)
        {
            var namesResponse =  await _namesRepository.GetAllNames(request.PagedRequest);
            if (request.PagedRequest.PageNumber < 1 || request.PagedRequest.PageSize < 1 || namesResponse.Data is null)
            {
                return namesResponse;
            }

            namesResponse.PageNumber = request.PagedRequest.PageNumber;
            namesResponse.PageSize = request.PagedRequest.PageSize;
            namesResponse.NextPage = _uriService.GetNextPageUri(request.CurrentPathUri, request.PagedRequest);
            namesResponse.PreviousPage = _uriService.GetPreviousPageUri(request.CurrentPathUri, request.PagedRequest);

            return namesResponse;
        }
    }
}
