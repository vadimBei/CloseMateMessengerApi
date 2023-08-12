using ApplicationServices.Interfaces;
using AutoMapper;
using Entities.Enums;
using Entities.Models;
using Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OpenAI.Interfaces.Dtos;
using OpenAI.Interfaces.Interfaces;
using System.Text;
using UseCases.ChatCompletions.Dtos;
using UseCases.ChatCompletions.ViewModels;
using Utils.Exceptions;

namespace UseCases.ChatCompletions.Commands.CreateChatCompletion
{
    public class CreateChatCompletionCommandHandler : IRequestHandler<CreateChatCompletionCommand, ChatCompletionVM>
    {
        private readonly IMapper _mapper;
        private readonly IOpenAIService _openAIService;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IChatCompletionService _chatCompletionService;

        public CreateChatCompletionCommandHandler(
            IMapper mapper,
            IOpenAIService openAIService,
            IApplicationDbContext applicationDbContext,
            IChatCompletionService chatCompletionService)
        {
            _mapper = mapper;
            _openAIService = openAIService;
            _applicationDbContext = applicationDbContext;
            _chatCompletionService = chatCompletionService;
        }

        public async Task<ChatCompletionVM> Handle(CreateChatCompletionCommand request, CancellationToken cancellationToken)
        {
            var chatName = this.GetChatName(request.Message);

            var chatCompletionId = await this.CreateChatCompletion(chatName, cancellationToken);

            await this.CreateChatCompletionMessage(
                new CreateChatCompletionMessageDto(
                    string.Empty,
                    DateTime.Now,
                    request.Message,
                    ChatMessageRole.User,
                    chatCompletionId)
                , cancellationToken);

            var messages = new List<CompletionMessageDto>()
            {
                new CompletionMessageDto(ChatMessageRole.User.ToString(), request.Message)
            };

            var chatCompletionDto = await _openAIService
                .CreateChatCompletion(new CreateChatCompletionDto(messages), cancellationToken);

            await this.UpdateChatCompletionModel(
                new UpdateChatCompletionModelDto(chatCompletionId, chatCompletionDto.Model)
                , cancellationToken);

            await this.CreateChatCompletionMessage(
                new CreateChatCompletionMessageDto(
                    chatCompletionDto.Id,
                    DateTimeOffset.FromUnixTimeSeconds(chatCompletionDto.Created).DateTime,
                    chatCompletionDto.Choices.FirstOrDefault()!.Message.Content,
                    ChatMessageRole.Assistant,
                    chatCompletionId)
                , cancellationToken);

            await this.CreateChatCompletionUsage(
                new CreateChatCompletionUsageDto(
                    chatCompletionDto.Usage.PromptTokens,
                    chatCompletionDto.Usage.CompletionTokens,
                    chatCompletionDto.Usage.TotalTokens,
                    chatCompletionId)
                , cancellationToken);

            var chatCompletion = await _chatCompletionService
                .GetChatCompletionById(chatCompletionId, cancellationToken);

            return _mapper.Map<ChatCompletionVM>(chatCompletion);
        }

        private string GetChatName(string message)
        {
            var splitedMessage = message.Split(" ");

            var splitedChatName = splitedMessage.Take(10);

            var chatName = new StringBuilder();

            foreach (var word in splitedChatName)
            {
                chatName.Append(word);
                chatName.Append(" ");
            }

            return chatName.ToString();
        }

        private async Task<long> CreateChatCompletion(string chatName, CancellationToken cancellationToken)
        {
            var entity = new ChatCompletion()
            {
                Created = DateTime.Now,
                Name = chatName
            };

            _applicationDbContext.ChatCompletions.Add(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public async Task<ChatCompletionMessage> CreateChatCompletionMessage(CreateChatCompletionMessageDto dto, CancellationToken cancellationToken)
        {
            var entity = new ChatCompletionMessage()
            {
                IntegrationId = dto.IntegrationId,
                Created = dto.Created,
                Content = dto.Content,
                Role = dto.Role,
                ChatCompletionId = dto.ChatCompletionId
            };

            _applicationDbContext.ChatCompletionMessages.Add(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        private async Task<ChatCompletion> UpdateChatCompletionModel(UpdateChatCompletionModelDto dto, CancellationToken cancellationToken)
        {
            var chatCompletion = await _applicationDbContext.ChatCompletions
                .FirstOrDefaultAsync(x => x.Id == dto.Id, cancellationToken);

            if (chatCompletion == null)
            {
                throw new NotFoundException(typeof(ChatCompletion), dto.Id);
            }

            chatCompletion.Model = dto.Model;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return chatCompletion;
        }

        private async Task<ChatCompletionUsage> CreateChatCompletionUsage(CreateChatCompletionUsageDto dto, CancellationToken cancellationToken)
        {
            var entity = new ChatCompletionUsage()
            {
                PromptTokens = dto.PromptTokens,
                CompletionTokens = dto.CompletionTokens,
                TotalTokens = dto.TotalTokens,
                ChatCompletionId = dto.ChatCompletionId
            };

            _applicationDbContext.ChatCompletionUsages.Add(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
