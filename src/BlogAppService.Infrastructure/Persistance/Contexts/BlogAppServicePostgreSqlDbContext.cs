using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Relish> Relishes { get; set; }
    }
}
