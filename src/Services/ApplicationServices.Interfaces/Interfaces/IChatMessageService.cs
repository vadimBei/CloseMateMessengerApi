using ApplicationServices.Interfaces.Dtos;
using Entities.Models;

namespace ApplicationServices.Interfaces.Interfaces
{
    public interface IChatMessageService
    {
        Task<ChatMessage> CreateMessage(CreateMessageDto dto, CancellationToken cancellationToken);
    }
}
