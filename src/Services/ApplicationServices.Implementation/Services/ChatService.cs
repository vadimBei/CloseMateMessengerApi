using ApplicationServices.Interfaces.Interfaces;
using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Utils.Exceptions;

namespace ApplicationServices.Implementation.Services
{
    public class ChatService : IChatService
    {
        private readonly IReadOnlyApplicationDbContext _readOnlyApplicationDbContext;

        public ChatService(
            IReadOnlyApplicationDbContext readOnlyApplicationDbContext)
        {
            _readOnlyApplicationDbContext = readOnlyApplicationDbContext;
        }

        public async Task<Chat> GetChatById(long id, CancellationToken cancellationToken)
        {
            var entity = await _readOnlyApplicationDbContext.Chats
               .AsNoTracking()
               .Include(x => x.Messages)
               .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(Chat), id);
            }

            entity.Messages = entity.Messages
                .OrderBy(x => x.Created)
                .ToList();

            return entity;
        }

        public async Task<ChatMessage> GetLastChatMessage(long id, CancellationToken cancellationToken)
        {
            var chat = await this.GetChatById(id, cancellationToken);

            var lastMessage = chat.Messages
                .OrderByDescending(x => x.Created)
                .FirstOrDefault();

            return lastMessage;
        }
    }
}
