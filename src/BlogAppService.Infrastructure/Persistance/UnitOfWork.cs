using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Common.Repositories.ArticleCommentRepository;
using BlogAppService.Application.Common.Repositories.ArticleRepository;
using BlogAppService.Application.Common.Repositories.CategoryRepository;
using BlogAppService.Application.Common.Repositories.RelishRepository;
using BlogAppService.Infrastructure.Identity;
using BlogAppService.Infrastructure.Persistance.Contexts;
using BlogAppService.Infrastructure.Persistance.Repositories.ArticleCommentRepository;
using BlogAppService.Infrastructure.Persistance.Repositories.ArticleRelishRepository;
using BlogAppService.Infrastructure.Persistance.Repositories.ArticleRepository;
using BlogAppService.Infrastructure.Persistance.Repositories.CategoryRepository;
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
        private ArticleRelishReadRepository _articleRelishReadRepository;
        private ArticleRelishWriteRepository _articleRelishWriteRepository;
        private CategoryReadRepository _categoryReadRepository;
        private CategoryWriteRepository _categoryWriteRepository;
        private IdentityHelperService _identityHelper;
        public UnitOfWork(BlogAppServicePostgreSqlDbContext context)
        {
            _context = context;
        }
        public IArticleReadRepository ArticleReadRepository => _articleReadRepository ?? (_articleReadRepository = new ArticleReadRepository(_context));

        public IArticleWriteRepository ArticleWriteRepository => _articleWriteRepository ?? (_articleWriteRepository = new ArticleWriteRepository(_context));

        public IArticleCommentReadRepository ArticleCommentReadRepository => _articleCommentReadRepository ?? (_articleCommentReadRepository = new ArticleCommentReadRepository(_context));

        public IArticleCommentWriteRepository ArticleCommentWriteRepository => _articleCommentWriteRepository ?? (_articleCommentWriteRepository = new ArticleCommentWriteRepository(_context));

        public ICategoryReadRepository CategoryReadRepository => _categoryReadRepository ?? (_categoryReadRepository = new CategoryReadRepository(_context));

        public ICategoryWriteRepository CategoryWriteRepository => _categoryWriteRepository ?? (_categoryWriteRepository = new CategoryWriteRepository(_context));

        public IArticleRelishReadRepository ArticleRelishReadRepository => _articleRelishReadRepository ?? (_articleRelishReadRepository = new ArticleRelishReadRepository(_context));

        public IArticleRelishWriteRepository ArticleRelishWriteRepository => _articleRelishWriteRepository ?? (_articleRelishWriteRepository = new ArticleRelishWriteRepository(_context));
        public IIdentityHelperService IdentityHelperService => _identityHelper ?? (_identityHelper = new IdentityHelperService(_context));

    }
}
