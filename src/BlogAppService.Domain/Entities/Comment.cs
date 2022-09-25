using BlogAppService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Domain.Entities
{
    public class Comment:BaseEntity
    {
        public string Content { get; set; }
        public string ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
