namespace TetatetMessenger_API.Models
{
    public class UserChat
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // участник
        public User User { get; set; }
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; } 
    }
}
