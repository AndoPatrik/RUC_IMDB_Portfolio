using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.TitleBookmarksService.Command
{
    public class AddTitleBookmarkCommandHandler : IRequestHandler<AddTitleBookmarkCommand, ResponseMessage>
    {
        private readonly IBookmarksRepository _bookmarksRepository;

        public AddTitleBookmarkCommandHandler(IBookmarksRepository bookmarksRepository)
        {
            _bookmarksRepository = bookmarksRepository;
        }

        public async Task<ResponseMessage> Handle(AddTitleBookmarkCommand request, CancellationToken cancellationToken)
        {
            return await _bookmarksRepository.AddTitleBookmarkToUser(request.titleBookmark);
        }
    }
}
