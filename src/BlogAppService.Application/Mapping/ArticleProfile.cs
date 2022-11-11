using AutoMapper;
using BlogAppService.Application.Dtos.ArticleDtos;
using BlogAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Mapping
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, AddArticleDto>().ReverseMap();
            CreateMap<Article, UpdateArticleDto>().ReverseMap();
            CreateMap<Article, ArticleDto>()
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.AppUser.UserName))
                .ReverseMap();
        }
    }
}
