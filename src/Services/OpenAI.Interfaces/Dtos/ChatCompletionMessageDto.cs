namespace OpenAI.Interfaces.Dtos
{
    public record ChatCompletionMessageDto(
        string Role,
        string Content);
}
