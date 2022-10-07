using BlogAppService.Application.Common.Repositories;
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
    public class ArticleWriteRepository : WriteRepository<Article>, IArticleWriteRepository
    {
        public ArticleWriteRepository(BlogAppServicePostgreSqlDbContext context) : base(context)
        {
        }
    }
}
