using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAI.Implementations.Options;
using OpenAI.Interfaces.Dtos;
using OpenAI.Interfaces.Interfaces;
using System.Buffers.Text;
using System.ComponentModel;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using System;
using WebClient.Implementations.Extensions;
using WebClient.Interfaces.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            //var resultJson =
            //    "{" +
            //        "\"id\": \"chatcmpl-7mNxq3BJEQ1NNYJl9XaJ1NvTveqat\"," +
            //        "\"object\": \"chat.completion\"," +
            //        "\"created\": 1691766218," +
            //        "\"model\": \"gpt-3.5-turbo-0613\"," +
            //        "\"choices\": [" +
            //            "{" +
            //            "\"index\": 0," +
            //            "\"message\": {" +
            //            "\"role\": \"assistant\"," +
            //            "\"content\": \"The Los Angeles Dodgers won the World Series in 2020.\"" +
            //            "}," +
            //            "\"finish_reason\": \"stop\"" +
            //            "}" +
            //        "]," +
            //        "\"usage\": {" +
            //            "\"prompt_tokens\": 17," +
            //            "\"completion_tokens\": 13," +
            //            "\"total_tokens\": 30" +
            //        "}" +
            //    "}";

            var resultJson = "{" +
                     "\"id\": \"chatcmpl-7mO0FLJzhPxnHdUXK2BbnNghikG0F\"," +
                     "\"object\": \"chat.completion\"," +
                     "\"created\": 1691766367," +
                     "\"model\": \"gpt-3.5-turbo-0613\"," +
                     "\"choices\": [ " +
                         "{" +
                             "\"index\": 0," +
                             "\"message\": {" +
                             "\"role\": \"assistant\"," +
                             "\"content\": \"In C#, a record is a new feature introduced in C# 9.0 that provides a succinct way to declare a type and its properties. Records are primarily used " +
                             "for immutability and provide useful features such as value - based equality, deconstruction, and robust ToString() implementation. " +
                             "\n\nTo create a C# record, follow these steps:\n\nStep 1: Create a new C# project or open an existing project in an integrated development environment (IDE) " +
                             "like Visual Studio.\n\nStep 2: Add a new class file to your project.\n\nStep 3: Inside the class file, declare a record using the `record` keyword followed " +
                             "by the name of the record.\n\nExample:\n```csharp\npublic record Person(string Name, int Age);\n```\n\nIn this example, we create a `Person` record with two " +
                             "properties - `Name` of type `string` and `Age` of type `int`.\n\nStep 4: Use the record in your program by instantiating it.\n\nExample:\n```csharp\nvar person = new Person(); " +
                             "\n```\n\nStep 5: Access the properties of the record using dot notation.\n\nExample:\n```csharp\nConsole.WriteLine();\n``` " +
                             "\n\nThis will output `Name: John Doe, Age: 25`.\n\nRecords in C# are by default immutable, meaning their properties cannot be modified after construction. " +
                             "If you want to modify the properties, you can use the `with` keyword to create a new record with the modified values. " +
                             "\n\nExample:\n```csharp\nvar modifiedPerson = person with { Age = 30 };\n```\n\nThis creates a new `Person` record with the same `Name` but a different `Age`." +
                             "\n\nThat's it! You have successfully created a C# record.\" " +
                             "}," +
                             "\"finish_reason\": \"stop\" " +
                         "}" +
                     "]," +
                     "\"usage\": {" +
                         "\"prompt_tokens\": 14," +
                         "\"completion_tokens\": 367," +
                         "\"total_tokens\": 381 " +
                     "} " +
                 "}";


            var chatCompletionDto = await Task.Run(() => JsonConvert.DeserializeObject<ChatCompletionDto>(resultJson));

            return chatCompletionDto;
        }
    }
}
