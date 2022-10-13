using BlogAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Common.Repositories.ArticleCommentRepository
{
    public interface IArticleCommentReadRepository : IReadRepository<ArticleComment>
    {
    }
}
