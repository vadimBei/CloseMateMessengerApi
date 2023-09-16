namespace OpenAI.Abstractions.Dtos
{
    public class CreateChatCompletionDto
    {
        public IEnumerable<CompletionMessageDto> Messages { get; set; }
    }
}
