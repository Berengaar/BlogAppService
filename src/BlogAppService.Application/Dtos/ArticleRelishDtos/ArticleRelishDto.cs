using BlogAppService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Dtos.ArticleRelishDtos
{
    public class ArticleRelishDto
    {
        public int RelishStatus { get; set; }
        public string UserName { get; set; }
    }
}
