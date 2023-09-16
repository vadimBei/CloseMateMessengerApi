using ApplicationServices.Abstractions.Interfaces;
using AutoMapper;
using MediatR;
using UseCases.Chats.ViewModels;

namespace UseCases.Chats.Queries.GetChatById
{
    public class GetChatByIdQueryHandler : IRequestHandler<GetChatByIdQuery, ChatVM>
    {
        private readonly IMapper _mapper;
        private readonly IChatService _chatService;

        public GetChatByIdQueryHandler(
            IMapper mapper, 
            IChatService chatService)
        {
            _mapper = mapper;
            _chatService = chatService;
        }

        public async Task<ChatVM> Handle(GetChatByIdQuery request, CancellationToken cancellationToken)
        {
            var chat = await _chatService.GetChatById(request.Id, cancellationToken);

            return _mapper.Map<ChatVM>(chat);
        }
    }
}
