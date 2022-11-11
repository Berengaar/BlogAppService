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
    public class ArticleRelishWriteRepository : WriteRepository<ArticleRelish>, IArticleRelishWriteRepository
    {
        public ArticleRelishWriteRepository(BlogAppServicePostgreSqlDbContext context) : base(context)
        {
        }
    }
}
