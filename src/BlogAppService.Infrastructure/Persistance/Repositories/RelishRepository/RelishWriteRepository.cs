﻿using BlogAppService.Application.Common.Repositories.RelishRepository;
using BlogAppService.Domain.Entities;
using BlogAppService.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.Repositories.RelishRepository
{
    public class RelishWriteRepository : WriteRepository<Relish>, IRelishWriteRepository
    {
        public RelishWriteRepository(BlogAppServicePostgreSqlDbContext context) : base(context)
        {
        }
    }
}