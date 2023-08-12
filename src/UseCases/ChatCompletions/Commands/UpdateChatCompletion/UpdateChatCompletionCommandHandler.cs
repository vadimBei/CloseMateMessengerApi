using AutoMapper;
using Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.ChatCompletions.ViewModels;
using Utils.Exceptions;

namespace UseCases.ChatCompletions.Commands.UpdateChatCompletion
{
    public class UpdateChatCompletionCommandHandler : IRequestHandler<UpdateChatCompletionCommand, ChatCompletionVM>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateChatCompletionCommandHandler(
            IMapper mapper,
            IApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ChatCompletionVM> Handle(UpdateChatCompletionCommand request, CancellationToken cancellationToken)
        {
            var chatCompletion = await _applicationDbContext.ChatCompletions
                 .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (chatCompletion == null)
            {
                throw new NotFoundException(typeof(ChatCompletion), request.Id);
            }

            chatCompletion.Name = request.Name;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ChatCompletionVM>(chatCompletion);
        }
    }
}
