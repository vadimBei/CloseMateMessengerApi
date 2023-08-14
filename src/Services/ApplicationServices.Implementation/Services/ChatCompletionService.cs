using ApplicationServices.Interfaces;
using Entities.Models;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Utils.Exceptions;

namespace ApplicationServices.Implementation.Services
{
    public class ChatCompletionService : IChatCompletionService
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IReadOnlyApplicationDbContext _readOnlyApplicationDbContext;

        public ChatCompletionService(
            IApplicationDbContext applicationDbContext, 
            IReadOnlyApplicationDbContext readOnlyApplicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _readOnlyApplicationDbContext = readOnlyApplicationDbContext;
        }

        public async Task<ChatCompletion> GetChatCompletionById(long id, CancellationToken cancellationToken)
        {
            var entity = await _readOnlyApplicationDbContext.ChatCompletions
               .AsNoTracking()
               .Include(x => x.Messages)
               .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(typeof(ChatCompletion), id);
            }

            entity.Messages = entity.Messages
                .OrderByDescending(x => x.Created)
                .ToList();

            return entity;
        }
    }
}
