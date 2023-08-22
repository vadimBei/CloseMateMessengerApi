using MediatR;
using UseCases.Chats.Dtos;
using UseCases.Chats.ViewModels;

namespace UseCases.Chats.Commands.CreateChat
{
    public class CreateChatCommand : IRequest<ChatVM>
    {
        public CreateChatDto Data { get; set; }
    }
}
