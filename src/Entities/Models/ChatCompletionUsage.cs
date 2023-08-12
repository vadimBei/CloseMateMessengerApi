namespace Entities.Models
{
    public class ChatCompletionUsage
    {
        public long Id { get; set; }

        public int PromptTokens { get; set; }
        
        public int CompletionTokens { get; set; }

        public int TotalTokens { get; set; }

        public long ChatCompletionId { get; set; }
        public ChatCompletion ChatCompletion { get; set; }
    }
}
