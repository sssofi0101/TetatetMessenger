using TetatetMessenger_API.Models;

namespace TetatetMessenger_API
{
    public static class SampleData
    {
        public static void Initialize(MessengerContext context)
        {
            Chat? chat = null;
            User? user1 = null;
            User? user2 = null;
            if (!context.Users.Any()) 
            {
                context.Users.Add(new User("user1", "user1","Иван", "Иванов","Курск"));
                context.Users.Add(new User("user2", "user2", "Петр","Петров","Москва"));
                user1 = context.Users.Where(u => u.Nickname == "user1" && u.Password == "user1").FirstOrDefault();
                user2 = context.Users.Where(u => u.Nickname == "user2" && u.Password == "user2").FirstOrDefault();
            }
            if (!context.Chats.Any())
            {
                context.Chats.Add(new Chat());
                chat = context.Chats.FirstOrDefault();
            }

            if (!context.UsersChats.Any())
            {
                if (user1 != null && user2 != null && chat != null) 
                {
                    context.UsersChats.Add(new UserChat(user1.Id, chat.Id));
                    context.UsersChats.Add(new UserChat(user2.Id, chat.Id));
                }
            }
            if (!context.Messages.Any())
            {
                if (user1 != null && user2 != null && chat != null)
                {
                    context.Messages.Add(new Message(chat.Id,user1.Id,"Привет, Петр", DateTime.Now));
                    context.Messages.Add(new Message(chat.Id, user2.Id, "Привет, Иван", DateTime.Now));
                }
            }

        }
    }
}
