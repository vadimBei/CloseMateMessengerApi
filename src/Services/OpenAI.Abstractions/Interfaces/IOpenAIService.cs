using OpenAI.Abstractions.Dtos;

namespace OpenAI.Abstractions.Interfaces
{
    public interface IOpenAIService
    {
        Task<ChatCompletionDto> CreateChatCompletion(CreateChatCompletionDto dto, CancellationToken cancellationToken);
    }
}
