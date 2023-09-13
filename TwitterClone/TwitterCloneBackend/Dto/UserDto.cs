using TwitterCloneBackend.Models;

namespace TwitterCloneBackend.Dto
{
    public class UserDto
    {
        public string? Username { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Bio { get; set; }

        public List<Tweet> Tweets { get; set; }
        public List<Follow> Followers { get; set; }
        public List<Follow> Following { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
