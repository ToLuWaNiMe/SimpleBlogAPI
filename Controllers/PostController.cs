using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogAPI.DTOs;
using SimpleBlogAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(string id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] PostDTO postDto)
        {
            await _postService.CreatePostAsync(postDto);
            return CreatedAtAction(nameof(GetPost), new { id = postDto.Id }, postDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(string id, [FromBody] PostDTO postDto)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            await _postService.UpdatePostAsync(id, postDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(string id)
        {
            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            await _postService.DeletePostAsync(id);
            return NoContent();
        }
    }
}
