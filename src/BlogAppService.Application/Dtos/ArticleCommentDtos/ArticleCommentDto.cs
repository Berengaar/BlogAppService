using BlogAppService.Application.Dtos.ArticleCommentRelishDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Dtos.ArticleCommentDtos
{
    public class ArticleCommentDto
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public IList<ArticleCommentRelishDto> ArticleCommentRelishes { get; set; }
    }
}
