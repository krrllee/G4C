namespace TwitterCloneBackend.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public bool? IsRead { get; set; }   
        public DateTime? Created { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }



    }
}
