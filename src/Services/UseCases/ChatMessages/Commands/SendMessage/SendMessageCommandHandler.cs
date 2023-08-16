using ApplicationServices.Interfaces.Dtos;
using ApplicationServices.Interfaces.Interfaces;
using AutoMapper;
using Entities.Enums;
using MediatR;
using OpenAI.Interfaces.Dtos;
using OpenAI.Interfaces.Interfaces;
using UseCases.ChatMessages.ViewModels;

namespace UseCases.ChatMessages.Commands.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, ChatMessageVM>
    {
        private readonly IMapper _mapper;
        private readonly IChatService _chatService;
        private readonly IOpenAIService _openAIService;
        private readonly IChatMessageService _chatMessageService;

        public SendMessageCommandHandler(
            IMapper mapper, 
            IChatService chatService, 
            IOpenAIService openAIService, 
            IChatMessageService chatMessageService)
        {
            _mapper = mapper;
            _chatService = chatService;
            _openAIService = openAIService;
            _chatMessageService = chatMessageService;
        }

        public async Task<ChatMessageVM> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            await _chatService.GetChatById(request.Data.ChatId, cancellationToken);

            await _chatMessageService.CreateMessage(
                new CreateMessageDto(
                    string.Empty,
                    DateTime.Now,
                    request.Data.Content,
                    ChatMessageRole.User,
                    request.Data.ChatId)
                , cancellationToken);

            var chat = await _chatService.GetChatById(request.Data.ChatId, cancellationToken);

            var chatMessages = chat.Messages.ToList();

            var completionMessages = new List<CompletionMessageDto>();

            foreach (var message in chatMessages)
            {
                var completionMessage = new CompletionMessageDto(
                        message.Role.ToString().ToLower(),
                        message.Content);

                completionMessages.Add(completionMessage);
            }

            var chatCompletion = await _openAIService.CreateChatCompletion(
                new CreateChatCompletionDto(completionMessages)
                , cancellationToken);

            if (chatCompletion.Choices.Any())
            {
                var chatCompletionChoice = chatCompletion.Choices.FirstOrDefault();

                if (chatCompletionChoice != null)
                {
                    await _chatMessageService.CreateMessage(
                        new CreateMessageDto(
                            chatCompletion.Id,
                            DateTime.Now, //The date is manually generated while the service mocked.
                                          //DateTimeOffset.FromUnixTimeSeconds(chatCompletion.Created).DateTime,
                            chatCompletionChoice.Message.Content,
                            ChatMessageRole.Assistant,
                            chat.Id)
                        , cancellationToken);
                }                
            }

            var lastChatMessage = await _chatService.GetLastChatMessage(chat.Id, cancellationToken);

            return _mapper.Map<ChatMessageVM>(lastChatMessage);
        }
    }
}
