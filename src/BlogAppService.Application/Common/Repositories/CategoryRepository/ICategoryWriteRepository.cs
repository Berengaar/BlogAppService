using BlogAppService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Common.Repositories.CategoryRepository
{
    public interface ICategoryWriteRepository : IWriteRepository<Category>
    {
    }
}
