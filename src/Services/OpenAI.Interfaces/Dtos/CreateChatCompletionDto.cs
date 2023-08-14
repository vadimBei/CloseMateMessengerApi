namespace OpenAI.Interfaces.Dtos
{
    public record CreateChatCompletionDto( 
        IEnumerable<CompletionMessageDto> Messages);
}
