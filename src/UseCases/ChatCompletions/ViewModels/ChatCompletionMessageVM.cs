using AutoMapper;
using Entities.Enums;
using Entities.Models;

namespace UseCases.ChatCompletions.ViewModels
{
    [AutoMap(typeof(ChatCompletionMessage))]
    public class ChatCompletionMessageVM
    {
        public long Id { get; set; }

        public string IntegrationId { get; set; }

        public DateTime Created { get; set; }

        public string Content { get; set; }

        public ChatMessageRole Role { get; set; }
    }
}
