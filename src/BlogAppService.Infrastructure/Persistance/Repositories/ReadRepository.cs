using BlogAppService.Application.Common.Repositories;
using BlogAppService.Domain.Common;
using BlogAppService.Domain.Entities;
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

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = Table.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                    //
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        //public async Task<T> FindAsync(Expression<Func<T, bool>> predicate) => await Table.AsNoTracking().FirstOrDefaultAsync(predicate);


        public async Task<IList<T>> GetAllAsync() => await Table.AsNoTracking().ToListAsync();


        public async Task<IList<T>> GetWhereAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = Table.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                    //
                }
            }
            return await query.AsNoTracking().ToListAsync();
        }

    }
}
