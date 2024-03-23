using Entities.Enums;
using Entity.Abstractions.Interfaces;

namespace Entities.Models
{
    public class ChatMessage : ISoftDeletable
    {
        public long Id { get; set; }

        public string IntegrationId { get; set; }

        public DateTime Created { get; set; }

        public string Content { get; set; }

        public ChatMessageRole Role { get; set; }

        public long ChatId { get; set; }
        public Chat Chat { get; set; }

        public bool IsDeleted { get; set; }
       
        public DateTime? DeletedAt { get; set; }
    }
}
