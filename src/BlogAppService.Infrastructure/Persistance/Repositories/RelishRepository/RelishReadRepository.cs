using BlogAppService.Application.Common.Repositories.RelishRepository;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories.RelishRepository
{
    public class RelishReadRepository : ReadRepository<Relish>, IRelishReadRepository
    {
        public RelishReadRepository(BlogAppServicePostgreSqlDbContext context) : base(context)
        {
        }
    }
}
