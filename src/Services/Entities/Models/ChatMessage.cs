using Entities.Enums;

namespace Entities.Models
{
    public class ChatMessage
    {
        public long Id { get; set; }

        public string IntegrationId { get; set; }

        public DateTime Created { get; set; }

        public string Content { get; set; }

        public ChatMessageRole Role { get; set; }

        public long ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
