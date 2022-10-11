using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Common.Repositories.ArticleRepository;
using BlogAppService.Application.Common.Repositories.CategoryRepository;
using BlogAppService.Application.Common.Repositories.CommentRepository;
using BlogAppService.Application.Common.Repositories.RelishRepository;
using BlogAppService.Infrastructure.Identity;
using BlogAppService.Infrastructure.Persistance.Repositories.ArticleRepository;
using BlogAppService.Infrastructure.Persistance.Repositories.CategoryRepository;
using BlogAppService.Infrastructure.Persistance.Repositories.CommentRepository;
using BlogAppService.Infrastructure.Persistance.Repositories.RelishRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance.DIContainer
{
    public static class DIServiceRegistration
    {
        public static void AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICommentReadRepository, CommentReadRepository>();
            services.AddScoped<ICommentWriteRepository, CommentWriteRepository>();
            services.AddScoped<IRelishReadRepository, RelishReadRepository>();
            services.AddScoped<IRelishWriteRepository, RelishWriteRepository>();
            services.AddScoped<IArticleReadRepository, ArticleReadRepository>();
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
