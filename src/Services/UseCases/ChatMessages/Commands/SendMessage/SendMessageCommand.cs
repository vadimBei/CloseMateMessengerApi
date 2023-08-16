using MediatR;
using UseCases.ChatMessages.Dtos;
using UseCases.ChatMessages.ViewModels;

namespace UseCases.ChatMessages.Commands.SendMessage
{
    public class SendMessageCommand : IRequest<ChatMessageVM>
    {
        public SendMessageDto Data { get; set; }
    }
}
