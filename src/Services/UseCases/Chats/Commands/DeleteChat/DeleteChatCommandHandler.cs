﻿using Entities.Exceptions;
using Entities.Models;
using Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace UseCases.Chats.Commands.DeleteChat
{
    public class DeleteChatCommandHandler : IRequestHandler<DeleteChatCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteChatCommandHandler(
            IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Unit> Handle(DeleteChatCommand request, CancellationToken cancellationToken)
        {
            var chatCompletion = await _applicationDbContext.Chats
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (chatCompletion == null)
            {
                throw new EntityNotFoundException(typeof(Chat), request.Id);
            }

            _applicationDbContext.Chats.Remove(chatCompletion);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
