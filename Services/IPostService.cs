using MongoDB.Bson;
using SimpleBlogAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Services
{
    public interface IPostService
    {
        Task<IEnumerable<PostDTO>> GetAllPostsAsync();
        Task<PostDTO> GetPostByIdAsync(string id);
        Task CreatePostAsync(PostDTO postDto);
        Task UpdatePostAsync(string id, PostDTO postDto);
        Task DeletePostAsync(string id);
    }
}
