using MongoDB.Bson;
using MongoDB.Driver;
using SimpleBlogAPI.Models;
using SimpleBlogAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IMongoCollection<Post> _posts;

        public PostRepository(IMongoClient mongoClient, IMongoDBSettings settings)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _posts = database.GetCollection<Post>("Posts");
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _posts.Find(post => true).ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(string id)
        {
            return await _posts.Find(post => post.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreatePostAsync(Post post)
        {
            await _posts.InsertOneAsync(post);
        }

        public async Task UpdatePostAsync(string id, Post post)
        {
            await _posts.ReplaceOneAsync(p => p.Id == id, post);
        }

        public async Task DeletePostAsync(string id)
        {
            await _posts.DeleteOneAsync(post => post.Id == id);
        }
    }
}
