using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Dtos.ArticleCommentDtos
{
    public class UpdateArticleCommentDto : ArticleCommentDto
    {
        public string Id { get; set; }
    }
}
