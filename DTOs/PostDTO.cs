using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleBlogAPI.DTOs
{
    public class PostDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
