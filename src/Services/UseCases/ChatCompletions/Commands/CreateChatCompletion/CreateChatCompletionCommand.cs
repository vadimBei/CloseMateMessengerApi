using MediatR;
using UseCases.ChatCompletions.ViewModels;

namespace UseCases.ChatCompletions.Commands.CreateChatCompletion
{
    public class CreateChatCompletionCommand : IRequest<ChatCompletionVM>
    {
        public string Message { get; set; }
    }
}
