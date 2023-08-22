using MediatR;

namespace UseCases.Chats.Commands.DeleteChat
{
    public class DeleteChatCommand : IRequest
    {
        public long Id { get; set; }
    }
}
