using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SimpleBlogAPI.DTOs
{
    public class CommentDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PostId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
