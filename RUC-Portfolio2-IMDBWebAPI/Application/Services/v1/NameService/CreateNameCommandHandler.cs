using IMDB.Application.DTOs;
using IMDB.Application.Interfaces.v1.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB.Application.Services.v1.NameService
{
    public class CreateNameCommandHandler : IRequestHandler<CreateNameCommand, ResponseMessage>
    {
        private readonly INamesRepository _namesRepository;

        public CreateNameCommandHandler(INamesRepository namesRepository)
        {
            _namesRepository = namesRepository;
        }

        public async Task<ResponseMessage> Handle(CreateNameCommand request, CancellationToken cancellationToken)
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