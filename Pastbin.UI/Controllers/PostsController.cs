using Microsoft.AspNetCore.Mvc;
using Pastbin.Application.Interfaces;
using Pastbin.Domain.Entities;
using Pastbin.Domain.Models.DTO;

namespace Pastbin.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostsController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        public PostsController(IUserService _userService, IPostService postService)
        {
            this._userService = _userService;
            _postService = postService;

        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDTO postDTO)
        {
            User user = await _userService.GetByUsername(postDTO.UserName);

            if (user == null) return NotFound($"User {postDTO.UserName} not found");

            Post post=new Post() 
            {
            ExpireHour = postDTO.ExpireHour,
            User= user,
            };
           var response = await _postService.CreateAsync(post,postDTO.Text);
            return Ok($"File {response.HashUrl}");
        }

    }
}
