using BlogAppService.Application.Common.Pagination;
using BlogAppService.Application.Common.Repositories.ArticleRepository;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories.ArticleRepository
{
    public class ArticleReadRepository : ReadRepository<Article>, IArticleReadRepository
    {
        private readonly BlogAppServicePostgreSqlDbContext _context;
        public ArticleReadRepository(BlogAppServicePostgreSqlDbContext context) : base(context) => _context = context;


        public async Task<IList<Article>> GetAllWithPaginationAsync(Expression<Func<Article, bool>> predicate, PaginatedParameters paginatedParameters)
        {
            var list = await Task.Run(() => _context.Articles.Where(predicate));
            var result = PaginatedList<Article>.ToPagedList(list, paginatedParameters);
            return result;
        }
    }
}
