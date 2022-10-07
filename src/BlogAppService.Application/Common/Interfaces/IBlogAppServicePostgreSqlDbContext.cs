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
        DbSet<Comment> Comments { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Relish> Relishes { get; set; }
    }
}
