using BlogAppService.Application.Common.Pagination;
using BlogAppService.Application.Common.Repositories.ArticleRepository;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
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


        public async Task<IList<Article>> GetAllWithPaginationAsync(PaginatedParameters paginatedParameters, Expression<Func<Article, bool>> predicate = null, params Expression<Func<Article, object>>[] includeProperties)
        {
            IQueryable<Article> query = _context.Articles;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            var result = PaginatedList<Article>.ToPagedList(query, paginatedParameters);
            return result;
        }
    }
}
