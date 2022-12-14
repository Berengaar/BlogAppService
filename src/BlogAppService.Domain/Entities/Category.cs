using BlogAppService.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public IList<Article> Articles { get; set; }
    }
}
