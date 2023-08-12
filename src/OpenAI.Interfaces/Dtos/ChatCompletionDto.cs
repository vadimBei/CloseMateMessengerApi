namespace OpenAI.Interfaces.Dtos
{
    public record ChatCompletionDto(
        string Id, 
        string Object, 
        long Created, 
        string Model, 
        ChatCompletionUsageDto Usage, 
        IEnumerable<ChatCompletionChoiceDto> Choices);
}
