using SimpleBlogAPI.DTOs;
using SimpleBlogAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDTO>> GetCommentsByPostIdAsync(string postId);
        Task<CommentDTO> GetCommentByIdAsync(string id);
        Task<Comment> CreateCommentAsync(CommentDTO commentDto);
        Task UpdateCommentAsync(string id, CommentDTO commentDto);
        Task DeleteCommentAsync(string id);
    }
}
