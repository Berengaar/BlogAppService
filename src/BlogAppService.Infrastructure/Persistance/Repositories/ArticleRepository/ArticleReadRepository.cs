using BlogAppService.Application.Common.Repositories.ArticleRepository;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories.ArticleRepository
{
    public class ArticleReadRepository : ReadRepository<Article>, IArticleReadRepository
    {
        public ArticleReadRepository(BlogAppServicePostgreSqlDbContext context) : base(context)
        {
        }
    }
}
