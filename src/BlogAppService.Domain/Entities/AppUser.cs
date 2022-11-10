using BlogAppService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Domain.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Article> Articles { get; set; }
        public IList<ArticleComment> ArticleComments { get; set; }
        public IList<ArticleRelish> ArticleRelishes { get; set; }
    }
}
