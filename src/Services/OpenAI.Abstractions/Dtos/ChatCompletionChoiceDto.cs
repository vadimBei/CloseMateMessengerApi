namespace OpenAI.Abstractions.Dtos
{
    public record ChatCompletionChoiceDto(
         int Index,
         ChatCompletionMessageDto Message,
         string FinishReason);
}
