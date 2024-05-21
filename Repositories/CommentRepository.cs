using MongoDB.Driver;
using SimpleBlogAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlogAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IMongoCollection<Comment> _comments;

        public CommentRepository(IMongoDatabase database)
        {
            _comments = database.GetCollection<Comment>("Comments");
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(string postId)
        {
            return await _comments.Find(comment => comment.PostId == postId).ToListAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(string id)
        {
            return await _comments.Find(comment => comment.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            await _comments.InsertOneAsync(comment);
        }

        public async Task UpdateCommentAsync(string id, Comment comment)
        {
            await _comments.ReplaceOneAsync(c => c.Id == id, comment);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _comments.DeleteOneAsync(comment => comment.Id == id);
        }
    }
}
