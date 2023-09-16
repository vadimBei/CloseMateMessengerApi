using Entities.Models;

namespace ApplicationServices.Abstractions.Interfaces
{
    public interface IChatService
    {
        Task<Chat> GetChatById(long id, CancellationToken cancellationToken);

        Task<ChatMessage> GetLastChatMessage(long id, CancellationToken cancellationToken);
    }
}
