using ApplicationServices.Abstractions.Dtos;
using Entities.Models;

namespace ApplicationServices.Abstractions.Interfaces
{
    public interface IChatMessageService
    {
        Task<ChatMessage> CreateMessage(CreateMessageDto dto, CancellationToken cancellationToken);
    }
}
