using BlogAppService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Domain.Entities
{
    public class ArticleComment: BaseEntity
    {
        public string Content { get; set; }
        public string ArticleId { get; set; }
        public Article Article { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public IList<ArticleCommentRelish> ArticleCommentRelishes { get; set; }
    }
}
