﻿using AutoMapper;
using Domain.Entities;
using IMDB.Application.DTOs;

namespace IMDB.Application.Mappers
{
    public class NameBookmarkMapper : Profile
    {
        public NameBookmarkMapper()
        {
            CreateMap<NamesBookmarking, NameBookmarkDTO>()
                .ForMember(dest => dest.Uconst, opt => opt.MapFrom(src => src.Uconst))
                .ForMember(dest => dest.Nconst, opt => opt.MapFrom(src => src.Nconst)); 
        }
    }
}
