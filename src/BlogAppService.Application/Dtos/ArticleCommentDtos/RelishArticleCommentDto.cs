using BlogAppService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Dtos.ArticleCommentDtos
{
    public class RelishArticleCommentDto
    {
        public string Id { get; set; }
        public RelishEnums RelishStatus { get; set; }
    }
}
