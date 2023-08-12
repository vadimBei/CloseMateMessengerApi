using MediatR;
using UseCases.ChatCompletions.ViewModels;

namespace UseCases.ChatCompletions.Queries.GetChatCompletions
{
    public class GetChatCompletionsQuery : IRequest<IEnumerable<ChatCompletionVM>>
    {
    }
}
