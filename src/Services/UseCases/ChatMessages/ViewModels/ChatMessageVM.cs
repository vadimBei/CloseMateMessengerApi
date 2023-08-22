using AutoMapper;
using Entities.Enums;
using Entities.Models;

namespace UseCases.ChatMessages.ViewModels
{
    [AutoMap(typeof(ChatMessage))]
    public class ChatMessageVM
    {
        public long Id { get; set; }

        public string IntegrationId { get; set; }

        public DateTime Created { get; set; }

        public string Content { get; set; }

        public ChatMessageRole Role { get; set; }
    }
}
