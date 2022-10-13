using BlogAppService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Common.Interfaces
{
    public interface IBlogAppServicePostgreSqlDbContext
    {
        DbSet<Article> Articles { get; set; }
        DbSet<ArticleRelish> ArticleRelishes { get; set; }
        DbSet<ArticleComment> ArticleComment { get; set; }
        DbSet<ArticleCommentRelish> ArticleCommentRelishes { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
