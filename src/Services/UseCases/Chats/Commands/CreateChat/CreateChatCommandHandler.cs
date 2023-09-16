using AutoMapper;
using Entities.Models;
using Infrastructure.Abstractions.Interfaces;
using MediatR;
using System.Text;
using UseCases.Chats.ViewModels;

namespace UseCases.Chats.Commands.CreateChat
{
    public class CreateChatCommandHandler : IRequestHandler<CreateChatCommand, ChatVM>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateChatCommandHandler(
            IMapper mapper,
            IApplicationDbContext applicationDbContext)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<ChatVM> Handle(CreateChatCommand request, CancellationToken cancellationToken)
        {
            var chatName = this.GetChatName(request.Data.Name);

            var chat = new Chat()
            {
                Created = DateTime.Now,
                Name = chatName
            };

            _applicationDbContext.Chats.Add(chat);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ChatVM>(chat);
        }

        private string GetChatName(string message)
        {
            var splitedMessage = message.Split(" ");

            var splitedChatName = splitedMessage.Take(10).ToList();

            var chatName = new StringBuilder();

            for (int i = 0; i < splitedChatName.Count; i++)
            {
                chatName.Append(splitedChatName[i]);

                if (i != splitedChatName.Count - 1)
                    chatName.Append(" ");
            }

            return chatName.ToString();
        }
    }
}
