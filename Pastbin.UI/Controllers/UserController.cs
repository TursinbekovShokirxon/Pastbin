using Microsoft.AspNetCore.Mvc;
using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
using Pastbin.Domain.Models.DTO;

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
        public async Task<IActionResult> CreateAsync(UserCreateDTO userCreateDTO)
        {
            if (userCreateDTO == null) { return BadRequest("User is null"); }
            var hasInDb=await _userService.GetByUsername(userCreateDTO.Username);
            if (hasInDb!=null) { return BadRequest("User has in Db"); }
            User newUser=new User() { 
            Username= userCreateDTO.Username,
            Password= userCreateDTO.Password
            };
            var response = await _userService.CreateAsync(newUser);
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Users=await _userService.GetAllAsync();
            return Ok(Users);
        }

    }
}
