using BlogAppService.Application.Models.Identity;
using BlogAppService.Application.Models.ResultType;
using BlogAppService.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(Result, string token)> LoginAsync(LoginModel loginModel);
        Task<Result> RegisterAsync(RegisterModel registerModel, string role = UserRoles.User);
        Task<Result> RegisterAdminAsync(RegisterModel registerModel, string role = UserRoles.Admin);
    }
}
