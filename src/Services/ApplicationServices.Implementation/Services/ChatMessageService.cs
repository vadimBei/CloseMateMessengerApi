using ApplicationServices.Interfaces.Dtos;
using ApplicationServices.Interfaces.Interfaces;
using Entities.Models;
using Infrastructure.Interfaces;

namespace ApplicationServices.Implementation.Services
{
    public class ChatMessageService : IChatMessageService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ChatMessageService(
            IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ChatMessage> CreateMessage(CreateMessageDto dto, CancellationToken cancellationToken)
        {
            var entity = new ChatMessage()
            {
                IntegrationId = dto.IntegrationId,
                Created = dto.Created,
                Content = dto.Content,
                Role = dto.Role,
                ChatId = dto.ChatId
            };

            _applicationDbContext.ChatMessages.Add(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
