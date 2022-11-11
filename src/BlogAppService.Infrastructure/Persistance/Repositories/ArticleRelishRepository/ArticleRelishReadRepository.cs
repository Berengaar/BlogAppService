using BlogAppService.Application.Common.Repositories.RelishRepository;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories.ArticleRelishRepository
{
    public class ArticleRelishReadRepository : ReadRepository<ArticleRelish>, IArticleRelishReadRepository
    {
        public ArticleRelishReadRepository(BlogAppServicePostgreSqlDbContext context) : base(context)
        {
        }
    }
}
