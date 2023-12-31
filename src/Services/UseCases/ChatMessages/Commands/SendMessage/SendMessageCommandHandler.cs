﻿using ApplicationServices.Abstractions.Dtos;
using ApplicationServices.Abstractions.Interfaces;
using AutoMapper;
using Entities.Enums;
using MediatR;
using OpenAI.Abstractions.Dtos;
using OpenAI.Abstractions.Interfaces;
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
                var completionMessage = new CompletionMessageDto()
                {
                    Role = message.Role.ToString().ToLower(),
                    Content = message.Content
                };

                completionMessages.Add(completionMessage);
            }

            var chatCompletion = await _openAIService.CreateChatCompletion(
                new CreateChatCompletionDto()
                {
                    Messages = completionMessages
                }
                , cancellationToken);

            if (chatCompletion.Choices.Any())
            {
                var chatCompletionChoice = chatCompletion.Choices.FirstOrDefault();

                if (chatCompletionChoice != null)
                {
                    await _chatMessageService.CreateMessage(
                        new CreateMessageDto(
                            chatCompletion.Id,
                            DateTimeOffset.FromUnixTimeSeconds(chatCompletion.Created).DateTime,
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
