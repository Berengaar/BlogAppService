using BlogAppService.Application.Common.Repositories.ArticleCommentRepository;
using BlogAppService.Application.Common.Repositories.ArticleRepository;
using BlogAppService.Application.Common.Repositories.CategoryRepository;
using BlogAppService.Application.Common.Repositories.RelishRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        IArticleReadRepository ArticleReadRepository { get; }
        IArticleWriteRepository ArticleWriteRepository { get; }
        IArticleCommentReadRepository ArticleCommentReadRepository { get; }
        IArticleCommentWriteRepository ArticleCommentWriteRepository { get; }
        IArticleRelishReadRepository ArticleRelishReadRepository { get; }
        IArticleRelishWriteRepository ArticleRelishWriteRepository { get; }
        ICategoryReadRepository CategoryReadRepository { get; }
        ICategoryWriteRepository CategoryWriteRepository { get; }
        IIdentityHelperService IdentityHelperService { get; }
    }
}
