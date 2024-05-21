using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SimpleBlogAPI.Models
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Content")]
        public string Content { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement("Comments")]
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

}