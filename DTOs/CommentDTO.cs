namespace BookWormProject.DTOs
{
    public class CommentDTO
    {
        public int CommentId { get; set; }

        public UserDTO User { get; set; }

        public string Content { get; set; } = null!;

        public DateTime CreatedAt { get; set; }
        public string TimeAgo { get; set; }
    }
}
