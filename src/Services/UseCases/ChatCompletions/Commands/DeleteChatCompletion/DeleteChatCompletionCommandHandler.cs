using Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Utils.Exceptions;

namespace UseCases.ChatCompletions.Commands.DeleteChatCompletion
{
    public class DeleteChatCompletionCommandHandler : IRequestHandler<DeleteChatCompletionCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteChatCompletionCommandHandler(
            IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Unit> Handle(DeleteChatCompletionCommand request, CancellationToken cancellationToken)
        {
            var chatCompletion = await _applicationDbContext.ChatCompletions
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (chatCompletion == null)
            {
                throw new NotFoundException(typeof(ChatCompletion), request.Id);
            }

            _applicationDbContext.ChatCompletions.Remove(chatCompletion);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
