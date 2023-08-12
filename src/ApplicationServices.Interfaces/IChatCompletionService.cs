using Entities.Models;

namespace ApplicationServices.Interfaces
{
    public interface IChatCompletionService
    {
        Task<ChatCompletion> GetChatCompletionById(long id, CancellationToken  cancellationToken);
    }
}
