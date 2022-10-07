using BlogAppService.Infrastructure.Identity;
using BlogAppService.Infrastructure.Persistance.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Infrastructure.Persistance
{
    public static class DbRegistration
    {
        public static void AddDbServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<BlogAppServicePostgreSqlDbContext>(options => options.UseNpgsql(configuration["PostgreSql:ConnectionStrings"]));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BlogAppServicePostgreSqlDbContext>().AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
            });
        }
    }
}
