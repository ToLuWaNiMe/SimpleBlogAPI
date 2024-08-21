using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SimpleBlogAPI.DTOs;
using SimpleBlogAPI.Services;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Controllers
{
    [Authorize(Policy = "RequireLoggedIn")]
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetAllPosts()
        {
            var posts = await _postService.GetAllPostsAsync();
            if (posts == null)
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

        [Authorize(Policy = "RequireLoggedIn")]
        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] PostDTO postDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                postDto.Id = ObjectId.GenerateNewId().ToString();
                await _postService.CreatePostAsync(postDto);
                return CreatedAtAction(nameof(GetPostById), new { id = postDto.Id }, postDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [Authorize(Policy = "RequireLoggedIn")]
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

        [Authorize(Policy = "RequireLoggedIn")]
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
