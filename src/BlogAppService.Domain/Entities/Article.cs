using BlogAppService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }
        public AppUser? AppUser { get; set; }
        public string? AppUserId { get; set; }
        public IList<ArticleComment>? Comments { get; set; }
        public IList<ArticleRelish>? Relish { get; set; }
    }
}
