using BlogAppService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Domain.Entities
{
    public class ArticleCommentRelish : BaseEntity
    {
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public string ArticleCommentId { get; set; }
        public ArticleComment ArticleComment { get; set; }
        public RelishEnums RelishEnums { get; set; }
    }
}
