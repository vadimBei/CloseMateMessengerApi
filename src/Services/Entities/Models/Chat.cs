using Entity.Abstractions.Interfaces;

namespace Entities.Models
{
    public class Chat : ISoftDeletable
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public List<ChatMessage> Messages { get; set; }
    }
}