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
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("post/{postId}")]
        public async Task<ActionResult<IEnumerable<CommentDTO>>> GetCommentsByPostId(string postId)
        {
            var comments = await _commentService.GetCommentsByPostIdAsync(postId);
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDTO>> GetComment(string id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment([FromBody] CommentDTO commentDto)
        {
            await _commentService.CreateCommentAsync(commentDto);
            return CreatedAtAction(nameof(GetComment), new { id = commentDto.Id }, commentDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateComment(string id, [FromBody] CommentDTO commentDto)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            await _commentService.UpdateCommentAsync(id, commentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(string id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }
    }
}
