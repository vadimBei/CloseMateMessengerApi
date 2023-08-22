namespace OpenAI.Interfaces.Dtos
{
    public class CreateChatCompletionDto
    {
        public IEnumerable<CompletionMessageDto> Messages { get; set; }
    }
}
