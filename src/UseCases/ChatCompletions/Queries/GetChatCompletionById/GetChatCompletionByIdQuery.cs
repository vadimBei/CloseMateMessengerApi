using MediatR;
using UseCases.ChatCompletions.ViewModels;

namespace UseCases.ChatCompletions.Queries.GetChatCompletionById
{
    public class GetChatCompletionByIdQuery : IRequest<ChatCompletionVM>
    {
        public long Id { get; set; }
    }
}
