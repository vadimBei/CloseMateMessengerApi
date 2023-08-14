namespace UseCases.ChatCompletions.Dtos
{
    public record CreateChatCompletionUsageDto(
        int PromptTokens,
        int CompletionTokens,
        int TotalTokens,
        long ChatCompletionId);
}
