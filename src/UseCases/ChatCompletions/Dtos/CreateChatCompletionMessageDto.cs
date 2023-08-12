using Entities.Enums;

namespace UseCases.ChatCompletions.Dtos
{
    public record CreateChatCompletionMessageDto(
        string IntegrationId,
        DateTime Created,
        string Content,
        ChatMessageRole Role,
        long ChatCompletionId);
}
