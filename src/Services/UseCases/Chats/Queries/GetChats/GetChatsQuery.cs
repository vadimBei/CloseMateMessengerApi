using MediatR;
using UseCases.Chats.ViewModels;

namespace UseCases.Chats.Queries.GetChats
{
    public class GetChatsQuery : IRequest<IEnumerable<ChatVM>>
    {
    }
}
