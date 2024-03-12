using Microsoft.EntityFrameworkCore;

namespace TetatetMessenger_API.Models
{
    public class MessengerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserChat> UsersChats { get; set; }
        public MessengerContext(DbContextOptions<MessengerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
