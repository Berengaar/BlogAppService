using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Domain.Entities
{
    public class Article
    {
        public string Id { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public IList<Comment> Comments { get; set; }
    }
}
