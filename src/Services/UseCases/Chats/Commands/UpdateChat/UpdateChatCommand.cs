using MediatR;
using UseCases.Chats.Dtos;
using UseCases.Chats.ViewModels;

namespace UseCases.Chats.Commands.UpdateChat
{
    public class UpdateChatCommand : IRequest<ChatVM>
    {
        public UpdateChatDto Data { get; set; }
    }
}
