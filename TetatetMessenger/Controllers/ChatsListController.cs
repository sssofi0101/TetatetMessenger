using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TetatetMessenger_API.Models;

namespace TetatetMessenger_API.Controllers
{
    [Route("api/ChatsList")]
    [ApiController]
    public class ChatsListController : ControllerBase
    {
        private readonly MessengerContext _context;
        public ChatsListController(MessengerContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<UserChat>>> GetChats(Guid userId)
        {
            return await _context.UsersChats
            .Where(c => c.UserId == userId)
            .ToListAsync();
        }

        [HttpGet("{userId}/{nickname}")]
        public async Task<ActionResult<IEnumerable<UserChat>>> GetChatsByNickname(Guid userId, string nickname)
        {
            var userChats = _context.UsersChats.Where(c => c.UserId == userId).Distinct().ToList();
            List<UserChat> nicknameChats = new List<UserChat>();
            for (int i = 0; i < userChats.Count; i++)
            {
                var chats = _context.UsersChats.Where(c => c.ChatId == userChats[i].ChatId && c.UserId != userId).Distinct().ToList();
                for (int j = 0; j < chats.Count; j++)
                {
                    nicknameChats.Add(chats[j]);
                }
            }
            return nicknameChats;
        }
    }
}
