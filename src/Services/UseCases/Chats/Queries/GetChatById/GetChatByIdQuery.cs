using MediatR;
using UseCases.Chats.ViewModels;

namespace UseCases.Chats.Queries.GetChatById
{
    public class GetChatByIdQuery : IRequest<ChatVM>
    {
        public long Id { get; set; }
    }
}
