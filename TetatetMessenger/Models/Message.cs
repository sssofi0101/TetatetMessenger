namespace TetatetMessenger_API.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }  

        public Guid UserId { get; set; } //автор
        public User User { get; set; }  

        public string Content { get; set; }
        public DateTime Time { get; set; }
    }
}
