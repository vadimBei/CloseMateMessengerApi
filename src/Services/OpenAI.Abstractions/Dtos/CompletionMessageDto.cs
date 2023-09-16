using Newtonsoft.Json;

namespace OpenAI.Abstractions.Dtos
{
    public class CompletionMessageDto
    {
        [JsonProperty(PropertyName = "role")]
        public string Role { get; init; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; init; }
    }
}
