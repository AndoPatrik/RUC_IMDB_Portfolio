using IMDB.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Application.Services.v1.NameService
{
    public class CreateNameCommand : IRequest<ResponseMessage>
    {
        public string Nconst { get; set; }

        public CreateNameCommand() { }
    }
}