namespace TetatetMessenger_API.Models
{
    public class MessageApi
    {
        public Guid ChatId { get; set; }

        public Guid UserId { get; set; } //автор

        public required string Content { get; set; }
        public DateTime Time { get; set; }
    }
}
