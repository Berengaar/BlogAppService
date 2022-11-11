using AutoMapper;
using BlogAppService.Application.Dtos.ArticleRelishDtos;
using BlogAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Mapping
{
    public class ArticleRelishProfile : Profile
    {
        public ArticleRelishProfile()
        {
            CreateMap<ArticleRelish, AddArticleRelishDto>().ReverseMap();
            CreateMap<ArticleRelish, UpdateArticleRelishDto>().ReverseMap();
            CreateMap<ArticleRelish, ArticleRelishDto>()
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.AppUser.UserName))
                .ReverseMap();
        }
    }
}
