using MongoDB.Bson;
using SimpleBlogAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetPostByIdAsync(string id);
        Task CreatePostAsync(Post post);
        Task UpdatePostAsync(string id, Post post);
        Task DeletePostAsync(string id);
    }
}
