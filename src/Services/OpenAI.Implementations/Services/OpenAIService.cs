﻿using Microsoft.Extensions.Options;
using OpenAI.Abstractions.Dtos;
using OpenAI.Abstractions.Interfaces;
using OpenAI.Implementations.Options;
using WebClient.Abstractions.Interfaces;
using WebClient.Implementations.Extensions;

namespace OpenAI.Implementations.Services
{
    public class OpenAIService : IOpenAIService
    {
        private OpenAIOptions _openAIOptions;
        private readonly IWebClient _webClient;

        public OpenAIService(
            IOptions<OpenAIOptions> openAIOptions,
            IWebClient webClient)
        {
            _openAIOptions = openAIOptions.Value;

            _webClient = webClient;
            _webClient.Configure(x =>
            {
                x.WebResourcePath = "openai-api/chat-completions";
            });
        }

        public async Task<ChatCompletionDto> CreateChatCompletion(CreateChatCompletionDto dto, CancellationToken cancellationToken)
        {
            var bodyContent = new
            {
                model = _openAIOptions.Model,
                messages = dto.Messages
            };

            var response = await _webClient
                .WithBearerAuthentication(_openAIOptions.ApiKey)
                .WithStringContent(bodyContent)
                .Post<ChatCompletionDto>("", cancellationToken);

            return response;
        }
    }
}
