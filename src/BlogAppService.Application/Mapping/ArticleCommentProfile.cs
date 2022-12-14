using AutoMapper;
using BlogAppService.Application.Dtos.ArticleCommentDtos;
using BlogAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Mapping
{
    public class ArticleCommentProfile:Profile
    {
        public ArticleCommentProfile()
        {
            CreateMap<AddArticleCommentDto,ArticleComment>().ReverseMap();
            CreateMap<ArticleComment, ArticleCommentDto>()
                .ForMember(dest => dest.UserName, act => act.MapFrom(src => src.AppUser.UserName))
                .ReverseMap();
            CreateMap<UpdateArticleCommentDto,ArticleComment>().ReverseMap();
        }
    }
}
