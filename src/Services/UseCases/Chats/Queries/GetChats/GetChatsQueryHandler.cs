using AutoMapper;
using Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.Chats.ViewModels;

namespace UseCases.Chats.Queries.GetChats
{
    public class GetChatsQueryHandler : IRequestHandler<GetChatsQuery, IEnumerable<ChatVM>>
    {
        private readonly IMapper _mapper;
        private readonly IReadOnlyApplicationDbContext _readOnlyApplicationDbContext;

        public GetChatsQueryHandler(
            IMapper mapper, 
            IReadOnlyApplicationDbContext readOnlyApplicationDbContext)
        {
            _mapper = mapper;
            _readOnlyApplicationDbContext = readOnlyApplicationDbContext;
        }

        public async Task<IEnumerable<ChatVM>> Handle(GetChatsQuery request, CancellationToken cancellationToken)
        {
            var chatCompletions = await _readOnlyApplicationDbContext.Chats
                .AsNoTracking()
                .OrderByDescending(x => x.Created)
                .ToListAsync(cancellationToken);

            return _mapper.Map<IEnumerable<ChatVM>>(chatCompletions);
        }
    }
}
