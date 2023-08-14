using ApplicationServices.Interfaces;
using AutoMapper;
using MediatR;
using UseCases.ChatCompletions.ViewModels;

namespace UseCases.ChatCompletions.Queries.GetChatCompletionById
{
    public class GetChatCompletionByIdQueryHandler : IRequestHandler<GetChatCompletionByIdQuery, ChatCompletionVM>
    {
        private readonly IMapper _mapper;
        private readonly IChatCompletionService _chatCompletionService;

        public GetChatCompletionByIdQueryHandler(
            IMapper mapper,
            IChatCompletionService chatCompletionService)
        {
            _mapper = mapper;
            _chatCompletionService = chatCompletionService;
        }

        public async Task<ChatCompletionVM> Handle(GetChatCompletionByIdQuery request, CancellationToken cancellationToken)
        {
            var chatCompletion = await _chatCompletionService
                .GetChatCompletionById(request.Id, cancellationToken);

            return _mapper.Map<ChatCompletionVM>(chatCompletion);
        }
    }
}
