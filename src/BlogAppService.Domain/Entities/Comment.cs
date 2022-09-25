using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Domain.Entities
{
    public class Comment
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
