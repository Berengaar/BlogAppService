using BlogAppService.Application.Dtos.ArticleCommentDtos;
using BlogAppService.Application.Dtos.ArticleRelishDtos;
using BlogAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Dtos.ArticleDtos
{
    public class ArticleDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public string CategoryId { get; set; }
        public string UserName { get; set; }
    }
}
