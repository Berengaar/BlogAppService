using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Dtos.ArticleDtos
{
    public class UpdateArticleDto : ArticleDto
    {
        public string Id { get; set; }
    }
}
