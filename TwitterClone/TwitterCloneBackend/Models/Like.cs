using System.ComponentModel.DataAnnotations;

namespace TwitterCloneBackend.Models
{
    public class Like
    {
        [Required]
        public int Id { get; set; }
        public int? TweetId { get; set; }
        public Tweet? Tweet { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
