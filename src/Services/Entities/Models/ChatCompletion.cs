namespace Entities.Models
{
    public class ChatCompletion
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public ChatCompletionUsage Usage { get; set; }

        public List<ChatCompletionMessage> Messages { get; set; }
    }
}