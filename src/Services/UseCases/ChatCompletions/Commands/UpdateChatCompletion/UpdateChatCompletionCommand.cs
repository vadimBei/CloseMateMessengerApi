using MediatR;
using UseCases.ChatCompletions.ViewModels;

namespace UseCases.ChatCompletions.Commands.UpdateChatCompletion
{
    public class UpdateChatCompletionCommand : IRequest<ChatCompletionVM>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
