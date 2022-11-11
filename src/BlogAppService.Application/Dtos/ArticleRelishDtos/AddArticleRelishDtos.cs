using BlogAppService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Dtos.ArticleRelishDtos
{
    public class AddArticleRelishDto
    {
        public string ArticleId { get; set; }
        public RelishEnums RelishEnums { get; set; }
    }
}
