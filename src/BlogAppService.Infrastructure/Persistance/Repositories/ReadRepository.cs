using BlogAppService.Application.Common.Repositories;
using BlogAppService.Domain.Common;
using BlogAppService.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly BlogAppServicePostgreSqlDbContext _context;

        public ReadRepository(BlogAppServicePostgreSqlDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate) => await Table.AsNoTracking().FirstOrDefaultAsync(predicate);


        public async Task<IList<T>> GetAllAsync() => await Table.AsNoTracking().ToListAsync();


        public async Task<IList<T>> GetWhereAsync(Expression<Func<T, bool>> predicate) => await Table.AsNoTracking().Where(predicate).ToListAsync();

    }
}
