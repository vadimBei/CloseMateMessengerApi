using Entities.Enums;

namespace ApplicationServices.Interfaces.Dtos
{
    public record CreateMessageDto(
        string IntegrationId,
        DateTime Created,
        string Content,
        ChatMessageRole Role,
        long ChatId);
}
