using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Common.Repositories.ArticleCommentRepository;
using BlogAppService.Application.Common.Repositories.ArticleRepository;
using BlogAppService.Infrastructure.Persistance.Contexts;
using BlogAppService.Infrastructure.Persistance.Repositories.ArticleCommentRepository;
using BlogAppService.Infrastructure.Persistance.Repositories.ArticleRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogAppServicePostgreSqlDbContext _context;
        private ArticleReadRepository _articleReadRepository;
        private ArticleWriteRepository _articleWriteRepository;
        private ArticleCommentReadRepository _articleCommentReadRepository;
        private ArticleCommentWriteRepository _articleCommentWriteRepository;
        public UnitOfWork(BlogAppServicePostgreSqlDbContext context)
        {
            _context = context;
        }
        public IArticleReadRepository ArticleReadRepository => _articleReadRepository ?? (_articleReadRepository = new ArticleReadRepository(_context));

        public IArticleWriteRepository ArticleWriteRepository => _articleWriteRepository ?? (_articleWriteRepository = new ArticleWriteRepository(_context));

        public IArticleCommentReadRepository ArticleCommentReadRepository => _articleCommentReadRepository ?? (_articleCommentReadRepository = new ArticleCommentReadRepository(_context));

        public IArticleCommentWriteRepository ArticleCommentWriteRepository => _articleCommentWriteRepository ?? (_articleCommentWriteRepository = new ArticleCommentWriteRepository(_context));
    }
}
