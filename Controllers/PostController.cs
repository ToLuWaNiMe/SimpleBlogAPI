using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogAPI.DTOs;
using SimpleBlogAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Controllers
{
    [Authorize(Policy = "RequireLoggedIn")]
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
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            if (posts == null) // Handle potential null result from service layer
            {
                return StatusCode(500, "An error occurred while retrieving posts.");
            }
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPostById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid id provided.");
            }

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
            if (!ModelState.IsValid)
            { 
               return BadRequest(ModelState);
            }
            try
            {
                await _postService.CreatePostAsync(postDto);
                return CreatedAtAction(nameof(GetPostById), new { id = postDto.Id }, postDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(string id, [FromBody] PostDTO postDto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid post id provided.");
            }

            if (postDto == null)
            {
                return BadRequest("Post data cannot be empty.");
            }

            var post = await _postService.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            await _postService.UpdatePostAsync(id, postDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid post id provided.");
            }

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
