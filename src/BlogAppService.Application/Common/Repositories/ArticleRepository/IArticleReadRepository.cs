using BlogAppService.Application.Common.Pagination;
using BlogAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Common.Repositories.ArticleRepository
{
    public interface IArticleReadRepository : IReadRepository<Article>
    {
        Task<IList<Article>> GetAllWithPaginationAsync(Expression<Func<Article, bool>> predicate,PaginatedParameters paginatedParameters);
    }
}
