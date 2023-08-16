namespace Entities.Models
{
    public class Chat
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public List<ChatMessage> Messages { get; set; }
    }
}