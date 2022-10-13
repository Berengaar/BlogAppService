using BlogAppService.Application.Common.Interfaces;
using BlogAppService.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAppService.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AccountsController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel user)
        {
            var result = await _identityService.RegisterAsync(user);
            if (result.Succeeded)
            {
                return Created("~api/Accounts", user);
            }
            else if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return StatusCode(501);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            var result = await _identityService.LoginAsync(user);
            if (result.Item1.Succeeded)
            {
                return Ok(result.token);
            }
            else
            {
                return BadRequest(result.Item1.Errors);
            }
        }
    }
}
