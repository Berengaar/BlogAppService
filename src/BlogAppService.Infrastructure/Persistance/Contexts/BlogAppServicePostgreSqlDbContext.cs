using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Domain.Common;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Contexts
{
    public class BlogAppServicePostgreSqlDbContext : IdentityDbContext<AppUser, AppRole, string>, IBlogAppServicePostgreSqlDbContext
    {
        public BlogAppServicePostgreSqlDbContext(DbContextOptions<BlogAppServicePostgreSqlDbContext> options) : base(options)
        {

        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleRelish> ArticleRelishes { get; set; }
        public DbSet<ArticleComment> ArticleComment { get; set; }
        public DbSet<ArticleCommentRelish> ArticleCommentRelishes { get; set; }
        public DbSet<Category> Categories { get; set; }

        public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                data.Entity.Id = Guid.NewGuid().ToString();
            }
            return base.AddAsync(entity, cancellationToken);
        }
    }
}
