using SimpleBlogAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(string postId);
        Task<Comment> GetCommentByIdAsync(string id);
        Task CreateCommentAsync(Comment comment);
        Task UpdateCommentAsync(string id, Comment comment);
        Task DeleteCommentAsync(string id);
    }
}

