using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OpenAI.Implementations.Options;
using OpenAI.Interfaces.Dtos;
using OpenAI.Interfaces.Interfaces;
using WebClient.Implementations.Extensions;
using WebClient.Interfaces.Interfaces;

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
            //var bodyContent = new
            //{
            //    model = _openAIOptions.Model,
            //    messages = dto.Messages
            //};

            //var result = await _webClient
            //    .WithBearerAuthentication(_openAIOptions.ApiKey)
            //    .WithStringContent(bodyContent)
            //    .Post<ChatCompletionDto>("", cancellationToken);

            var resultJson =
                "{" +
                    "\"id\": \"chatcmpl-7mNxq3BJEQ1NNYJl9XaJ1NvTveqat\"," +
                    "\"object\": \"chat.completion\"," +
                    "\"created\": 1691766218," +
                    "\"model\": \"gpt-3.5-turbo-0613\"," +
                    "\"choices\": [" +
                        "{" +
                        "\"index\": 0," +
                        "\"message\": {" +
                        "\"role\": \"assistant\"," +
                        "\"content\": \"The Los Angeles Dodgers won the World Series in 2020.\"" +
                        "}," +
                        "\"finish_reason\": \"stop\"" +
                        "}" +
                    "]," +
                    "\"usage\": {" +
                        "\"prompt_tokens\": 17," +
                        "\"completion_tokens\": 13," +
                        "\"total_tokens\": 30" +
                    "}" +
                "}";

            var chatCompletionDto = await Task.Run(() => JsonConvert.DeserializeObject<ChatCompletionDto>(resultJson));

            return chatCompletionDto;
        }
    }
}
