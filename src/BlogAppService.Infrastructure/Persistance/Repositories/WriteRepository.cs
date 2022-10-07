using BlogAppService.Application.Common.Repositories;
using BlogAppService.Domain.Common;
using BlogAppService.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly BlogAppServicePostgreSqlDbContext _context;

        public WriteRepository(BlogAppServicePostgreSqlDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
