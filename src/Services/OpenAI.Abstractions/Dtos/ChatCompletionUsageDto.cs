using Newtonsoft.Json;

namespace OpenAI.Abstractions.Dtos
{
    public record ChatCompletionUsageDto
    {
        [JsonProperty("prompt_tokens")]
        public int PromptTokens { get; init; }

        [JsonProperty("completion_tokens")]
        public int CompletionTokens { get; init; }

        [JsonProperty("total_tokens")]
        public int TotalTokens { get; init; }
    }
}
