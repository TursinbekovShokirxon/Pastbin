using Microsoft.AspNetCore.Mvc;
using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;

namespace Pastbin.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(User user)
        {
            if (user == null) { return BadRequest("User is null"); }
            var response = await _userService.CreateAsync(user);

            return Ok(response);
        }
    }
}
