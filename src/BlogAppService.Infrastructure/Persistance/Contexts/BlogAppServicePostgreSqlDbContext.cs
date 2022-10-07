using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Contexts
{
    public class BlogAppServicePostgreSqlDbContext : IBlogAppServicePostgreSqlDbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Relish> Relishes { get; set; }
    }
}
