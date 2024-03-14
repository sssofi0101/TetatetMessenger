using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TetatetMessenger_API.Models;

namespace TetatetMessenger_API.Controllers
{
    [Route("api/Messages")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessengerContext _context;

        public MessagesController(MessengerContext context)
        {
            _context = context;
        }

        // POST: api/Messages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(MessageApi message)
        {
            var m = new Message(message.ChatId, message.UserId, message.Content, message.Time);
            var user = _context.Users.Where(u => u.Id == m.UserId).FirstOrDefault();
            var chat = _context.Chats.Where(c => c.Id == m.ChatId).FirstOrDefault();
            var newMessage =_context.Messages.Add(new Message(m.ChatId,chat,m.UserId, user,m.Content,m.Time));
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMessage), new { id = newMessage.Entity.Id }, message);

        }
        [HttpGet("message/{id}")]
        internal async Task<ActionResult<Message>> GetMessage(Guid id)
        {
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // GET: api/Messages/bhkbnuh676-bhuyg
        [HttpGet("{chatId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages(Guid chatId)
        {
            return await _context.Messages.Where(i => i.ChatId == chatId).ToListAsync();
        }

        // PUT: api/Messages/bhkbnuh676-bhuyg
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessage(Guid id, MessageApi message)
        {
            var oldMessage = _context.Messages.FirstOrDefault(c => c.Id == id);
            if (oldMessage == null)
            {
                return BadRequest();
            }
            var newMessage = oldMessage;
            newMessage.Time = message.Time;
            newMessage.Content = message.Content;

            _context.Entry(newMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        

        // DELETE: api/UserChats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(Guid id)
        {
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(Guid id)
        {
            return _context.Messages.Any(e => e.Id == id);
        }
    }
}
