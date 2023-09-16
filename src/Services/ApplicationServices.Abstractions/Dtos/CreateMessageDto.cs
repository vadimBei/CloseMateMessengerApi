using Entities.Enums;

namespace ApplicationServices.Abstractions.Dtos
{
    public record CreateMessageDto(
        string IntegrationId,
        DateTime Created,
        string Content,
        ChatMessageRole Role,
        long ChatId);
}
