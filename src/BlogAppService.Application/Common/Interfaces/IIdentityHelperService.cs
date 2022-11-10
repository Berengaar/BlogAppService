using BlogAppService.Application.Dtos.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppService.Application.Common.Interfaces
{
    public interface IIdentityHelperService
    {
        Task<IdentityModelDto> GetIdentityModel(string email);
    }
}
