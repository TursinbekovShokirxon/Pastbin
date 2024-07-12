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
            return Ok(response.HashUrl);
        }

        [HttpGet("{keyword}")]
        public async Task<IActionResult> GetUrlsForKeyword(string keyword)
        {
            var posts =  _postService.GetAllAsync().Result.ToList();
                var urls= posts.Where(k => k.HashUrl == keyword)
                        .Select(k =>k.UrlAWS)
                        .ToList();

            if (urls == null || urls.Count == 0)
            {
                return NotFound();
            }

            return Ok(urls);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFromUsernameAsync(string Username)
        {
            var Posts=await _postService.GetAllFromUsernameAsync(Username);
            if(Posts==null) return NotFound("in db not exist");
            return Ok(Posts);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(_postService.GetAllAsync());
        }
    }
}
