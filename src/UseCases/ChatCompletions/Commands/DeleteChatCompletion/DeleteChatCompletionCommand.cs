using MediatR;

namespace UseCases.ChatCompletions.Commands.DeleteChatCompletion
{
    public class DeleteChatCompletionCommand : IRequest
    {
        public long Id { get; set; }
    }
}
