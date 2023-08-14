using Entities.Enums;

namespace Entities.Models
{
    public class ChatCompletionMessage
    {
        public long Id { get; set; }

        public string IntegrationId { get; set; }

        public DateTime Created { get; set; }

        public string Content { get; set; }

        public ChatMessageRole Role { get; set; }

        public long ChatCompletionId { get; set; }
        public ChatCompletion ChatCompletion { get; set; }
    }
}
