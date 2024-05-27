using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleBlogAPI.Models
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonElement("PostId")]
        public string PostId { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}