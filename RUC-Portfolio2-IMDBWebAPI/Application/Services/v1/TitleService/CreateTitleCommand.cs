using IMDB.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Application.Services.v1.TitleService
{
    public class CreateTitleCommand : IRequest<ResponseMessage>
    {
        public string Tconst { get; set; }
    }
}
