using OpenAI.Interfaces.Dtos;

namespace OpenAI.Interfaces.Interfaces
{
    public interface IOpenAIService
    {
        Task<ChatCompletionDto> CreateChatCompletion(CreateChatCompletionDto dto, CancellationToken cancellationToken);
    }
}
