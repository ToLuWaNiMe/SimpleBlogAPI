namespace SimpleBlogAPI.DTOs
{
    public class CommentDTO
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
