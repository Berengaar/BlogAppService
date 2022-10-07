using BlogAppService.Application.Common.Repositories.CommentRepository;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories.CommentRepository
{
    public class CommentWriteRepository : WriteRepository<Comment>, ICommentWriteRepository
    {
        public CommentWriteRepository(BlogAppServicePostgreSqlDbContext context) : base(context)
        {
        }
    }
}
