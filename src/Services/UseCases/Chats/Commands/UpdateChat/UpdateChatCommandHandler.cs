using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Infrastructure.Abstractions.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.Chats.ViewModels;

namespace UseCases.Chats.Commands.UpdateChat
{
    public class UpdateChatCommandHandler : IRequestHandler<UpdateChatCommand, ChatVM>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateChatCommandHandler(
            IMapper mapper, 
            IApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ChatVM> Handle(UpdateChatCommand request, CancellationToken cancellationToken)
        {
            var chatCompletion = await _applicationDbContext.Chats
                .FirstOrDefaultAsync(x => x.Id == request.Data.Id, cancellationToken);

            if (chatCompletion == null)
            {
                throw new EntityNotFoundException(typeof(Chat), request.Data.Id);
            }

            chatCompletion.Name = request.Data.Name;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ChatVM>(chatCompletion);
        }
    }
}
