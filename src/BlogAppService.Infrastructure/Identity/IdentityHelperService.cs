using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Dtos.Identity;
using BlogAppService.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Identity
{
    public class IdentityHelperService : IIdentityHelperService
    {
        private readonly BlogAppServicePostgreSqlDbContext _context;

        public IdentityHelperService(BlogAppServicePostgreSqlDbContext context)
        {
            _context = context;
        }

        public async Task<IdentityModelDto> GetIdentityModel(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(s => s.Email == email);
            if (user == null) return null;
            IdentityModelDto userModel = new()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return userModel;
        }
    }
}
