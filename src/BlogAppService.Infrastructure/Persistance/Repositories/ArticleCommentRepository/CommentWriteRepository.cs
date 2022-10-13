using BlogAppService.Application.Common.Repositories.ArticleCommentRepository;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories.ArticleCommentRepository
{
    public class ArticleCommentWriteRepository : WriteRepository<ArticleComment>, IArticleCommentWriteRepository
    {
        public ArticleCommentWriteRepository(BlogAppServicePostgreSqlDbContext context) : base(context)
        {
        }
    }
}
