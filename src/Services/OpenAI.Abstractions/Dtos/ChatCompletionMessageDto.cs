namespace OpenAI.Abstractions.Dtos
{
    public record ChatCompletionMessageDto(
       string Role,
       string Content);
}
