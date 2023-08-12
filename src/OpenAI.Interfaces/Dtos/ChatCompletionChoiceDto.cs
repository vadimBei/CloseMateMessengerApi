namespace OpenAI.Interfaces.Dtos
{
    public record ChatCompletionChoiceDto(
        int Index, 
        ChatCompletionMessageDto Message, 
        string FinishReason);
}
