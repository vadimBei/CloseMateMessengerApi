using AutoMapper;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.ChatCompletions.ViewModels;

namespace UseCases.ChatCompletions.Queries.GetChatCompletions
{
    public class GetChatCompletionsQueryHandler : IRequestHandler<GetChatCompletionsQuery, IEnumerable<ChatCompletionVM>>
    {
        private readonly IMapper _mapper;
        private readonly IReadOnlyApplicationDbContext _readOnlyApplicationDbContext;

        public GetChatCompletionsQueryHandler(
            IMapper mapper,
            IReadOnlyApplicationDbContext readOnlyApplicationDbContext)
        {
            _mapper = mapper;
            _readOnlyApplicationDbContext = readOnlyApplicationDbContext;
        }

        public async Task<IEnumerable<ChatCompletionVM>> Handle(GetChatCompletionsQuery request, CancellationToken cancellationToken)
        {
            var chatCompletions = await _readOnlyApplicationDbContext.ChatCompletions
                .AsNoTracking()
                .OrderByDescending(x => x.Created)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ChatCompletionVM>>(chatCompletions);
        }
    }
}
