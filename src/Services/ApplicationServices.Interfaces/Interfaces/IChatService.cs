using Entities.Models;

namespace ApplicationServices.Interfaces.Interfaces
{
    public interface IChatService
    {
        Task<Chat> GetChatById(long id, CancellationToken cancellationToken);

        Task<ChatMessage> GetLastChatMessage(long id, CancellationToken cancellationToken);
    }
}
