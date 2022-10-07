using BlogAppService.Application.Common.Repositories;
using BlogAppService.Application.Common.Repositories.CategoryRepository;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories.CategoryRepository
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(BlogAppServicePostgreSqlDbContext context) : base(context)
        {
        }
    }
}
