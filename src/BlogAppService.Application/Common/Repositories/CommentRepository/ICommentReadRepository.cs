using BlogAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Common.Repositories.CommentRepository
{
    public interface ICommentReadRepository : IReadRepository<ArticleComment>
    {
    }
}
