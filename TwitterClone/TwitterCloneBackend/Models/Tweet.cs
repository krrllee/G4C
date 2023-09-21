using System.ComponentModel.DataAnnotations;

namespace TwitterCloneBackend.Models
{
    public class Tweet
    {
        [Required]
        public int Id { get; set; }
        public string? Content { get;set;}

        public DateTime? Created { get; set; }

        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public User? User { get; set; }

        public int LikesCount { get; set; }
        public List<Like>? Likes { get; set; }
        public List<Comment>? Comments { get; set; }

        public Tweet? Retweeted { get; set; }
        public List<Tweet>? Retweetes { get; set; }
    }
}
